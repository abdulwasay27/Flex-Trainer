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
    public partial class Member_WorkoutPlan_Create : Form
    {
        public Member_WorkoutPlan_Create()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Dashboard member_Dashboard = new Member_Dashboard();
            member_Dashboard.Show();
        }

        private void Member_WorkoutPlan_Create_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void kryptonComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void kryptonComboBox3_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox3.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=Shaif-PC\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd;
            string display_targetMuscle = "SELECT distinct(targetMuscle) From exercise ;";
            cmd = new SqlCommand(display_targetMuscle, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string targetMuscle = reader.GetString(0);
                kryptonComboBox3.Items.Add(targetMuscle);
            }


            cmd.Dispose();
            conn.Close();
        }

        private void kryptonComboBox2_DropDown(object sender, EventArgs e)
        {
            kryptonComboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=Shaif-PC\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd;
            string display_exerciseNames_specific = "SELECT exerciseName From exercise where targetMuscle = @target_muscle;";
            string display_exerciseNames = "SELECT exerciseName From exercise ;";
            if (kryptonComboBox3.SelectedIndex == -1 || string.IsNullOrEmpty(kryptonComboBox3.Text))
            {
                cmd = new SqlCommand(display_exerciseNames, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string exerciseName = reader.GetString(0);
                        kryptonComboBox2.Items.Add(exerciseName);
                    }
                }
                
            }

            else
            {
                cmd = new SqlCommand(display_exerciseNames_specific, conn);
                string target_muscle = kryptonComboBox3.Text;
                cmd.Parameters.Add("@target_muscle", SqlDbType.VarChar).Value = target_muscle;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string exerciseName = reader.GetString(0);
                        kryptonComboBox2.Items.Add(exerciseName);
                    }
                }
            }

            cmd.Dispose();
            conn.Close();
        }
    }
}
