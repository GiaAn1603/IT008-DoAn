using System;
using System.Windows.Forms;

namespace OHIOCF
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Database.Init();
            DataSeeder.Seed();
            Application.Run(new Form1());
        }
    }
}
