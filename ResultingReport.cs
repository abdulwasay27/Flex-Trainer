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
    public partial class ResultingReport : Form
    {
        string s1, s2, s3;
        public ResultingReport(string s1 = "", string s2 = "", string s3 = "", string p = "")
        {
            InitializeComponent();
            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;

            if (p == "1")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select * from Member where gymName = @gym AND trainerEmail = @trainer";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.Add("@gym", SqlDbType.VarChar).Value = s1;
                    command.Parameters.Add("@trainer", SqlDbType.VarChar).Value = s2;

                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
            else if (p == "2")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select * from Member where gymName = @gym AND dietplanID = @dietID;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.Add("@gym", SqlDbType.VarChar).Value = s1;
                    command.Parameters.Add("@dietid", SqlDbType.Int).Value = s2;

                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
            else if (p == "3")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select * from Member where trainerEmail = @trainer AND dietplanID = @dietID;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.Add("@trainer", SqlDbType.VarChar).Value = s1;
                    command.Parameters.Add("@dietid", SqlDbType.Int).Value = s2;

                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
            else if (p == "4")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select count(*) as Count_of_Members from Member " +
                               "join Gym_Machines on Member.gymName = Gym_Machines.gymName " +
                               "join Workout_Exercises on Gym_Machines.exerciseName = Workout_Exercises.exerciseName " +
                               "where Gym_Machines.gymName = @gym AND Gym_Machines.machineName = @machine AND Workout_Exercises.day = @day ";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.Add("@gym", SqlDbType.VarChar).Value = s1;
                    command.Parameters.Add("@machine", SqlDbType.VarChar).Value = s2;
                    command.Parameters.Add("@day", SqlDbType.Int).Value = s3;

                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
            else if (p == "5")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select DietPlan.dietPlanID, DietPlan.purpose, DietPlan.typeOfDiet, Meal.calories from DietPlan " +
                               "join Diet_Meal on DietPlan.dietPlanID = Diet_Meal.dietPlanID " +
                               "join Meal on Diet_Meal.mealName = Meal.mealName " +
                               "where Meal.calories < 500 ;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
            else if (p == "6")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select DietPlan.dietPlanID, DietPlan.purpose, DietPlan.typeOfDiet from DietPlan " +
                               "join Diet_Meal on DietPlan.dietPlanID = Diet_Meal.dietPlanID " +
                               "join Meal on Diet_Meal.mealName = Meal.mealName " +
                               "where Meal.carbs < 300 ;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
            else if (p == "7")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select WorkoutPlan.WorkoutPlanID from WorkoutPlan " +
                               "join Workout_Exercises on WorkoutPlan.WorkoutPlanID = Workout_Exercises.WorkoutPlanID " +
                               "join Gym_Machines on Workout_Exercises.exerciseName = Gym_Machines.exerciseName " +
                               "where Gym_Machines.machineName is NULL";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
            else if (p == "8")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select DietPlan.dietPlanID, DietPlan.purpose, DietPlan.typeOfDiet from DietPlan " +
                               "join Diet_Meal on DietPlan.dietPlanID = Diet_Meal.dietPlanID " +
                               "join Meal on Diet_Meal.mealName = Meal.mealName " +
                               "where Meal.allergen != 'peanuts' ;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
            else if (p == "9")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "Select * from Member " +
                               "join Gym on Member.gymName = Gym.gymName " +
                               "where Gym.gymOwner = @owner AND Member.signup_date < DATEADD(MONTH, -3, GETDATE())";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.Add("@owner", SqlDbType.VarChar).Value = s1;
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
            else if (p == "10")
            {
                SqlConnection conn = new SqlConnection(ConnectionString.ServerName);
                conn.Open();
                string query = "SELECT Gym.gymName, COUNT(Member.memberEmail) AS TotalMembers " +
                               "FROM Gym LEFT JOIN Member ON Gym.gymName = Member.gymName " +
                               "WHERE Member.signup_date >= DATEADD(MONTH, -6, GETDATE()) " +
                               "GROUP BY Gym.gymName;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        kryptonDataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void ResultingReport_Load(object sender, EventArgs e)
        {

        }
    }
}
