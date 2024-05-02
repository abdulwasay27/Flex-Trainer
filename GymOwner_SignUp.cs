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
    public partial class GymOwner_SignUp : Form
    {
        public GymOwner_SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            GymOwner_Login gymOwner_Login = new GymOwner_Login();
            gymOwner_Login.Show();
        }

        private void GymOwner_SignUp_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            GymOwner_Login gymOwner_Login = new GymOwner_Login();
            gymOwner_Login.Show();
        }
    }
}
