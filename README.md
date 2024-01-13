# Loan Management System

[![Build Status](https://your-build-status-icon-url)](https://your-build-status-link)

A console application developed in C# using Visual Studio and .NET for efficiently managing colleague loans.

## Features

- Add loans with names, amounts, and locations
- List and overview all entered loans

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

Tests ensure proper functioning of the repository, covering scenarios where the file exists or does not. These tests include add or get data.

## Components

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
