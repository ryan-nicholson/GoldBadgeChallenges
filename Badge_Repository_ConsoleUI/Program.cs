using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository_ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI program = new ProgramUI(); // method to start ProgramUI
            program.Run(); //calling Run in ProgramUI
        }
    }
}
