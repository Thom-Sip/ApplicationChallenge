# Setup
- Open a powershell/terminal window at the repository root.
- Build the application:
    - ```dotnet build ApplicationChallenge.sln --configuration Release``` 
- Navigate the terminal to the outputfolder of the HouseNumbers.ConsoleApp project
    - ```CD src\HouseNumbers.ConsoleApp\bin\Release\net8.0```
- Run the App using the BubbleSortService:
    - ```dotnet HouseNumbers.App.dll --SortingSettings:Type BubbleSortService```
- Run the App using the QuickSortService: 
    - ```dotnet HouseNumbers.App.dll --SortingSettings:Type QuickSortService```

# Running the benchmark
- Navigate to the benchmark project output folder
    - ```CD ..\..\..\..\..\tests\HouseNumbers.Benchmark\bin\Release\net8.0```
- Run the Benchmark
    - ```dotnet HouseNumbers.Benchmark.dll```

# Benchmark result
- Running the benchmark on my machine gave the following result
```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
AMD Ryzen 9 7845HX with Radeon Graphics, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
```
| Method     | Mean      | Error    | StdDev   |
|----------- |----------:|---------:|---------:|
| QuickSort  |  15.94 μs | 0.314 μs | 0.605 μs |
| BubbleSort | 442.59 μs | 3.511 μs | 2.741 μs |
