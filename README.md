# Setup
- Open a powershell/terminal window at the repository root.
- Build the application:
    - ```dotnet build ApplicationChallenge.sln``` 
- Navigate the terminal to the outputfolder of the HouseNumbers.ConsoleApp project
    - ```CD src\HouseNumbers.ConsoleApp\bin\Debug\net8.0```
- Run the App using the BubbleSortService:
    - ```dotnet HouseNumbers.App.dll --SortingSettings:Type BubbleSortService```
- Run the App using the QuickSortService: 
    - ```dotnet HouseNumbers.App.dll --SortingSettings:Type QuickSortService```
