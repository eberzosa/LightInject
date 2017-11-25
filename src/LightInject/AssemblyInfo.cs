using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("LightInject")]
#if NET452
    [assembly: AssemblyProduct("LightInject (NET45)")]
#endif
#if NET46
[assembly: AssemblyProduct("LightInject (NET46)")]
#endif
#if NETSTANDARD1_1
    [assembly: AssemblyProduct("LightInject (NETSTANDARD11)")]
#endif
#if NETSTANDARD1_3
    [assembly: AssemblyProduct("LightInject (NETSTANDARD13)")]
#endif
#if NETSTANDARD1_6
    [assembly: AssemblyProduct("LightInject (NETSTANDARD16)")]
#endif
[assembly: AssemblyCopyright("Copyright © Bernhard Richter 2017")]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("4.0.0")]
[assembly: AssemblyFileVersion("4.0.0")]
[assembly: AssemblyInformationalVersion("4.0.0")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:FileMustHaveHeader", Justification = "Custom header.")]
[assembly: InternalsVisibleTo("LightInject.Benchmarks, PublicKey=002400000480000094000000060200000024000052534131000400000100010009a0524a3fac11a4dcd1c6e004d83287420b52b355c9b69c161af8481e52dbb17041bf8ae7c6a0f49e4c665fc4b040ef1974f12d25b8b225148db6e1cbd0ec65f147432cc0d33b6904c65821c4e9fc62b7f45d76533cfc43b60af58b25df370aa6c4b610efcb23d53320867ea1d48da1933583b4a1a71553f5711cf2017390eb")]
