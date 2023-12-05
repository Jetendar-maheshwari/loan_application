namespace tests;

using Loan_Application.src.Models;
using Loan_Application.src.Repository;
using Loan_Application.src.Utils;
using Moq;
using NUnit.Framework;

public class RepositoryTest
{
    private string dummyPath = "dummyFile";

    [Test]
    public void GetLoans_WhenFileExists_ReturnListOfLoans()
    {
        var pathWrapperMock = new Mock<IPathWrapper>();
        var repository = new LoansRepository(pathWrapperMock.Object);

        var loansData = new List<string> { "Jetendar,10,Chemnitz", "Sadiq,25,Berlin" };

        pathWrapperMock.Setup(p => p.Combine(It.IsAny<string>(), "loans.txt")).Returns(dummyPath);
        File.WriteAllLines(dummyPath, loansData);

        var result = repository.GetLoans();

        CollectionAssert
            .AreEqual(loansData, result.Select(loan => $"{loan.Name},{loan.Amount},{loan.Location}").ToList());

        TestCleanup();
    }

    [Test]
    public void GetLoans_WhenFileDoesNotExist_ReturnEmptyList()
    {
        var pathWrapperMock = new Mock<IPathWrapper>();
        var repository = new LoansRepository(pathWrapperMock.Object);

        pathWrapperMock.Setup(p => p.Combine(It.IsAny<string>(), "loans.txt")).Returns(dummyPath);
        File.Delete(dummyPath);

        var result = repository.GetLoans();
        Assert.AreEqual(0, result.Count);
        TestCleanup();
    }

    [Test]
    public void AddLoan_AppendLoanDetailsToFile()
    {
        var pathWrapperMock = new Mock<IPathWrapper>();
        var repository = new LoansRepository(pathWrapperMock.Object);

        var loan = new Loan { Name = "Jetendar", Amount = 10, Location = "Chemnitz" };
        pathWrapperMock.Setup(p => p.Combine(It.IsAny<string>(), "loans.txt")).Returns(dummyPath);

        repository.AddLoan(loan);

        var lines = File.ReadAllLines(dummyPath);
        Assert.AreEqual(1, lines.Length);
        Assert.AreEqual($"{loan.Name},{loan.Amount},{loan.Location}", lines[0]);

        TestCleanup();
    }

  
    private void TestCleanup()
    {
        if (File.Exists(dummyPath)){
            File.Delete(dummyPath);
        }
    }

}
