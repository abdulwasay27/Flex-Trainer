using System;
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
    public partial class Member_DietPlan_Create : Form
    {
        string memberEmail;
        public Member_DietPlan_Create(string memberEmail)
        {
            InitializeComponent();
            this.memberEmail = memberEmail;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Dashboard member_Dashboard = new Member_Dashboard();
            member_Dashboard.Show();
        }

        private void Member_DietPlan_Create_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
