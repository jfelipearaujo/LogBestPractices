# LogBestPractices

### Legend
- SP: Simple process
- SPwPar: Simple process with parameters
- SPwStrInt: Simple process with string interpolation
- SPwIf: Simple process with If (for log level)
- SPwParIf: Simple process with parameters and If (for log level)
- SPwStrIntIf: Simple process with string interpolation and If (for log level)
- HPwPar: Heavy process with parameters
- HPwAdpPar: Heavy process with log Adapter and parameters
- HPwAdpParAnoObj: Heavy process with log Adapter, parameters and anonymous object
- HPwAdpParKnoObj: Heavy process with log Adapter, parameters and known object
- HPwAdpParKnoObjWithIf: Heavy process with log Adapter, parameters and anonymous object and If (for log level)
- HPwAdpParAnoObjWithIf: Heavy process with log Adapter, parameters and known object and If (for log level)
- HPwParIf: Heavy process with parameters and If (for log level)
- HPwStrInt: Heavy process with string interpolation
- HPwStrIntIf: Heavy process with string interpolation and If (for log level)

### Test details

All logs are calling Debug method and the minimum level is defined for Information.

## Microsoft logger and Log Adapter results

|                Method |                Mean |             Error |            StdDev | Rank |       Gen 0 |       Allocated |
|---------------------- |--------------------:|------------------:|------------------:|-----:|------------:|----------------:|
|                    SP |            44.12 ns |          0.192 ns |          0.150 ns |    1 |           - |               - |
|                 SPwIf |            55.43 ns |          0.584 ns |          0.547 ns |    2 |           - |               - |
|                SPwPar |           133.12 ns |          1.021 ns |          0.955 ns |    3 |      0.0215 |           136 B |
|              SPwParIf |           141.46 ns |          0.335 ns |          0.297 ns |    4 |      0.0215 |           136 B |
|           SPwStrIntIf |           732.71 ns |          3.086 ns |          2.736 ns |    5 |      0.0877 |           552 B |
|             SPwStrInt |           733.35 ns |          5.650 ns |          5.285 ns |    5 |      0.0877 |           552 B |
|                HPwPar | 1,331,299,300.00 ns |  4,241,083.793 ns |  3,759,610.315 ns |    6 | 216000.0000 | 1,360,000,000 B |
|              HPwParIf | 1,375,677,961.54 ns |  5,966,537.528 ns |  4,982,329.061 ns |    7 | 216000.0000 | 1,360,000,000 B |
|             HPwAdpPar | 1,549,881,207.14 ns |  5,678,376.440 ns |  5,033,732.810 ns |    8 | 216000.0000 | 1,360,000,000 B |
|       HPwAdpParAnoObj | 1,614,623,650.00 ns |  6,068,595.478 ns |  4,737,960.174 ns |    9 | 280000.0000 | 1,760,001,336 B |
| HPwAdpParKnoObjWithIf | 1,639,876,223.53 ns | 31,922,942.707 ns | 32,782,511.845 ns |   10 | 229000.0000 | 1,440,000,000 B |
|       HPwAdpParKnoObj | 1,644,097,686.67 ns | 11,357,920.356 ns | 10,624,205.748 ns |   10 | 229000.0000 | 1,440,000,000 B |
| HPwAdpParAnoObjWithIf | 1,708,052,660.00 ns | 15,772,143.506 ns | 14,753,272.821 ns |   11 | 280000.0000 | 1,760,001,848 B |
|             HPwStrInt | 7,219,351,571.43 ns | 30,437,985.748 ns | 26,982,481.548 ns |   12 | 879000.0000 | 5,520,000,000 B |
|           HPwStrIntIf | 7,307,434,406.67 ns | 28,958,760.275 ns | 27,088,042.328 ns |   12 | 879000.0000 | 5,520,000,000 B |

## Serilog results

|                Method |                 Mean |              Error |             StdDev | Rank |       Gen 0 |       Allocated |
|---------------------- |---------------------:|-------------------:|-------------------:|-----:|------------:|----------------:|
|                 SPwIf |             1.854 ns |          0.0240 ns |          0.0224 ns |    1 |           - |               - |
|           SPwStrIntIf |             1.915 ns |          0.0222 ns |          0.0197 ns |    2 |           - |               - |
|              SPwParIf |             1.923 ns |          0.0316 ns |          0.0295 ns |    2 |           - |               - |
|                    SP |             3.532 ns |          0.0405 ns |          0.0378 ns |    3 |           - |               - |
|                SPwPar |             9.354 ns |          0.0832 ns |          0.0778 ns |    4 |           - |               - |
|             SPwStrInt |           653.558 ns |          7.9920 ns |          7.0847 ns |    5 |      0.0877 |           552 B |
|              HPwParIf |    20,191,036.458 ns |     32,939.6862 ns |     25,717.1403 ns |    6 |           - |            41 B |
|           HPwStrIntIf |    20,552,954.018 ns |    108,768.4595 ns |     96,420.4063 ns |    7 |           - |           150 B |
|                HPwPar |    92,351,927.381 ns |    374,867.6137 ns |    332,310.3754 ns |    8 |           - |           225 B |
|             HPwAdpPar |   141,604,636.667 ns |  1,197,639.2664 ns |  1,120,272.5129 ns |    9 |           - |         2,330 B |
| HPwAdpParKnoObjWithIf |   142,645,639.286 ns |    526,344.8661 ns |    466,591.0142 ns |    9 |           - |         2,330 B |
| HPwAdpParAnoObjWithIf |   174,129,451.111 ns |  1,138,075.2841 ns |  1,064,556.3269 ns |   10 |  51000.0000 |   320,000,000 B |
|       HPwAdpParKnoObj | 1,118,782,660.000 ns |  2,912,871.8093 ns |  2,724,702.0977 ns |   11 | 395000.0000 | 2,480,000,000 B |
|       HPwAdpParAnoObj | 1,154,114,133.333 ns | 11,418,594.6462 ns | 10,680,960.5166 ns |   12 | 446000.0000 | 2,800,000,000 B |
|             HPwStrInt | 6,569,995,369.231 ns | 30,034,661.0617 ns | 25,080,302.2632 ns |   13 | 879000.0000 | 5,520,000,000 B |

Methods WithIf statements are irrelevant for this benchmark because Serilog already do the "ifs" internally
