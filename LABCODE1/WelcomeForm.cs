﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABCODE1
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            timer1.Start();
        }
        int startPoint = 0;
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            startPoint += 2;
            progressBar1.Value = startPoint;
            if (progressBar1.Value >= progressBar1.Maximum ) 
            {
                progressBar1.Value = 0;
                timer1.Stop();
                LoginForm login = new LoginForm();
                this.Hide();
                login.ShowDialog();
            }
        }
    }
}
