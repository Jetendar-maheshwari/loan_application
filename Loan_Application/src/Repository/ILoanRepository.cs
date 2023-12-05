using Loan_Application.src.Models;

namespace Loan_Application.scr.RepositoryInterface
{
    public interface ILoanRepository
    {
        void AddLoan(Loan loan);
        List<Loan> GetLoans();
    }
}

