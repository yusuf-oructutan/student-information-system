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
    public partial class ListStudent : Form
    {
        public ListStudent()
        {
            InitializeComponent();
        }

        private void ListStudent_Load(object sender, EventArgs e)
        {
            LoadStudentsToDataGridView();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridViewStudents_CellClick);


        }
        private DataTable GetStudents()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = DatabaseConnection.BaglantiyiAl())
            {
                connection.Open();

                string query = "SELECT * FROM Student"; 
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void LoadStudentsToDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
          
            dataGridView1.ReadOnly = true; 
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = GetStudents();
           


        }
        private void dataGridViewStudents_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Cursor = Cursors.Hand; 
            }
        }

        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
               


                string studentId = row.Cells["StudentId"].Value.ToString();
                string studentName = row.Cells["StudentName"].Value.ToString();
                string studentSurname = row.Cells["StudentSurname"].Value.ToString();
                string studentNo = row.Cells["StudentNo"].Value.ToString();

               
                ShowDetails detailsForm = new ShowDetails(studentId, studentName, studentSurname, studentNo);
                detailsForm.Show();
            }
        }



    }
}
