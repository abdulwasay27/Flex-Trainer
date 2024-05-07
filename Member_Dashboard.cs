using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Database_Project_GymTrainer
{
    public partial class Member_Dashboard : Form
    {
        string owner_email, member_email;
        string currently_selected_button;
        string current_gym;
        public Member_Dashboard(string email = "", string email2 = "", string current_gym = "")
        {
            InitializeComponent();
            currently_selected_button = "";
            this.current_gym = current_gym;
            owner_email = email;
            member_email = email2;

            dataGridView1.Visible = false;
            kryptonTextBox1.Visible = false;
            kryptonButton7.Visible = false;
            kryptonButton6.Visible = false;
            kryptonButton8.Visible = false;
            label1.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Member_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true ;
            currently_selected_button = "gym";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select Gym.gymName, Gym.gymOwner, Gym.adminEmail, Gym.location, Gym.membership_fees from Member join Gym on Member.gymName = Gym.gymName;", conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            dataGridView1.DataSource = dt;

            kryptonButton8.Visible = false;
            kryptonButton7.Visible = true;
            kryptonButton6.Visible = false;
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "workout";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT WorkoutPlan.workoutPlanID, WorkoutPlan.goal, WorkoutPlan.schedule, WorkoutPlan.experienceLevel " +
                "FROM WorkoutPlan JOIN Member ON WorkoutPlan.workoutPlanID = Member.currentlyFollowingWorkoutPlanID;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@memberemail", member_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible=false; // SELECT
            kryptonButton6.Visible = true; // CREATE
            kryptonButton7.Visible = true; // CHANGE
            kryptonTextBox1.Visible = false; // INPUT BOX     
            label1.Visible = false; // LABEL "ENTER"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "diet";
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "SELECT dietPlan.dietPlanID, dietPlan.purpose, dietPlan.typeOfDiet " +
                "FROM dietPlan JOIN Member ON dietPlan.dietPlanID = Member.dietPlanID ";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@memberemail", member_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            kryptonButton8.Visible = false; // SELECT
            kryptonButton6.Visible = true; // CREATE
            kryptonButton7.Visible = true; // CHANGE
            kryptonTextBox1.Visible = false; // INPUT BOX     
            label1.Visible = false; // LABEL "ENTER"
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            currently_selected_button = "trainer";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select Trainer.trainerEmail, Trainer.name, Trainer.speciality, Trainer.experience from Trainer join Member on Trainer.trainerEmail = Member.trainerEmail;", conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            dataGridView1.DataSource = dt;          
            kryptonButton7.Visible = true;
            kryptonButton7.Text = "Change";
            kryptonButton6.Visible = false;
            kryptonButton8.Visible = false;
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {      
            kryptonButton8.Visible = true; // SELECT
            kryptonButton6.Visible = false; // CREATE
            kryptonButton7.Visible = false; // CHANGE
            kryptonTextBox1.Visible = true; // INPUT BOX     
            label1.Visible = true; // LABEL "ENTER"
            kryptonButton8.Location = kryptonButton7.Location;
            if (currently_selected_button == "gym")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select Gym.gymName, Gym.gymOwner, Gym.adminEmail, Gym.location, Gym.membership_fees from Gym";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@currentgym", current_gym);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter Gym Name: ";
            }
            else if (currently_selected_button == "trainer")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT Trainer.trainerEmail, Trainer.name, Trainer.speciality, Trainer.experience FROM Trainer " +
                       "JOIN GymTrainers ON GymTrainers.trainerEmail = Trainer.trainerEmail " +
                       "WHERE GymTrainers.gymName = @currentgym;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@currentgym", current_gym);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter Trainer Email: ";
                label1.Visible = true;
                kryptonButton7.Visible = false;
                kryptonButton8.Location = kryptonButton7.Location;
                kryptonButton8.Visible = true;
            }
            else if (currently_selected_button == "workout")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT workoutPlanID, trainerEmail, memberEmail, goal, schedule, experienceLevel FROM WorkoutPlan;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter WorkoutPlan ID: ";
                label1.Visible = true;
                kryptonButton7.Visible = false;
                kryptonButton8.Location = kryptonButton7.Location;
                kryptonButton8.Visible = true;
            }
            else if (currently_selected_button == "diet")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT dietplanID, trainerEmail, memberEmail, purpose, typeOfDiet FROM DietPlan;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                label1.Text = "Enter DietPlan ID: ";
                label1.Visible = true;
                kryptonButton7.Visible = false;
                kryptonButton8.Location = kryptonButton7.Location;
                kryptonButton8.Visible = true;
            }

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton8_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            if ( currently_selected_button == "workout")
            {
                this.Close();
                Member_WorkoutPlan_Create member = new Member_WorkoutPlan_Create(member_email, owner_email, current_gym);
                member.Show();
            }
            else if ( currently_selected_button == "diet")
            {
                this.Close();
                Member_DietPlan_Create member = new Member_DietPlan_Create(member_email, owner_email, current_gym);
                member.Show();
            }
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            if (currently_selected_button == "gym")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select Gym.gymName, Gym.gymOwner, Gym.adminEmail, Gym.location, Gym.membership_fees from Gym";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@currentgym", current_gym);
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                string gymname = kryptonTextBox1.Text;
                if (string.IsNullOrEmpty(gymname))
                {
                    MessageBox.Show("Please enter all compulsory fields!");
                }
                else
                {
                    conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    SqlCommand cmd;
                    query = "";
                    query = "select count(*) from Gym where gymName=@gymName";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = gymname;
                    int count = (int)cmd.ExecuteScalar();

                    if (count != 0)
                    {
                        query = "";
                        query = "select gymOwner from Gym where gymName = @gymName";
                        owner_email = cmd.ExecuteScalar().ToString();

                        query = "";
                        query = "update Member set gymName = @gymName where memberEmail = @memberEmail";
                        cmd.CommandText = query;
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Gym Changed Successfully. Now in order to select the trainer, goto Trainer Tab!");
                        kryptonTextBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Invalid Gym Name!");
                    }
                }
            }
            else if (currently_selected_button == "trainer")
            {
                string traineremail = kryptonTextBox1.Text;
                if (string.IsNullOrEmpty(traineremail))
                {
                    MessageBox.Show("Please enter all compulsory fields!");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    SqlCommand cmd;
                    string query = "select count(*) from Trainer where trainerEmail=@trainerEmail";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = traineremail;
                    int count = (int)cmd.ExecuteScalar();

                    if (count != 0)
                    {
                        query = "";
                        query = "select gymOwner from Gym where gymName = @gymName";
                        owner_email = cmd.ExecuteScalar().ToString();

                        query = "";
                        query = "update Member set gymName = @gymName where memberEmail = @memberEmail";
                        cmd.CommandText = query;
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Gym Changed Successfully. Now in order to select the trainer, goto Trainer Tab!");
                        kryptonTextBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Invalid Trainer Email!");
                    }
                }
            }
            else if (currently_selected_button == "workout")
            {
                string workoutid = kryptonTextBox1.Text;
                if (string.IsNullOrEmpty(workoutid))
                {
                    MessageBox.Show("Please enter all compulsory fields!");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    SqlCommand cmd;
                    string query = "select count(*) from WorkoutPlan where workoutPlanID = @workoutid";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@workoutid", SqlDbType.VarChar).Value = workoutid;
                    int count = (int)cmd.ExecuteScalar();

                    if (count != 0)
                    {
                        query = "";
                        query = "update Member set currentlyFollowingWorkoutPlanID = @workoutid where memberEmail = @memberEmail";
                        cmd.CommandText = query;  
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Workoutplan Changed Successfully!");
                        kryptonTextBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Invalid Workout ID!");
                    }
                }
            }
            else if (currently_selected_button == "diet")
            {
                string dietplanid = kryptonTextBox1.Text;
                if (string.IsNullOrEmpty(dietplanid))
                {
                    MessageBox.Show("Please enter all compulsory fields!");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                    conn.Open();
                    SqlCommand cmd;
                    string query = "select count(*) from DietPlan where dietPlanID = @dietplanid";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@dietplanid", SqlDbType.VarChar).Value = dietplanid;
                    int count = (int)cmd.ExecuteScalar();

                    if (count != 0)
                    {
                        query = "";
                        query = "update Member set dietPlanID = @dietplanid where memberEmail = @memberEmail";
                        cmd.CommandText = query;
                        cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = member_email;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Dietplan Changed Successfully!");
                        kryptonTextBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Invalid Diet Plan ID!");
                    }
                }
            }
        }
    }
}
