``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22623.1250)
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


```
|               Method |  Count |         Mean |       Error |      StdDev |       Median |
|--------------------- |------- |-------------:|------------:|------------:|-------------:|
|            **BitWriter** |    **100** |     **432.0 μs** |    **15.32 μs** |    **43.47 μs** |     **423.6 μs** |
|          StreamWrite |    100 |     437.0 μs |    19.05 μs |    52.79 μs |     422.6 μs |
| BitWriterSmallBuffer |    100 |   1,654.2 μs |    29.24 μs |    36.98 μs |   1,654.5 μs |
|     StreamWriteAsync |    100 |     365.2 μs |     7.07 μs |     9.19 μs |     365.9 μs |
|            **BitWriter** |   **1000** |     **430.7 μs** |    **12.30 μs** |    **34.10 μs** |     **421.6 μs** |
|          StreamWrite |   1000 |     610.3 μs |    47.04 μs |   125.55 μs |     590.5 μs |
| BitWriterSmallBuffer |   1000 |   3,739.3 μs |    71.90 μs |    98.41 μs |   3,757.3 μs |
|     StreamWriteAsync |   1000 |     452.1 μs |    16.04 μs |    46.01 μs |     434.7 μs |
|            **BitWriter** | **100000** |   **4,738.8 μs** |   **341.72 μs** |   **980.47 μs** |   **4,536.4 μs** |
|          StreamWrite | 100000 |   8,635.7 μs |   523.25 μs | 1,492.87 μs |   8,388.4 μs |
| BitWriterSmallBuffer | 100000 | 308,267.1 μs | 5,861.89 μs | 6,272.15 μs | 309,207.5 μs |
|     StreamWriteAsync | 100000 |           NA |          NA |          NA |           NA |

Benchmarks with issues:
  Benchmarks.StreamWriteAsync: DefaultJob [Count=100000]
