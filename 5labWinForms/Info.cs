using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("FIO");
            data.Columns.Add("Аудитория");
            data.Columns.Add("Department");

            Form1 form = (Form1)ActiveForm;
            foreach (Form2.Teacher s in form._s)
            {
                data.Rows.Add(s.FIO, s.Auditory, s.Department);
            }
            dataGridView1.DataSource = data;

            DataTable data2 = new DataTable();
            data2.Columns.Add("Subject name");
            data2.Columns.Add("Grade");
            data2.Columns.Add("Semester");
            data2.Columns.Add("Exam");
            data2.Columns.Add("Speciality");
            data2.Columns.Add("Labs hours");
            data2.Columns.Add("Lecture hours");
            
            foreach (Form1.Subject s in form.subjectss)
            {
                data2.Rows.Add(s.subjectName, s.grade, s.semester, s.exam, s.specialty, s.labsCount, s.lectureCount);
            }

            dataGridView2.DataSource = data2;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
