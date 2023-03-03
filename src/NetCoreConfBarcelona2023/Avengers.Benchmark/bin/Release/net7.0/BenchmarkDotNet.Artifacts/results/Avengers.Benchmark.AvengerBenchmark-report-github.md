``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2546/22H2/2022Update)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


```
|            Method |      Mean |    Error |   StdDev |
|------------------ |----------:|---------:|---------:|
|  GrpcGetallMethod |  88.07 ms | 1.657 ms | 1.701 ms |
| GrpcGetByIdMethod |  84.36 ms | 0.706 ms | 0.626 ms |
|  RestGetallMethod | 124.98 ms | 1.526 ms | 1.427 ms |
| RestGetByIdMethod | 123.95 ms | 1.572 ms | 1.470 ms |
