using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project_GymTrainer
{
    public partial class Trainer_Dashboard : Form
    {
        string trainerEmail;
        string currently_selected_button;
        public Trainer_Dashboard(string email="")
        {
            InitializeComponent();
            this.trainerEmail = email;
            this.currently_selected_button = "";

            currently_selected_button = "gym";
            dataGridView1.Visible = false;
            kryptonButton8.Visible = false; // SELECT
            kryptonButton10.Visible = false; // CHANGE
            kryptonButton9.Visible = false; // CREATE
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
        }

        private void Trainer_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currently_selected_button = "gym";
            dataGridView1.Visible = false;
            kryptonButton8.Visible = false; // SELECT
            kryptonButton10.Visible = false; // CHANGE
            kryptonButton9.Visible = false; // CREATE
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
            Trainer_Gym trainer = new Trainer_Gym(trainerEmail);
            trainer.Show();
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
            Trainer_WorkoutPlan_Create trainer_WorkoutPlan_Create = new Trainer_WorkoutPlan_Create(trainerEmail);
            trainer_WorkoutPlan_Create.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Trainer_DietPlan_Create training_WorkoutPlan_ = new Trainer_DietPlan_Create(trainerEmail);
            training_WorkoutPlan_.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {

        }
    }
}
