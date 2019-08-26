``` ini

BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.5 (18F132) [Darwin 18.6.0]
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview6-012264
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|           Method |     Mean |     Error |    StdDev |
|----------------- |---------:|----------:|----------:|
| UsingLightInject | 93.88 ns | 1.7239 ns | 1.5282 ns |
|   UsingMicrosoft | 39.85 ns | 0.3799 ns | 0.3172 ns |
