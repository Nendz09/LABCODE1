﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABCODE1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //run main form
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //AccountForm accountForm = new AccountForm();
            //MainForm mainForm = new MainForm(accountForm);
            //Application.Run(mainForm);




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

    }
}
