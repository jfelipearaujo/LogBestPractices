Serilog results

Logs level: Information
Minimum Level: Warning

|                                     Method |                 Mean |              Error |             StdDev |       Gen 0 |       Allocated |
|------------------------------------------- |---------------------:|-------------------:|-------------------:|------------:|----------------:|
|                              SimpleProcess |             3.577 ns |          0.0116 ns |          0.0097 ns |           - |               - |
|                    SimpleProcessWithParams |             9.176 ns |          0.0741 ns |          0.0657 ns |           - |               - |
|       SimpleProcessWithStringInterpolation |           656.386 ns |          9.3832 ns |          8.7770 ns |      0.0877 |           552 B |
|                        SimpleProcessWithIf |             1.842 ns |          0.0155 ns |          0.0137 ns |           - |               - |
|              SimpleProcessWithParamsWithIf |             1.879 ns |          0.0036 ns |          0.0032 ns |           - |               - |
| SimpleProcessWithStringInterpolationWithIf |             1.862 ns |          0.0044 ns |          0.0041 ns |           - |               - |
|                    HeavyProccessWithParams |    91,920,852.222 ns |    222,152.9755 ns |    207,802.0311 ns |           - |           892 B |
|             HeavyProccessAdapterWithParams |   135,070,303.571 ns |    211,422.2085 ns |    187,420.2810 ns |           - |           314 B |
|              HeavyProccessWithParamsWithIf |    20,170,683.750 ns |     46,032.5353 ns |     43,058.8621 ns |           - |            42 B |
|       HeavyProccessWithStringInterpolation | 6,597,733,246.667 ns | 48,808,460.1546 ns | 45,655,463.9115 ns | 879000.0000 | 5,520,000,000 B | 5,52 GB
| HeavyProccessWithStringInterpolationWithIf |    20,126,878.542 ns |     43,904.6022 ns |     41,068.3921 ns |           - |            41 B |

Methods WithIf statements are irrelevant for this benchmark because Serilog already do the "ifs" internally