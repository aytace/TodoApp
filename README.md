
# TodoApp

A simple C#/.NET To-Do app with ASP.NET Core Web API backend and Blazor WebAssembly frontend.

## How to Run

1. Build the solution:
   ```
   dotnet build
   ```
2. Run the backend:
   ```
   dotnet run --project TodoApp.Api
   ```
3. Run the frontend:
   ```
   dotnet run --project TodoApp.Client
   ```
4. Open your browser at the URL shown in the output (typically https://localhost:5001 for backend, http://localhost:5002 for frontend).

## SonarQube

This solution contains minor code issues (unused variables, poor naming, redundant code) that will be picked up by SonarQube analysis.
