# Project Overview

* Project Name: MinimalAPI
* Description: A demonstration of implementing a Minimal API using ASP.NET Core.
* Purpose: To showcase the implementation of a lightweight, efficient API with minimal configuration.

## Prerequisites:

* .NET SDK 9.0 or later
* IDE of choice (e.g., Visual Studio, Visual Studio Code)
* Git

### Installation Steps:
1. Clone the repository using the following command:
``` 
git clone https://github.com/Dotnetstore/MinimalAPI.git
cd MinimalAPI
```
2. Restore Dependencies:
```
dotnet restore
```
3. Build the Application:
```
dotnet build
```
4. Run the Application:
```
dotnet run --project .\src\Dotnetstore.MinimalAPI\Dotnetstore.MinimalAPI.csproj
```

## Project Structure
* **Dotnetstore.MinimalAPI** - The main project that contains the API implementation.
* **Dotnetstore.MinimalAPI.Tests** - The project that contains the unit tests for the API.
* **Dotnetstore.MinimalAPI.sln** - The solution file for the project.
* **README.md** - The project overview file.
* **LICENSE** - The license file for the project.
* **.gitignore** - The file that specifies which files and directories to ignore in the repository.

## API Endpoints
* **GET /employees** - Get all employees.
* **GET /employees/{id}** - Get an employee by ID.
* **POST /employees** - Create a new employee.
* **PUT /employees** - Update an employee.
* **DELETE /employees/{id}** - Delete an employee by ID.

## Technologies Used
* ASP.NET Core
* C#
* .NET SDK 9.0
* Git
* Rider

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author
* [Hans Sjödin](Hans Sjödin)