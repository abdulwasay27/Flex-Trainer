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
    public partial class Member_Dashboard : Form
    {
        string owner_email;
        public Member_Dashboard(string email = "")
        {
            InitializeComponent();
            owner_email = email;
            kryptonTextBox1.Visible = false;
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
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I1CSL1J\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select Gym.gymName, Gym.gymOwner, Gym.adminEmail, Gym.location, Gym.membership_fees from Member join Gym on Member.gymName = Gym.gymName;", conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            dataGridView1.DataSource = dt;

            kryptonTextBox1.Visible = true;
            label1.Text = "Enter GymName: ";
            label1.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
            this.Hide();
            Member_WorkoutPlan_Create member_WorkoutPlan_Create = new Member_WorkoutPlan_Create(memberEmail);
            member_WorkoutPlan_Create.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kryptonTextBox1.Visible = false;
            label1.Visible = false;
            this.Hide();
            Member_DietPlan_Create member_DietPlan_ = new Member_DietPlan_Create(memberEmail);
            member_DietPlan_.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I1CSL1J\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select Trainer.trainerEmail, Trainer.name, Trainer.speciality, Trainer.experience from Trainer join GymTrainers on Trainer.trainerEmail = GymTrainers.trainerEmail join Gym on Gym.gymName = GymTrainers.gymName where trainer.isVerified = 1;", conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            dataGridView1.DataSource = dt;

            kryptonTextBox1.Visible = true;
            label1.Text = "Enter Trainer Email: ";
            label1.Visible = true;
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
