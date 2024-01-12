# loan_application

This console application, developed in C# using Visual Studio and .NET, efficiently manages colleague loans. Users can add loans with names, amounts, and locations, and then list and overview all entered loans.

The system follows architecture and design patterns, emphasizing testability and extendibility. It includes a service layer and repository interface for better code organization. Unit tests are provided for robustness, ensuring a reliable loan management solution.

In the file structure Loan_Application, the user can interact with the system by adding loans, listing existing loans, or exiting the application. tests ensure the proper functioning of the repository, covering scenarios where the file exists or does not, add or get data or not.

Model (Loan): Represents loan entities with properties like Name, Amount, and Location.

Repository Interface (ILoanRepository): Defines methods to add loans and retrieve a list, establishing a contract.

Repository (LoansRepository): Implements ILoanRepository, persisting loan data in "loans.txt" using injected IPathWrapper for file path management.

Service (LoansService): Serves as an intermediary, implementing ILoanRepository and delegating calls to LoansRepository for application logic.

Utility (PathWrapper): Provides a streamlined interface for combining file paths, primarily for repository file handling.

Testing (RepositoryTest):

NUnit tests for LoansRepository functionality.

Mocks file system operations using IPathWrapper.

Asserts expected behavior in adding and retrieving loans.

Application (LoanApp):

The main entry point where the user interacts with the Loan Management System through a console menu.

Options include adding a loan, listing all loans, and exiting the application.

Utilizes the LoansService for loan operations and incorporates user input validation.

Testing (RepositoryTest):

Contains NUnit tests to validate the functionality of the LoansRepository class.

Mocks the file system operations using IPathWrapper and asserts the expected behavior of adding and retrieving loans.
