using Menu_Repository_ConcoleUI.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Repository_ConcoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RealConsole console = new RealConsole();
            ProgramUI ui = new ProgramUI(console);
            ui.Run();
        }
    }
}
