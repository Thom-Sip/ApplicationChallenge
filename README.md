# Intro
The challenge has 2 main components, parsing and sorting. I implemented a parsing solution that
uses Full static checking and 1 that uses partial Regex Checking. For the Sorting part I implemented
BubbleSort and QuickSort. After running the benchmarks it shows that:
- Static Parsing is slightly faster
- QuickSort is much faster

Which parsing and sorting method are used configurable. I set the defaults to the fastest solution

# Setup
- Open a powershell/terminal window at the repository root.
- Build the application:
    - ```dotnet build ApplicationChallenge.sln --configuration Release``` 
- Navigate the terminal to the outputfolder of the HouseNumbers.ConsoleApp project:
    - ```CD src\HouseNumbers.ConsoleApp\bin\Release\net8.0```
- Run the App using the default settings:
    - ```dotnet HouseNumbers.App.dll```
- Run the App using the BubbleSort: 
    - ```dotnet HouseNumbers.App.dll --SortingSettings:Type QuickSortService```
- Run the App using RegexValidation:
    - ```dotnet HouseNumbers.App.dll --ParsingSettings:Type Regex```

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
| Method              | Mean        | Error     | StdDev    |
|-------------------- |------------:|----------:|----------:|
| Sorting__QuickSort  |    16.79 μs |  0.328 μs |  0.426 μs |
| Sorting__BubbleSort |   530.60 μs |  3.339 μs |  2.960 μs |
| Parsing__Static     | 2,658.41 μs |  8.641 μs |  7.216 μs |
| Parsing__Regex      | 3,131.91 μs | 61.729 μs | 63.391 μs |
