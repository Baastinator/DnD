using System;
using System.Windows.Forms;
using DND.Shared.Entities;

namespace DnD.Char_Gen
{
    static class Program
    {
        public static Character Character;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Character = new Character();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
