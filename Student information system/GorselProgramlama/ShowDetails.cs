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
    public partial class ShowDetails : Form
    {
        private readonly string studentId;
        private readonly string studentName;
        private readonly string studentSurname;
        private readonly string studentNo;

        public ShowDetails(string studentId, string studentName, string studentSurname, string studentNo)
        {
            InitializeComponent();

            this.studentId = studentId;
            this.studentName = studentName;
            this.studentSurname = studentSurname;
            this.studentNo = studentNo;

            FillStudentInfo();
            FillStudentGrades();


        }
        private void FillStudentInfo()
        {
            textBox1.Text = studentName;
            textBox2.Text = studentSurname;
            textBox3.Text = studentNo;
        }


        private void ShowDetails_Load(object sender, EventArgs e)
        {
            
        }
        private void FillStudentGrades()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.BaglantiyiAl())
                {
                    connection.Open();

                    string query = "SELECT YapayZeka, GörselProgramlama FROM grades WHERE StudentID = @StudentID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                if (!reader.IsDBNull(reader.GetOrdinal("YapayZeka")))
                                {
                                    int yapayZekaNot = reader.GetInt32("YapayZeka");
                                    textBox6.Text = yapayZekaNot.ToString();
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("GörselProgramlama")))
                                {
                                    int gorselProgramlamaNot = reader.GetInt32("GörselProgramlama");
                                    textBox5.Text = gorselProgramlamaNot.ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not bilgileri getirilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








    }
}









