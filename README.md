# benchmarks

Benchmarks for .NET

BenchmarkDotNet documentation: https://benchmarkdotnet.org/

Fork this repository, create your benchmark, add the results to this file and send a Pull Request.


## For vs Foreach vs Linq ForEach - Iteração, comparação e alteração entre listas (scamilo77 - Sugestão do Anderson)

Nota: No caso do ForEach (Linq), não é possível usar o comando BREAK, ou seja, sempre irá executar no PIOR CASO, sempre todos os itens da lista serão lidos a cada iteração.

```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-2600 CPU 3.40GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host] : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT  [AttachedDebugger]
  Core   : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT

Job=Core  Runtime=Core

|           Method | Size |         Mean |         Error |        StdDev |          Min |          Max |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |----- |-------------:|--------------:|--------------:|-------------:|-------------:|-------:|------:|------:|----------:|
|         UsingFor |   10 |     131.0 ns |     0.9766 ns |     0.9135 ns |     129.2 ns |     132.3 ns |      - |     - |     - |         - |
|     UsingForeach |   10 |     535.4 ns |    10.4301 ns |    13.5621 ns |     515.0 ns |     565.9 ns |      - |     - |     - |         - |
| UsingLinqForeach |   10 |     590.5 ns |     4.3212 ns |     4.0421 ns |     583.4 ns |     599.8 ns | 0.2241 |     - |     - |     944 B |
|         UsingFor |  200 |  54,330.9 ns |   393.0404 ns |   348.4201 ns |  53,821.1 ns |  54,881.6 ns |      - |     - |     - |         - |
|     UsingForeach |  200 | 127,845.8 ns |   537.6574 ns |   502.9251 ns | 127,191.0 ns | 128,630.4 ns |      - |     - |     - |         - |
| UsingLinqForeach |  200 | 133,428.9 ns | 1,586.3937 ns | 1,406.2967 ns | 131,401.1 ns | 136,404.1 ns | 4.1504 |     - |     - |   17664 B |

```


## String.Concat vs StringBuilder (scamilo77)

```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-2600 CPU 3.40GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host] : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT  [AttachedDebugger]
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


|             Method |  Job | Runtime | Size |        Mean |      Error |     StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------- |----- |-------- |----- |------------:|-----------:|-----------:|--------:|------:|------:|----------:|
|  UsingStringConcat |  Clr |     Clr |   10 |    842.6 ns |  14.382 ns |  13.452 ns |  0.1335 |     - |     - |     562 B |
| UsingStringbuilder |  Clr |     Clr |   10 |    792.0 ns |   5.711 ns |   5.342 ns |  0.1125 |     - |     - |     473 B |
|  UsingStringConcat | Core |    Core |   10 |    385.0 ns |   3.464 ns |   2.893 ns |  0.1330 |     - |     - |     560 B |
| UsingStringbuilder | Core |    Core |   10 |    364.3 ns |   1.496 ns |   1.326 ns |  0.0358 |     - |     - |     152 B |
|  UsingStringConcat |  Clr |     Clr |  100 |  8,459.7 ns | 107.859 ns |  95.614 ns |  1.3275 |     - |     - |    5617 B |
| UsingStringbuilder |  Clr |     Clr |  100 |  8,107.3 ns |  90.791 ns |  80.484 ns |  1.0681 |     - |     - |    4493 B |
|  UsingStringConcat | Core |    Core |  100 |  3,879.8 ns |  33.020 ns |  29.271 ns |  1.3313 |     - |     - |    5600 B |
| UsingStringbuilder | Core |    Core |  100 |  3,820.2 ns |  15.430 ns |  14.434 ns |  0.3319 |     - |     - |    1408 B |
|  UsingStringConcat |  Clr |     Clr | 1000 | 87,283.7 ns | 968.596 ns | 808.822 ns | 13.3057 |     - |     - |   56166 B |
| UsingStringbuilder |  Clr |     Clr | 1000 | 83,299.1 ns | 266.187 ns | 235.968 ns | 11.1084 |     - |     - |   46786 B |
|  UsingStringConcat | Core |    Core | 1000 | 40,136.3 ns | 422.029 ns | 394.766 ns | 13.3057 |     - |     - |   56000 B |
| UsingStringbuilder | Core |    Core | 1000 | 37,809.9 ns | 363.873 ns | 340.367 ns |  3.5400 |     - |     - |   14904 B |

```



## Thread vs. Task (scamilo77)

```

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-2600 CPU 3.40GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host] : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT  [AttachedDebugger]
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


|      Method |  Job | Runtime | Size |         Mean |        Error |       StdDev |          Min |          Max |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------ |----- |-------- |----- |-------------:|-------------:|-------------:|-------------:|-------------:|-------:|-------:|-------:|----------:|
| UsingThread |  Clr |     Clr |   10 | 116,433.0 ns | 1,123.516 ns |   995.968 ns | 114,325.6 ns | 117,454.7 ns | 0.3662 | 0.3662 | 0.3662 |     354 B |
|   UsingTask |  Clr |     Clr |   10 |     566.6 ns |     6.617 ns |     6.190 ns |     551.8 ns |     577.1 ns | 0.0296 | 0.0067 | 0.0010 |     145 B |
| UsingThread | Core |    Core |   10 | 107,359.8 ns |   654.423 ns |   580.129 ns | 106,245.9 ns | 108,147.0 ns | 2.3193 | 0.3662 | 0.3662 |     344 B |
|   UsingTask | Core |    Core |   10 |     548.2 ns |     8.018 ns |     7.500 ns |     531.7 ns |     560.3 ns | 0.0296 |      - |      - |     128 B |
| UsingThread |  Clr |     Clr |  100 | 116,584.1 ns | 1,376.228 ns | 1,287.324 ns | 114,572.8 ns | 118,170.4 ns | 0.3662 | 0.3662 | 0.3662 |     354 B |
|   UsingTask |  Clr |     Clr |  100 |     553.5 ns |    10.844 ns |    11.136 ns |     524.4 ns |     570.5 ns | 0.0296 | 0.0067 | 0.0010 |     145 B |
| UsingThread | Core |    Core |  100 | 107,674.0 ns |   820.038 ns |   726.943 ns | 106,437.3 ns | 108,935.0 ns | 2.3193 | 0.3662 | 0.3662 |     344 B |
|   UsingTask | Core |    Core |  100 |     556.7 ns |     3.473 ns |     3.248 ns |     551.2 ns |     560.8 ns | 0.0296 |      - |      - |     128 B |

```