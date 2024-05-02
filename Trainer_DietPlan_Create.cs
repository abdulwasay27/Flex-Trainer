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
    public partial class Trainer_DietPlan_Create : Form
    {
        public Trainer_DietPlan_Create()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Trainer_Dashboard trainer_Dashboard = new Trainer_Dashboard();
            trainer_Dashboard.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
