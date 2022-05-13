# LogBestPractices

### Legend
- SP: Simple Process
- SPwPar: Simple Process With Params
- SPwStrInt: Simple Process With String Interpolation
- SPwIf: Simples Process With If
- SPwPaRwIf: Simple Process With Params and With If
- SPwStrIntWif: Simple Process With String Interpolation and With If
- HPwPar: Heavy Process With Params
- HPwParWif: Heavy Proccess With Params and WithIf
- HPwAdpPar: Heavy Proccess with Adapter and With Params
- HPwStrInt: Heavy Proccess With String Interpolation
- HPwStrIntWif: Heavy Proccess With String Interpolation and With If

## Microsoft logger and Log Adapter results

*Logs level: Information* and *Minimum Level: Warning*

|       Method |                 Mean |              Error |             StdDev |       Gen 0 |       Allocated |
|------------- |---------------------:|-------------------:|-------------------:|------------:|----------------:|
|           SP |            36.024 ns |          0.1062 ns |          0.0829 ns |           - |               - |
|       SPwPar |           122.591 ns |          0.7873 ns |          0.6574 ns |      0.0215 |           136 B |
|    SPwStrInt |           725.163 ns |          6.1399 ns |          5.4429 ns |      0.0877 |           552 B |
|        SPwIf |             6.639 ns |          0.0196 ns |          0.0153 ns |           - |               - |
|    SPwPaRwIf |             6.668 ns |          0.1352 ns |          0.1198 ns |           - |               - |
| SPwStrIntWif |            12.575 ns |          0.0423 ns |          0.0330 ns |           - |               - |
|       HPwPar | 1,214,381,552.941 ns | 20,542,754.6812 ns | 21,095,896.6046 ns | 216000.0000 | 1,360,001,848 B or 1,36 GB |
|    HPwParWif |    64,186,693.269 ns |    191,468.1840 ns |    159,884.6052 ns |           - |         1,201 B |
|    HPwAdpPar |   172,190,791.111 ns |    520,769.4771 ns |    487,128.0920 ns |           - |               - |
|    HPwStrInt | 6,965,133,757.143 ns | 38,524,944.2117 ns | 34,151,359.5860 ns | 879000.0000 | 5,520,001,440 B or 5,52 GB|
| HPwStrIntWif |    64,927,518.750 ns |     33,082.4815 ns |     29,326.7582 ns |           - |           614 B |

## Serilog results

*Logs level: Information* and *Minimum Level: Warning*

|       Method |                 Mean |              Error |             StdDev |       Gen 0 |       Allocated |
|------------- |---------------------:|-------------------:|-------------------:|------------:|----------------:|
|           SP |             3.577 ns |          0.0116 ns |          0.0097 ns |           - |               - |
|       SPwPar |             9.176 ns |          0.0741 ns |          0.0657 ns |           - |               - |
|    SPwStrInt |           656.386 ns |          9.3832 ns |          8.7770 ns |      0.0877 |           552 B |
|        SPwIf |             1.842 ns |          0.0155 ns |          0.0137 ns |           - |               - |
|    SPwPaRwIf |             1.879 ns |          0.0036 ns |          0.0032 ns |           - |               - |
| SPwStrIntWif |             1.862 ns |          0.0044 ns |          0.0041 ns |           - |               - |
|       HPwPar |    91,920,852.222 ns |    222,152.9755 ns |    207,802.0311 ns |           - |           892 B |
|    HPwParWif |   135,070,303.571 ns |    211,422.2085 ns |    187,420.2810 ns |           - |           314 B |
|    HPwAdpPar |    20,170,683.750 ns |     46,032.5353 ns |     43,058.8621 ns |           - |            42 B |
|    HPwStrInt | 6,597,733,246.667 ns | 48,808,460.1546 ns | 45,655,463.9115 ns | 879000.0000 | 5,520,000,000 B or 5,52 GB |
| HPwStrIntWif |    20,126,878.542 ns |     43,904.6022 ns |     41,068.3921 ns |           - |            41 B |

Methods WithIf statements are irrelevant for this benchmark because Serilog already do the "ifs" internally
