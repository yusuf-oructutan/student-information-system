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
    public partial class DeleteStudent : Form
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void DeleteStudent_Load(object sender, EventArgs e)
        {

            LoadStudentsToDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçili öğrenciyi silmek istediğinizden emin misiniz?", "Öğrenci Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int selectedStudentId = (int)dataGridView1.SelectedRows[0].Cells["StudentId"].Value;
                    DeleteStudentById(selectedStudentId);
                    LoadStudentsToDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Lütfen öğrenci seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void DeleteStudentById(int studentId)
        {
            using (MySqlConnection connection = DatabaseConnection.BaglantiyiAl())
            {
                connection.Open();

                // 1. İlişkili verileri sil
                string deleteGradesQuery = "DELETE FROM grades WHERE StudentID = @StudentID";

                using (MySqlCommand deleteGradesCommand = new MySqlCommand(deleteGradesQuery, connection))
                {
                    deleteGradesCommand.Parameters.AddWithValue("@StudentID", studentId);
                    deleteGradesCommand.ExecuteNonQuery();
                }

                // 2. Öğrenciyi sil
                string deleteStudentQuery = "DELETE FROM student WHERE StudentId = @StudentId";

                using (MySqlCommand deleteStudentCommand = new MySqlCommand(deleteStudentQuery, connection))
                {
                    deleteStudentCommand.Parameters.AddWithValue("@StudentId", studentId);
                    deleteStudentCommand.ExecuteNonQuery();
                }
            }
        }

        private void LoadStudentsToDataGridView()
        {
            dataGridView1.DataSource = GetStudents();
          
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Sil";
            deleteButtonColumn.Text = "X";
            deleteButtonColumn.Width = 40;
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButtonColumn);

            
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.ColumnIndex == dataGridView1.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                int studentId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["StudentId"].Value);

                DialogResult result = MessageBox.Show("Seçili öğrenciyi silmek istediğinizden emin misiniz?", "Öğrenci Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteStudentById(studentId);
                    LoadStudentsToDataGridView();
                }
            }
        }

        private List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (MySqlConnection connection = DatabaseConnection.BaglantiyiAl())
            {
                connection.Open();
                string query = "SELECT * FROM student";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                StudentName = reader["StudentName"].ToString(),
                                StudentSurname = reader["StudentSurname"].ToString(),
                                StudentNo = reader["StudentNo"].ToString()
                            };
                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }
    }


}
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentNo { get; set; }
    }

