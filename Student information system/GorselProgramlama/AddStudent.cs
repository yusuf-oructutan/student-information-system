using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GorselProgramlama
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
               
                string studentName = textBox4.Text;
                string studentSurname = textBox7.Text;
                string studentNo = textBox6.Text;

               
                using (MySqlConnection connection = DatabaseConnection.BaglantiyiAl())
                {
                    try
                    {
                        
                        connection.Open();

                        
                        string query = "INSERT INTO student (StudentName, StudentSurname, StudentNo) VALUES (@name, @surname, @no)";

                      
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                           
                            command.Parameters.AddWithValue("@name", studentName);
                            command.Parameters.AddWithValue("@surname", studentSurname);
                            command.Parameters.AddWithValue("@no", studentNo);

                            
                            command.ExecuteNonQuery();

                            
                            MessageBox.Show("Öğrenci başarıyla eklendi!");
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();

            
            this.Hide();

            form1.Show();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}