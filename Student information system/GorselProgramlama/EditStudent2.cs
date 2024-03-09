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
    public partial class EditStudent2 : Form
    {
        public EditStudent2()
        {
            InitializeComponent();
        }

        private void EditStudent2_Load(object sender, EventArgs e)
        {
            LoadStudentsToDataGridView();
        }
        

        private void LoadStudentsToDataGridView()
        {
           
            List<Student> students = GetStudents();

            dataGridView1.DataSource = students;

           
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditButtonColumn";
            editButtonColumn.HeaderText = "Düzenle";
            editButtonColumn.Text = "Düzenle";
            editButtonColumn.Width = 60;
            editButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editButtonColumn);

            
            dataGridView1.CellContentClick += DataGridViewStudents_CellContentClick;
        }

        private void DataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == dataGridView1.Columns["EditButtonColumn"].Index && e.RowIndex >= 0)
            {
                
                int selectedStudentId = (int)dataGridView1.Rows[e.RowIndex].Cells["StudentId"].Value;
                string selectedStudentName = dataGridView1.Rows[e.RowIndex].Cells["StudentName"].Value.ToString();
                string selectedStudentSurname = dataGridView1.Rows[e.RowIndex].Cells["StudentSurname"].Value.ToString();
                string selectedStudentNo = dataGridView1.Rows[e.RowIndex].Cells["StudentNo"].Value.ToString();

                EditStudent editStudentForm = new EditStudent();
                editStudentForm.FillStudentInfo(selectedStudentId,selectedStudentName, selectedStudentSurname, selectedStudentNo);
                editStudentForm.ShowDialog();

                LoadStudentsToDataGridView();
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
