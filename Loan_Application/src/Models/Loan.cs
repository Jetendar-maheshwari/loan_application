using System;
namespace Loan_Application.src.Models
{
    public class Loan
    {
        public required string Name { get; set; }
        public decimal Amount { get; set; }
        public required string Location { get; set; }

    }
}
