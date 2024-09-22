# Student Information System (CodeAcademy14)

A comprehensive C# console application for managing student, department, and lecture information in an educational institution.

## Project Overview

CodeAcademy14 is a robust Student Information System developed using C# and Entity Framework Core. It provides a console-based interface for managing various aspects of an educational institution, including students, departments, and lectures.

## Features

- **Student Management**: Add, view, and transfer students between departments
- **Department Management**: Create departments and assign lectures
- **Lecture Management**: Create lectures and assign them to departments
- **Data Validation**: Robust input validation for all entities
- **Database Integration**: Utilizes Entity Framework Core for data persistence
- **Initial Data Seeding**: Automatically seeds the database with initial data from CSV files

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB or full instance)

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/nolessas/CodeAcademy14.git
   ```

2. Navigate to the project directory:
   ```
   cd CodeAcademy14
   ```

3. Restore dependencies:
   ```
   dotnet restore
   ```

4. Update the connection string in `StudentInfoContext.cs` if necessary.

5. Run the application:
   ```
   dotnet run
   ```

## Project Structure

### Program.cs
The entry point of the application. It initializes the database, seeds initial data, and starts the main menu.


### Data/
Contains the `StudentInfoContext.cs` file, which defines the database context and entity configurations using Entity Framework Core.


### Menu/
Contains separate menu classes for Students, Departments, and Lectures, providing a user-friendly console interface for interacting with the system.

### Services/
Houses the `StudentService.cs` file, which encapsulates business logic for student-related operations.


### Validator/
Contains validation logic to ensure data integrity and adherence to business rules.

### Helpers/
Includes utility classes and helper methods to support various operations across the application.

### InitialData/
Contains CSV files used for seeding initial data into the database.

## Data Models

- **Student**: Represents a student with properties like name, student number, email, and department code
- **Department**: Represents an academic department with a unique code and name
- **Lecture**: Represents a lecture with properties like name, time, and day
- **DepartmentLecture**: Represents the many-to-many relationship between departments and lectures
- **StudentLecture**: Represents the many-to-many relationship between students and lectures

## Unit Testing

The project includes a comprehensive suite of unit tests to ensure the reliability and correctness of the implemented functionalities. These tests cover:

- Data validation
- Entity creation and management
- Business logic operations
- Edge cases and error handling

The unit tests are located in a separate test project and can be run using the standard .NET testing tools.

## Customization

The project is designed to be easily extensible. New functionalities can be added by creating additional methods in the `Program` class or by introducing new service classes in the `Services` folder.

## Contributing

Contributions, issues, and feature requests are welcome. Feel free to check the [issues page](https://github.com/nolessas/CodeAcademy14/issues) for open problems or to suggest new features.

## License

This project is licensed under the MIT License.

## Acknowledgements

- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [.NET Core](https://dotnet.microsoft.com/)

For more detailed information about specific components or functionalities, please refer to the inline documentation within the source code.
