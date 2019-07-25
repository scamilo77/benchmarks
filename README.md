# benchmarks

Benchmarks for .NET

BenchmarkDotNet documentation: https://benchmarkdotnet.org/

Fork this repository, create your benchmark, add the results to this file and send a Pull Request.


## Substring vs. Slice (scamilo77)

Nota: Este benchmark ilustra a performance do método Slice, da conversão do Slice para String (ToString) e da conversão do Slice para int(int.Parse).

```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-2600 CPU 3.40GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.301
  [Host]  : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT  [AttachedDebugger]
  DryCore : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT

Job=DryCore  Runtime=Core  IterationCount=1
LaunchCount=1  RunStrategy=ColdStart  UnrollFactor=1
WarmupCount=1

|                  Method |      Mean | Error |     Gen 0 |     Gen 1 | Gen 2 |  Allocated |
|------------------------ |----------:|------:|----------:|----------:|------:|-----------:|
|            UseSubstring | 16.445 ms |    NA | 2000.0000 |         - |     - | 11673632 B |
|                UseSlice |  5.883 ms |    NA |         - |         - |     - |       56 B |
| UseSubstringToAddString | 27.652 ms |    NA | 2000.0000 | 1000.0000 |     - | 13770808 B |
|     UseSliceToAddString | 14.325 ms |    NA | 1000.0000 |         - |     - |  6897232 B |
|    UseSubstringToAddInt | 25.024 ms |    NA | 2000.0000 |         - |     - | 11922232 B |
|        UseSliceToAddInt | 17.608 ms |    NA |         - |         - |     - |  1048656 B |


```

## For vs Foreach vs Linq ForEach - Iteração, comparação e alteração entre listas (scamilo77 - Sugestão do Anderson)

Nota: No caso do ForEach (Linq), não é possível usar o comando BREAK, ou seja, sempre irá executar no PIOR CASO, sempre todos os itens da lista serão lidos a cada iteração.

```

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-2600 CPU 3.40GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.301
  [Host] : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT  [AttachedDebugger]
  Core   : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT

Job=Core  Runtime=Core  InvocationCount=1
UnrollFactor=1

|           Method | Size |         Mean |       Error |      StdDev |       Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |----- |-------------:|------------:|------------:|-------------:|------:|------:|------:|----------:|
|       UsingWhile |   10 |     321.0 ns |    25.24 ns |    71.60 ns |     350.0 ns |     - |     - |     - |         - |
|         UsingFor |   10 |     306.1 ns |    26.88 ns |    78.41 ns |     300.0 ns |     - |     - |     - |         - |
|     UsingForeach |   10 |     820.0 ns |    33.95 ns |    97.41 ns |     800.0 ns |     - |     - |     - |         - |
| UsingLinqForeach |   10 |   3,272.0 ns |   639.44 ns | 1,813.98 ns |   2,100.0 ns |     - |     - |     - |     944 B |
|       UsingWhile |  200 |  54,742.6 ns | 1,096.13 ns | 2,312.12 ns |  54,800.0 ns |     - |     - |     - |         - |
|         UsingFor |  200 |  55,359.0 ns | 1,109.63 ns | 2,864.31 ns |  55,250.0 ns |     - |     - |     - |         - |
|     UsingForeach |  200 | 136,125.9 ns | 2,700.65 ns | 5,696.58 ns | 135,750.0 ns |     - |     - |     - |         - |
| UsingLinqForeach |  200 | 140,021.9 ns | 3,193.30 ns | 4,971.58 ns | 140,100.0 ns |     - |     - |     - |   17664 B |
```


## Thread vs. Task (scamilo77)

```

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-2600 CPU 3.40GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.301
  [Host] : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT  [AttachedDebugger]
  Core   : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT

Job=Core  Runtime=Core

|      Method | Size |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------ |----- |-------------:|-------------:|-------------:|-------:|-------:|-------:|----------:|
| UsingThread |   10 | 110,288.8 ns |   697.241 ns |   582.228 ns | 2.3193 | 0.3662 | 0.3662 |     344 B |
|   UsingTask |   10 |     451.5 ns |     5.637 ns |     4.997 ns | 0.0300 |      - |      - |     128 B |
| UsingThread |  100 | 110,240.6 ns | 1,370.164 ns | 1,281.652 ns | 2.3193 | 0.3662 | 0.3662 |     344 B |
|   UsingTask |  100 |     461.3 ns |     8.894 ns |     8.319 ns | 0.0300 |      - |      - |     128 B |

```

## String.Concat vs StringBuilder (scamilo77)

```

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-2600 CPU 3.40GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.301
  [Host]  : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT  [AttachedDebugger]
  DryCore : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT

Job=DryCore  Runtime=Core  IterationCount=1
LaunchCount=1  RunStrategy=ColdStart  UnrollFactor=1
WarmupCount=1

|             Method | Size |     Mean | Error | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------- |----- |---------:|------:|------:|------:|------:|----------:|
|  UsingStringConcat |   10 | 698.5 us |    NA |     - |     - |     - |     560 B |
| UsingStringbuilder |   10 | 717.7 us |    NA |     - |     - |     - |     152 B |
|  UsingStringConcat |  100 | 728.6 us |    NA |     - |     - |     - |    5600 B |
| UsingStringbuilder |  100 | 911.4 us |    NA |     - |     - |     - |    1408 B |
|  UsingStringConcat | 1000 | 770.5 us |    NA |     - |     - |     - |   56000 B |
| UsingStringbuilder | 1000 | 816.0 us |    NA |     - |     - |     - |   14904 B |

```


