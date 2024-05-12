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
    public partial class GymOwner_ViewMembersTrainers : Form
    {
        string current_email;
        public GymOwner_ViewMembersTrainers(string current_email = "")
        {
            InitializeComponent();
            this.current_email = current_email;

            SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
            conn.Open();
            string query = "Select * from Member where gymName = (Select gymName from Gym where gymOwner = @owner) AND isApproved = 1;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@owner", current_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView1.DataSource = dt;
                }
            }

            query = "Select Trainer.trainerEmail, Trainer.name, Trainer.password, Trainer.speciality, Trainer.experience, Trainer.qualification, " +
                    "Trainer_Verification.gymName FROM Trainer " +
                    "JOIN Trainer_Verification on Trainer.trainerEmail = Trainer_Verification.trainerEmail " +
                    "where Trainer_Verification.gymName = (Select gymName from Gym where gymOwner = @owner) AND Trainer_Verification.isVerified = 1;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@owner", current_email);
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    kryptonDataGridView2.DataSource = dt;
                }
            }
        }

        private void GymOwner_ViewMembersTrainers_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
