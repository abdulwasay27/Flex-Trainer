using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project_GymTrainer
{
    public partial class Member_SignUp : Form
    {
        public Member_SignUp()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Member_Login memberLogin = new Member_Login();
            this.Hide();
            memberLogin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string name = member_signup_name.Text;
            string email = member_signup_email.Text;
            string password = member_signup_pw.Text;
            string gym = member_signup_gym.Text;
            DateTime date = member_signup_date.Value;
            string objective = member_signup_obj.Text;
            string duration = member_signup_duration.Text;
            string type = member_signup_type.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(gym) || string.IsNullOrEmpty(duration) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Please enter all compulsory fields!");
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=Shaif-PC\\SQLEXPRESS;Initial Catalog=FlexTrainer;Integrated Security=True;");
                conn.Open();
                SqlCommand cmd;
                string query = "select count(*) from Member where memberEmail=@email";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@gym", SqlDbType.VarChar).Value = gym;
                cmd.Parameters.Add("@objective", SqlDbType.VarChar).Value = objective;
                cmd.Parameters.Add("@duration", SqlDbType.Int).Value = Int32.Parse(duration);
                cmd.Parameters.Add("@selectedDate", SqlDbType.DateTime).Value = date;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type;

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Email already exists!");
                }
                else
                {
                    query = "";
                    query = "Insert into Member(memberEmail, memberName, password, gymName, objectives, membershipDuration, signup_date) values(@email, @name, @password, @gym, @objective, @duration, @selectedDate)";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();

                    MessageBox.Show("Sign Up Successfull!");

                    this.Close();
                    Member_Dashboard member = new Member_Dashboard();
                    member.Show();
                }

            }
        }
    }
}
