using Loan_Application.src.Models;
using Loan_Application.scr.RepositoryInterface;

namespace Loan_Application.scr.Servies
{
    public class LoansService : ILoanRepository
    {
        private readonly ILoanRepository _Interfacerepository;

        public LoansService(ILoanRepository interfaceRepository)
        {
            _Interfacerepository = interfaceRepository;
        }

        public List<Loan> GetLoans()
        {
            return _Interfacerepository.GetLoans();
        }

        public void AddLoan(Loan loan)
        {
            _Interfacerepository.AddLoan(loan);
        }
    }
}

