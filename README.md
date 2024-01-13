# Loan Management System

A console application developed in C# using Visual Studio and .NET for efficiently managing colleague loans.

## Features

- Add loans with names, amounts, and locations
- List and overview all entered loans
- The application follows coding standards, incorporates design patterns, and includes comprehensive testing cases.

## Architecture and Design Patterns

The system follows architecture and design patterns, emphasizing:
- Testability
- Extendibility

It includes:

### Service Layer and Repository Interface

For better code organization, the system includes a service layer and repository interface.

### Unit Tests

Robustness is ensured through unit tests, providing a reliable loan management solution.

## File Structure

In the `Loan_Application` file structure:

- Add loans
- List existing loans
- Exit the application

Tests ensure the proper functioning of the repository, covering scenarios where the file exists or does not. These tests include adding or getting data.

### Model (Loan)

Represents loan entities with properties like Name, Amount, and Location.

### Repository Interface (ILoanRepository)

Defines methods to add loans and retrieve a list, establishing a contract.

### Repository (LoansRepository)

Implements `ILoanRepository`, persisting loan data in "loans.txt" using injected `IPathWrapper` for file path management.

### Service (LoansService)

Serves as an intermediary, implementing `ILoanRepository` and delegating calls to `LoansRepository` for application logic.

### Utility (PathWrapper)

Provides a streamlined interface for combining file paths, primarily for repository file handling.

### Testing (RepositoryTest)

NUnit tests for `LoansRepository` functionality:

- Mocks file system operations using `IPathWrapper`
- Asserts expected behavior in adding and retrieving loans

### Application (LoanApp)

The main entry point where the user interacts with the Loan Management System through a console menu:

- Options include adding a loan, listing all loans, and exiting the application
- Utilizes the `LoansService` for loan operations and incorporates user input validation.

### Testing (RepositoryTest)

Contains NUnit tests to validate the functionality of the `LoansRepository` class:

- Mocks file system operations using `IPathWrapper`
- Asserts the expected behavior of adding and retrieving loans.

# How to Run the Application

To run the Loan Management System application, follow these steps:

1. Navigate to the project directory containing `LoanApp.cs`.
2. Open a terminal or command prompt in that directory.

### Using Visual Studio:

3. If you have Visual Studio installed, you can open the project in Visual Studio and set `LoanApp.cs` as the startup file.
4. Build the project.
5. Run the project, and the console application will start.

### Using .NET CLI:

3. If you prefer using the .NET CLI, you can use the following commands:

```bash
dotnet build
dotnet run --project LoanApp.csproj

