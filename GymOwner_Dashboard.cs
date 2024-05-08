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
    public partial class GymOwner_Dashboard : Form
    {
        string current_email;

        public GymOwner_Dashboard(string current_email="")
        {
            InitializeComponent();
            this.current_email = current_email;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select * from Member_Verification;", conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView1.DataSource = dt;
            dt.Dispose();

            conn = new SqlConnection(ConnectionString.ServerName);
            sqlDA = new SqlDataAdapter("Select * from Trainer_Verification;", conn);
            dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView2.DataSource = dt;

            dt.Dispose();
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
            GymOwner_Approval gymOwner_Approval = new GymOwner_Approval(current_email);
            gymOwner_Approval.Show();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            string query = "Delete from Member_Verification;";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "Update Member set addedBy = @ownerEmail, isApproved = 1 where isApproved is NULL;";
            cmd.Parameters.Add("@ownerEmail", SqlDbType.VarChar).Value = current_email;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            MessageBox.Show("All Members Verified Successfully!");

            conn = new SqlConnection(ConnectionString.ServerName);
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select * from Member_Verification;", conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView1.DataSource = dt;
            dt.Dispose();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            int member_ver_id = Int32.Parse(kryptonNumericUpDown1.Text);
            if (member_ver_id > 0)
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                string query = "Select count(*) FROM Member_Verification where VerificationID = @verID;";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@verID", SqlDbType.Int).Value = member_ver_id;
                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    query = "Select memberEmail FROM Member_Verification where VerificationID = @verID;";
                    cmd.CommandText = query;
                    string returned_string = cmd.ExecuteScalar().ToString();

                    query = "Update Member set addedBy = @ownerEmail, isApproved = 1 where memberEmail = @memberEmail;";
                    cmd.CommandText = query;
                    cmd.Parameters.Add("@ownerEmail", SqlDbType.VarChar).Value = current_email;
                    cmd.Parameters.Add("@memberEmail", SqlDbType.VarChar).Value = returned_string;
                    cmd.ExecuteNonQuery();

                    query = "Delete from Member_Verification where VerificationID = @verID";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Verification ID " + member_ver_id + " Verified Successfully!");

                    conn = new SqlConnection(ConnectionString.ServerName);
                    SqlDataAdapter sqlDA = new SqlDataAdapter("Select * from Member_Verification;", conn);
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView1.DataSource = dt;
                    dt.Dispose();
                }
                else
                {
                    MessageBox.Show("Invalid Member Verification ID!");
                }
            }
            else
            {
                MessageBox.Show("Member Verification ID must be entered!");
            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            int trainer_ver_id = Int32.Parse(kryptonNumericUpDown1.Text);
            if (trainer_ver_id > 0)
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                SqlCommand cmd;
                string query = "Select count(*) FROM Trainer_Verification where VerificationID = @verID;";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@verID", SqlDbType.Int).Value = trainer_ver_id;
                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    query = "Select trainerEmail FROM Trainer_Verification where VerificationID = @verID;";
                    cmd.CommandText = query;
                    string returned_string = cmd.ExecuteScalar().ToString();

                    query = "Update Trainer set addedBy = @ownerEmail, isVerified = 1 where trainerEmail = @trainerEmail;";
                    cmd.CommandText = query;
                    cmd.Parameters.Add("@ownerEmail", SqlDbType.VarChar).Value = current_email;
                    cmd.Parameters.Add("@trainerEmail", SqlDbType.VarChar).Value = returned_string;
                    cmd.ExecuteNonQuery();

                    query = "Delete from Trainer_Verification where VerificationID = @verID";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Verification ID " + trainer_ver_id + " Verified Successfully!");

                    conn = new SqlConnection(ConnectionString.ServerName);
                    SqlDataAdapter sqlDA = new SqlDataAdapter("Select * from Trainer_Verification;", conn);
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView2.DataSource = dt;
                    dt.Dispose();
                }
                else
                {
                    MessageBox.Show("Invalid Trainer Verification ID!");
                }
            }
            else
            {
                MessageBox.Show("Trainer Verification ID must be entered!");
            }
        }

        private void kryptonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            string query = "Delete from Trainer_Verification;";
            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "Update Trainer set addedBy = @ownerEmail, isVerified = 1 where isVerified is NULL;";
            cmd.Parameters.Add("@ownerEmail", SqlDbType.VarChar).Value = current_email;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            MessageBox.Show("All Trainers Verified Successfully!");

            conn = new SqlConnection(ConnectionString.ServerName);
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select * from Trainer_Verification;", conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView2.DataSource = dt;
            dt.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
