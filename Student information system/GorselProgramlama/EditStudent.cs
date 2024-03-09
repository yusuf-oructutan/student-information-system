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
    public partial class EditStudent : Form
    {
        private int selectedStudentId; 

        public EditStudent()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EditStudent_Load(object sender, EventArgs e)
        {

        }
        public void FillStudentInfo(int studentId, string studentName, string studentSurname, string studentNo)
        {
            // Öğrenci bilgilerini CheckBox'lara doldurun
            selectedStudentId = studentId;
            textBox1.Text = studentName;
            textBox2.Text = studentSurname;
            textBox3.Text = studentNo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Yeni bilgileri al
            string newStudentName = textBox1.Text;
            string newStudentSurname = textBox2.Text;
            string newStudentNo = textBox3.Text;

          

            // Veritabanında öğrenci bilgilerini güncelle
            UpdateStudentInfo(selectedStudentId,newStudentName, newStudentSurname, newStudentNo);

           

            // Kullanıcıya güncelleme tamamlandı mesajını göster
            MessageBox.Show("Öğrenci bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);




        }
        private void UpdateStudentInfo(int studentId, string studentName, string studentSurname, string studentNo)
        {
            using (MySqlConnection connection = DatabaseConnection.BaglantiyiAl())
            {
                connection.Open();
                string query = "UPDATE student SET StudentName = @StudentName, StudentSurname = @StudentSurname, StudentNo = @StudentNo WHERE StudentId = @StudentId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId); // Burası eklenmiş oldu
                    command.Parameters.AddWithValue("@StudentName", studentName);
                    command.Parameters.AddWithValue("@StudentSurname", studentSurname);
                    command.Parameters.AddWithValue("@StudentNo", studentNo);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Öğrenci bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }

}
