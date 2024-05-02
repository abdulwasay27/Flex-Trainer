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
    public partial class GymOwner_Dashboard : Form
    {
        public GymOwner_Dashboard()
        {
            InitializeComponent();
        }

        private void GymOwner_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            Close();
            GymOwner_AddMachine gymOwner_AddMachine = new GymOwner_AddMachine();
            gymOwner_AddMachine.Show();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            Close();
            GymOwner_Approval gymOwner_Approval = new GymOwner_Approval();
            gymOwner_Approval.Show();
        }
    }
}
