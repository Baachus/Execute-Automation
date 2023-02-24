using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteClassProblem
{
    public class CallerA
    {
        CustomPrinter printer = new CustomPrinter();
        public void PrintMessage()
        {
            printer.PrintCustomMessage("Hello from CallerA");
        }
    }
}
