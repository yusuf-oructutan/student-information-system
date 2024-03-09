using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorselProgramlama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (AddStudent studentForm = new AddStudent())
            {
              
                DialogResult result = studentForm.ShowDialog();

                
            }




        }

        private void button7_Click(object sender, EventArgs e)
        {

            using (EditStudent2 studentForm = new EditStudent2())
            {
                
                DialogResult result = studentForm.ShowDialog();


            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (ListStudent studentForm = new ListStudent())
            {
                
                DialogResult result = studentForm.ShowDialog();


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            using (var deleteStudentForm = new DeleteStudent())
            {
                deleteStudentForm.ShowDialog();
            }

           
        }
    }
}
