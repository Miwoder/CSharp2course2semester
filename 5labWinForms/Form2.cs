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
    public partial class Form2 : Form
    {
        public Teacher teacher { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void SaveTeacherF2BT_Click(object sender, EventArgs e)
        {
            if (FIOTeacherBox != null && AuditoryBox != null && DepartmentTeacherBox != null)
            {
                teacher.FIO = FIOTeacherBox.Text;
                teacher.Auditory = AuditoryBox.Text;
                teacher.Department = DepartmentTeacherBox.Text;
                this.Close();
            }
            else
                MessageBox.Show("Заполните информацию!");
        }
    }
}
