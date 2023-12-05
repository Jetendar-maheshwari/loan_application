using System;

namespace Loan_Application.src.Utils
{
    public interface IPathWrapper
    {
        string Combine(string path1, string path2);
    }

    public class PathWrapper : IPathWrapper
    {
        public string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }
    }
}

