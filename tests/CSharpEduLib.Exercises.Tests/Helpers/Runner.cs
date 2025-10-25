using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CSharpEduLib.Exercises.Tests.Helpers
{
    public static class Runner
    {
        public static (bool success, string stdout, string stderr) Run(string sourceCode)
        {
            try
            {
                var temp = Path.Combine(Path.GetTempPath(), "CSharpEduLib");
                Directory.CreateDirectory(temp);
                var src = Path.Combine(temp, $"Program_{Guid.NewGuid():N}.cs");
                var exe = Path.ChangeExtension(src, ".exe");
                File.WriteAllText(src, sourceCode, Encoding.UTF8);

                // Пытаемся найти csc.exe из .NET Framework 4.x
                var frameworkDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Microsoft.NET\Framework\v4.0.30319";
                var csc = Path.Combine(frameworkDir, "csc.exe");
                if (!File.Exists(csc))
                {
                    return (false, "", "csc.exe не найден. Убедитесь, что установлен .NET Framework 4.8 SDK/Developer Pack");
                }

                var psi = new ProcessStartInfo
                {
                    FileName = csc,
                    Arguments = $"/nologo /t:exe /out:\"{exe}\" \"{src}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                };

                using (var proc = Process.Start(psi))
                {
                    proc.WaitForExit(15000);
                    if (proc.ExitCode != 0 || !File.Exists(exe))
                    {
                        return (false, proc.StandardOutput.ReadToEnd(), proc.StandardError.ReadToEnd());
                    }
                }

                var runPsi = new ProcessStartInfo
                {
                    FileName = exe,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                };

                using (var run = Process.Start(runPsi))
                {
                    run.WaitForExit(15000);
                    var stdout = run.StandardOutput.ReadToEnd();
                    var stderr = run.StandardError.ReadToEnd();
                    return (run.ExitCode == 0, stdout, stderr);
                }
            }
            catch (Exception ex)
            {
                return (false, "", ex.Message);
            }
        }
    }
}