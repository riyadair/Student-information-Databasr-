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

namespace StudentInfoUsingDatabaseApp
{
    public partial class StudentInformationUI : Form
    {
        public StudentInformationUI()
        {
            InitializeComponent();
        }
        Student aStudent = new Student();
        private void button2_Click(object sender, EventArgs e)
        {
            aStudent.name = nameTextBox.Text;
            aStudent.regNo = regNoTextBox.Text;
            aStudent.bloodGroup = bloodGroupTextBox.Text;
            aStudent.address = addressTextBox.Text;

            if (IsRegNoExist(aStudent.regNo))
            {
                MessageBox.Show("Reg No Already exist");
                return;
            }

            //connect to database

            string connectionString = @"SERVER = PC-301-28\SQLEXPRESS; DATABASE = StudentInfoDB; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);

            //write query

            string qurey = "INSERT INTO Student VALUES('"+aStudent.name+"','"+aStudent.bloodGroup+"','"+aStudent.regNo+"','"+aStudent.address+"')";

            //execute query

            SqlCommand command = new SqlCommand(qurey,connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
            {
                MessageBox.Show("Insert Successfully.");
            }
            else
            {
                MessageBox.Show("Insertion Faild!");
            }
        }

        public bool IsRegNoExist(string regNo)
        {
            string connectionString = @"SERVER = PC-301-28\SQLEXPRESS; DATABASE = StudentInfoDB; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);

            //write query

            string qurey = "SELECT * FROM Student WHERE RegNo='"+regNo+ "'";

            //execute query

            SqlCommand command = new SqlCommand(qurey, connection);

            bool isRegNoExist = false;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                isRegNoExist = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isRegNoExist;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
