# Intro
The challenge has 2 main components, parsing and sorting. I implemented a parsing solution that statically
checks the housenumber and uses a regex to check the suffix. For the Sorting part I implemented
**BubbleSort** and **QuickSort**. The Sorting methods is also configurable, **QuickSort** is used by default.

In order to allow sorting to work you need some way of determining if an object is considered 
greater, smaller or equal to another object. for this I implemented ```IComparable<T>``` on the 
**HouseNumberDetails** object. This also means that the Sorting services can be used with any object that implements it.

For benchmarking I used [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet).

# Setup
- Open a powershell/terminal window at the repository root.
- Build the application:
    - ```dotnet build ApplicationChallenge.sln --configuration Release``` 

# Running the app
- Navigate the terminal to the outputfolder of the **HouseNumbers.ConsoleApp** project:
    - ```CD src\HouseNumbers.ConsoleApp\bin\Release\net8.0```

- Run the App using the default settings:
    - ```dotnet HouseNumbers.App.dll```

- Run the App using the **BubbleSortService**:
    - ```dotnet HouseNumbers.App.dll --SortingSettings:Type BubbleSortService```

- Run the App and Sort the results in **descending order**:
    - ```dotnet HouseNumbers.App.dll --SortingSettings:Order Descending```

- Run the App and allow the suffix to consist of 2 letters instead of 1:
    - ```dotnet HouseNumbers.App.dll --ParseSettings:SuffixValidationRegex "^[A-Za-z]{1,2}$"```

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
| Parsing             | 2,689.72 μs | 40.907 μs | 38.264 μs |
| Sorting__BubbleSort |   430.17 μs |  8.478 μs | 16.734 μs |
| Sorting__QuickSort  |    15.75 μs |  0.248 μs |  0.220 μs |
