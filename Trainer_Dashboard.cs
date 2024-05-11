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
        public Trainer_Dashboard(string email = "")
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
            dataGridView1.Visible = true;
            currently_selected_button = "workout";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel " +
                "FROM WorkoutPlan INNER JOIN Trainer ON WorkoutPlan.trainerEmail = trainer.trainerEmail where trainer.trainerEmail = @trainerEmail;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", trainerEmail);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible = false; // SELECT
            kryptonButton9.Visible = true; // CREATE
            kryptonButton10.Visible = false; // CHANGE
            kryptonTextBox1.Visible = false; // INPUT BOX     
            label1.Visible = false; // LABEL "ENTER"
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "diet";
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT dietPlan.dietPlanID, dietPlan.purpose, dietPlan.typeOfDiet " +
                "FROM dietPlan Inner JOIN Trainer ON dietPlan.trainerEmail = trainer.trainerEmail where trainer.trainerEmail = @trainerEmail ";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", trainerEmail);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible = false; // SELECT
            kryptonButton9.Visible = true; // CREATE
            kryptonButton10.Visible = false; // CHANGE
            kryptonTextBox1.Visible = false; // INPUT BOX     
            label1.Visible = false; // LABEL "ENTER"
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Trainer_Appointments trainer = new Trainer_Appointments(trainerEmail);
            trainer.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            if (currently_selected_button == "workout")
            {
                this.Close();
                Trainer_WorkoutPlan_Create trainer = new Trainer_WorkoutPlan_Create(trainerEmail);
                trainer.Show();
            }
            else if (currently_selected_button == "diet")
            {
                this.Close();
                Trainer_DietPlan_Create trainer = new Trainer_DietPlan_Create(trainerEmail);
                trainer.Show();
            }
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "member_feedback";

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "select * from feedback where trainerEmail = @trainerEmail";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@trainerEmail", trainerEmail);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible = false; // SELECT
            kryptonButton9.Visible = false; // CREATE
            kryptonButton10.Visible = false; // CHANGE
            kryptonTextBox1.Visible = false; // INPUT BOX     
            label1.Visible = false; // LABEL "ENTER"
        }
    }
}
