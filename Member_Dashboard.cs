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
    public partial class Member_Dashboard : Form
    {
        public Member_Dashboard()
        {
            InitializeComponent();
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

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Member_WorkoutPlan_Create member_WorkoutPlan_Create = new Member_WorkoutPlan_Create();
            member_WorkoutPlan_Create.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_DietPlan_Create member_DietPlan_ = new Member_DietPlan_Create();
            member_DietPlan_.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
