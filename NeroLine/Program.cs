using System;
using System.Windows.Forms;
using Nero_PR_namespace;
using Nero_BL_namespace;
using Nero_Wiev;

namespace NeroLine
{
    static class Program
    {
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form =  new Form1();
            Nero_BL nero_BL = new Nero_BL();
            Nero_PR nero = new Nero_PR(form,nero_BL);
            Application.Run(form);

        }
    }
}
