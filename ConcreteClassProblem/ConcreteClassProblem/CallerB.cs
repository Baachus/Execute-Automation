using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteClassProblem
{
    public class CallerB : ICustomPrinter
    {
        public void PrintCustomMessage(string message)
        {
            Console.WriteLine($"My own custom message: {message}");
        }
    }
}
