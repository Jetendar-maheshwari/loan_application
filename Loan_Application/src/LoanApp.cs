using Loan_Application.scr.RepositoryInterface;
using Loan_Application.scr.Servies;
using Loan_Application.src.Models;
using Loan_Application.src.Repository;
using Loan_Application.src.Utils;

namespace Loan_Application.src
{
    class LoanApp
    {
        static void Main()
        {
            var repository = new LoansRepository(new PathWrapper());
            var service = new LoansService(repository);

            while (true)
            {
                Console.WriteLine("Welcome to the Loan Management System");
                Console.WriteLine("1. Add Loan");
                Console.WriteLine("2. List All Loans");
                Console.WriteLine("3. Exit Application");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddLoan(service);
                        break;
                    case "2":
                        ListLoans(service);
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddLoan(ILoanRepository service)
        {
            string name = GetValidInput("Enter the name:");

            decimal amount = GetValidDecimalInput("Enter amount of money:");

            string location = GetValidInput("Enter location or Occasion:");

            var loan = new Loan {
                Name = name,
                Amount = amount,
                Location = location
            };

            service.AddLoan(loan);
            Console.WriteLine("Loan added successfully.");
        }

        static void ListLoans(ILoanRepository service)
        {
            var loans = service.GetLoans();

            if (loans.Count == 0)
            {
                Console.WriteLine("No loans found.");
            }
            else
            {
                Console.WriteLine("All Loans:");
                foreach (var loan in loans)
                {
                    Console.WriteLine($"Name: {loan.Name}; Amount: €{loan.Amount}; Location: {loan.Location}");
                }
            }
        }

        static string GetValidInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input, Please " + prompt);
                input = Console.ReadLine().Trim();
            }

            return input;
        }

        static decimal GetValidDecimalInput(string prompt)
        {
            decimal amount;

            do
            {
                Console.WriteLine(prompt);

                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Invalid input. Please enter a valid decimal value for the amount:");
                }

                if (amount <= 0)
                {
                    Console.WriteLine("Amount must be greater than zero. Please enter a valid amount:");
                }

            } while (amount <= 0);

            return amount;
        }
    }
}


