param(
  [string]$Configuration = "Release"
)

nuget restore
msbuild /p:Configuration=$Configuration
