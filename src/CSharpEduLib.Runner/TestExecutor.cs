using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CSharpEduLib.Runner
{
    public class CompileResult
    {
        public bool Success { get; set; }
        public string StdOut { get; set; } = string.Empty;
        public string StdErr { get; set; } = string.Empty;
        public string OutputExePath { get; set; } = string.Empty;
    }

    public class ExecutionResult
    {
        public bool Success { get; set; }
        public string StdOut { get; set; } = string.Empty;
        public string StdErr { get; set; } = string.Empty;
        public int ExitCode { get; set; }
        public bool TimedOut { get; set; }
    }

    public interface ICompilerAdapter
    {
        CompileResult Compile(string sourcePath, string outputDir);
    }

    public class CscCompilerAdapter : ICompilerAdapter
    {
        private readonly string _cscPath;
        private readonly string _additionalArgs;

        public CscCompilerAdapter(string cscPath = "csc.exe", string additionalArgs = "/nologo /nowarn:1701,1702 /optimize+")
        {
            _cscPath = cscPath;
            _additionalArgs = additionalArgs;
        }

        public CompileResult Compile(string sourcePath, string outputDir)
        {
            Directory.CreateDirectory(outputDir);
            var exePath = Path.Combine(outputDir, "program.exe");

            var psi = new ProcessStartInfo
            {
                FileName = _cscPath,
                Arguments = $"/nologo {_additionalArgs} /target:exe /out:\"{exePath}\" \"{sourcePath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using var proc = Process.Start(psi);
            var stdout = proc.StandardOutput.ReadToEnd();
            var stderr = proc.StandardError.ReadToEnd();
            proc.WaitForExit();

            var success = proc.ExitCode == 0 && File.Exists(exePath);
            return new CompileResult { Success = success, StdOut = stdout, StdErr = stderr, OutputExePath = success ? exePath : string.Empty };
        }
    }

    public static class TestExecutor
    {
        public static ExecutionResult Run(string exePath, string? input = null, int timeoutMs = 5000)
        {
            var psi = new ProcessStartInfo
            {
                FileName = exePath,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var proc = new Process { StartInfo = psi };
            proc.Start();

            if (!string.IsNullOrEmpty(input))
            {
                proc.StandardInput.Write(input);
                if (!input.EndsWith("\n")) proc.StandardInput.Write("\n");
                proc.StandardInput.Flush();
                proc.StandardInput.Close();
            }

            var stdoutSb = new StringBuilder();
            var stderrSb = new StringBuilder();
            proc.OutputDataReceived += (_, e) => { if (e.Data != null) stdoutSb.AppendLine(e.Data); };
            proc.ErrorDataReceived += (_, e) => { if (e.Data != null) stderrSb.AppendLine(e.Data); };
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();

            var exited = proc.WaitForExit(timeoutMs);
            if (!exited)
            {
                try { proc.Kill(true); } catch { }
                return new ExecutionResult { Success = false, TimedOut = true, ExitCode = -1, StdOut = stdoutSb.ToString(), StdErr = stderrSb.ToString() };
            }

            return new ExecutionResult { Success = proc.ExitCode == 0, ExitCode = proc.ExitCode, StdOut = stdoutSb.ToString(), StdErr = stderrSb.ToString() };
        }

        public static string Normalize(string s)
        {
            if (s == null) return string.Empty;
            s = s.Replace("\r\n", "\n").Replace("\r", "\n");
            var lines = s.Split('\n');
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].TrimEnd();
            return string.Join("\n", lines).Trim();
        }
    }
}
