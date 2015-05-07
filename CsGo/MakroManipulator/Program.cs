using Manipulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manipulator.CsGo;

namespace MakroManipulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FormCsGoTool form = new FormCsGoTool();
            Application.Run(form);
        }
    }
}
