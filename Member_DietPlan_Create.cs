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
        public Member_DietPlan_Create()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Dashboard member_Dashboard = new Member_Dashboard();
            member_Dashboard.Show();
        }
    }
}
