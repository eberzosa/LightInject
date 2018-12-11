@SETLOCAL

@SET Root=X:\
@SET Nuget=%Root%tools\nuget.exe
@SET NugetFolder=%Root%packages

@SET Project=LightInject
@SET Solution=src\%Project%.sln

dotnet build %Solution% /t:Build /p:Configuration=Release

dotnet pack src\%Project%\%Project%.csproj --output %NugetFolder% --no-build

@echo.
@echo Press Control+C to abort NuGet Publish
@echo.
@Pause 

%Nuget% push %NugetFolder%\%Project%.*.nupkg -ConfigFile ..\..\nuget.config -Source EBerzosa-NuGetPublish -Verbosity detailed
