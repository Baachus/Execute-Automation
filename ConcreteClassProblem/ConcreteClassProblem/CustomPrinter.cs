using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteClassProblem
{
    public class CustomPrinter : ICustomPrinter
    {
        public void PrintCustomMessage(string message)
        {
            Console.WriteLine($"Custom message Prefix {message}");
        }
    }
}
