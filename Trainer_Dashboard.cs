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
    public partial class Trainer_Dashboard : Form
    {
        public Trainer_Dashboard()
        {
            InitializeComponent();
        }

        private void Trainer_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Trainer_WorkoutPlan_Create trainer_WorkoutPlan_Create = new Trainer_WorkoutPlan_Create();
            trainer_WorkoutPlan_Create.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Trainer_WorkoutPlan_Create training_WorkoutPlan_ = new Trainer_WorkoutPlan_Create();
            training_WorkoutPlan_.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
