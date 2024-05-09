﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project_GymTrainer
{
    public partial class Admin_Reports : Form
    {
        string current_admin;
        public Admin_Reports(string admin = "")
        {
            this.current_admin = admin;
            InitializeComponent();
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i%2 == 0)
                {
                    panel.Visible = false;
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i%2 == 0)
                {
                    panel.Visible = (panel == panel1); 
                    panel.Visible = (panel == panel2); 
                }
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = (panel == panel3);
                    panel.Visible = (panel == panel4);
                }
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Reports_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = (panel == panel5);
                    panel.Visible = (panel == panel6);
                }
            }
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = (panel == panel7);
                    panel.Visible = (panel == panel8);
                }
            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = Controls.Find("panel" + i, true).FirstOrDefault() as Panel;
                if (panel != null && i % 2 == 0)
                {
                    panel.Visible = (panel == panel9);
                    panel.Visible = (panel == panel10);
                }
            }
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            Admin_Reports_2 ad2 = new Admin_Reports_2(current_admin);
            ad2.Show();
            this.Hide();
        }
    }
}
