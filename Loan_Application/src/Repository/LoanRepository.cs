using Loan_Application.src.Models;
using Loan_Application.scr.RepositoryInterface;
using Loan_Application.src.Utils;

namespace Loan_Application.src.Repository
{
    public class LoansRepository : ILoanRepository
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        private readonly IPathWrapper _pathWrapper;

        public LoansRepository(IPathWrapper pathWrapper) {
            _pathWrapper = pathWrapper;
        }

        public List<Loan> GetLoans()
        {
            string FileName = _pathWrapper.Combine(currentDirectory, "loans.txt");

            if (!File.Exists(FileName))
            {
                return new List<Loan>();
            }

            var loanList = File.ReadAllLines(FileName);

            if (loanList.Length == 0)
            {
                Console.WriteLine("There are no loans available.");
                return new List<Loan>();
            }

            return loanList.Select(entry =>
            {
                var item = entry.Split(',');
                return new Loan
                {
                    Name = item[0],
                    Amount = decimal.Parse(item[1]),
                    Location = item[2]
                };
            }).ToList();
        }

        public void AddLoan(Loan loan)
        {
            string FileName = _pathWrapper.Combine(currentDirectory, "loans.txt");

            var loanDetail = $"{loan.Name},{loan.Amount},{loan.Location}";
            File.AppendAllLines(FileName, new[] { loanDetail });
        }

    }
}


