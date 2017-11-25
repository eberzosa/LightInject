@SETLOCAL

@SET Root=X:\
@SET Nuget=%Root%\tools\nuget.exe
@SET NugetFolder=%Root%\NuGetPackages


@SET Solution=src\LightInject.sln

MsBuild.exe %Solution% /t:Build /p:Configuration=Release

@SET Project=LightInject
%Nuget% pack src\%Project%\%Project%.nuspec -OutputDirectory %NugetFolder% -Properties Configuration=Release

@Pause

%Nuget% push %NugetFolder%\LightInject.nupkg -ConfigFile ..\..\nuget.config -Source Nuget-EBerzosa -Verbosity detailed
