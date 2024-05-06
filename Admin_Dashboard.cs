using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project_GymTrainer
{
    public partial class Admin_Dashboard : Form
    {
        string current_email;
        public Admin_Dashboard(string current_email = "")
        {
            InitializeComponent();
            this.current_email = current_email;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I1CSL1J\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
            SqlDataAdapter sqlDA = new SqlDataAdapter("Select * FROM Approval inner join gym on Approval.gymName = gym.gymName where gym.isApproved = 0 ;",conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView1.DataSource = dt;

        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I1CSL1J\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd;
            string delete_approval_record = "DELETE FROM Approval;";
            string update_gym_record = "Update Gym SET isApproved = 1, adminEmail = @adminEmail where isApproved = 0;";
            cmd = new SqlCommand(delete_approval_record, conn);
            cmd.Parameters.Add("@adminEmail", SqlDbType.VarChar).Value = current_email;
            cmd.ExecuteNonQuery();
            cmd.CommandText = update_gym_record;
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            SqlDataAdapter sqlDA = new SqlDataAdapter("Select * FROM Approval inner join gym on Approval.gymName = gym.gymName where gym.isApproved = 0 ;", conn);
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            kryptonDataGridView1.DataSource = dt;

            conn.Close();

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            int approval_id = Int32.Parse(kryptonNumericUpDown1.Text);
            if ( approval_id > 0)
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I1CSL1J\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
                conn.Open();
                SqlCommand cmd;

                string delete_approval_record = "Delete FROM Approval where approvalId = @approvalId;";
                string get_gymName = "SELECT gymName FROM Approval where approvalId = @approvalId;";
                string update_gym_record = "Update Gym SET isApproved = 1 where gymName = @gymName;";
                string update_gym_record1 = "Update Gym SET adminEmail = @adminEmail  where gymName = @gymName;";
                string gymName = "";

                cmd = new SqlCommand(get_gymName, conn);
                cmd.Parameters.Add("@approvalId", SqlDbType.Int).Value = approval_id;
                cmd.Parameters.Add("@adminEmail",SqlDbType.VarChar).Value = current_email;
                if (cmd.ExecuteScalar() != null)
                {
                    gymName = cmd.ExecuteScalar().ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Approval Id!");
                    return;
                }
                cmd.Parameters.Add("@gymName", SqlDbType.VarChar).Value = gymName;

                cmd.CommandText = delete_approval_record;
                cmd.ExecuteNonQuery();
                cmd.CommandText = update_gym_record;
                cmd.ExecuteNonQuery();
                cmd.CommandText = update_gym_record1;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                SqlDataAdapter sqlDA = new SqlDataAdapter("Select * FROM Approval inner join gym on Approval.gymName = gym.gymName where gym.isApproved = 0 ;", conn);
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                kryptonDataGridView1.DataSource = dt;

                conn.Close();

            }

            else
            {
                MessageBox.Show("Approval ID must be entered!");
                

            }


        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
