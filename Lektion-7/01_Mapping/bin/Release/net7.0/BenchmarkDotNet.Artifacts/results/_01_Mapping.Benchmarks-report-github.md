``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1265/22H2/2022Update/SunValley2)
AMD Ryzen 7 5800, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.200
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|        Method | InstanceCount |     Mean |     Error |    StdDev |
|-------------- |-------------- |---------:|----------:|----------:|
| DirectMapping |             1 | 6.799 ms | 0.1108 ms | 0.0982 ms |
|    AutoMapper |             1 | 7.887 ms | 0.0860 ms | 0.0762 ms |
|      Implicit |             1 | 6.619 ms | 0.0564 ms | 0.0500 ms |
