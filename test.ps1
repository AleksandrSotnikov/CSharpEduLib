param(
  [string]$Configuration = "Release"
)

# Найти все тестовые сборки (NUnit под .NET Framework 4.8)
$testDlls = Get-ChildItem -Recurse -Filter *Tests.dll | Where-Object { $_.FullName -notmatch "ref|TestHost|TestAdapter|TestFramework" }

# Запуск тестов через vstest.console
foreach ($dll in $testDlls) {
  & vstest.console.exe $dll.FullName /Platform:x64 /Framework:.NETFramework,Version=v4.8
}
