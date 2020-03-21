using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        [Serializable]
        public class Subject
        {
            public string subjectName { get; set; }
            public string semester { get; set; }
            public string grade { get; set; }
            public string specialty { get; set; }
            public int lectureCount { get; set; }
            public int labsCount { get; set; }
            public string exam { get; set; }
            public Form2.Teacher teacher{ get; set; }
            public Subject(Form2.Teacher teach)
            {
                teacher = teach;
            }
            public Subject(string subjectName, string semester, string grade, string specialty, int lectureCount, int labsCount, string exam)
            {
                this.subjectName = subjectName;
                this.semester = semester;
                this.grade = grade;
                this.specialty = specialty;
                this.lectureCount = lectureCount;
                this.labsCount = labsCount;
                this.exam = exam;

            }
            public Subject() { }
        }

        public Form1()
        {
            InitializeComponent();
            teacher = new Form2.Teacher();
            subject = new Subject(teacher);
            comboBox1.Items.Add("Add new...");
            _jsonSerializer = new JsonSerializer<Subject>("data.json");
        }
        Subject subject;
        Form2.Teacher teacher;
        JsonSerializer<Subject> _jsonSerializer;
        XmlSerializer serializer = new XmlSerializer(typeof(List<Subject>));
        XmlSerializer serializ2 = new XmlSerializer(typeof(List<Form2.Teacher>));

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateTeacherBT_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.teacher = subject.teacher;
            form.Show();
        }

        private void ShowBT_Click(object sender, EventArgs e)
        {
            var deser = _jsonSerializer.Deserialize();
            if (!string.IsNullOrEmpty(SubjectBox.Text) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                using (FileStream fs = new FileStream("subject.xml", FileMode.Open))
                {
                    subjectss.Clear();
                    subjectss = (List<Subject>)serializer.Deserialize(fs);
                }

                using (FileStream fs2 = new FileStream("teacher.xml", FileMode.Open))
                {
                    _s.Clear();
                    _s = (List<Form2.Teacher>)serializ2.Deserialize(fs2);
                }
                Info info = new Info();
                info.ShowDialog();
            }
            else
                MessageBox.Show("Заполните все поля");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

           // if (!subject.grade.Contains(checkBox.Text))
                subject.grade +=" " + checkBox.Text;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            
          //  if (!subject.semester.Contains(checkBox.Text))
            subject.semester += " " + checkBox.Text;
            sender = " ";
        }

        private void IsExam1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            subject.exam = radioButton.Text;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

          //  if (!subject.specialty.Contains(checkBox.Text))
                subject.specialty += " " + checkBox.Text;
        }

        private void SubjectBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SubjectBox.Text))
                MessageBox.Show("Введите название дисциплины");
            else
            subject.subjectName = SubjectBox.Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                subject.lectureCount = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Введите число");
                if(!string.IsNullOrEmpty(textBox1.Text))
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                subject.labsCount = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Введите число");
                if (!string.IsNullOrEmpty(textBox2.Text))
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1);
            }
        }
        private void SaveBT_Click(object sender, EventArgs e)
        {
            subjectss.Add(new Subject(subject.subjectName, subject.semester, subject.grade, subject.specialty, subject.lectureCount, subject.labsCount, subject.exam));
            using (FileStream fs = new FileStream("subject.xml", FileMode.Create))
            {
                serializer.Serialize(fs, subjectss);
            }
            using (FileStream fs2 = new FileStream("teacher.xml", FileMode.Create))
            {
                serializ2.Serialize(fs2, _s);
            }
            subjectss.Clear();
            _s.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public List<Form2.Teacher> _s = new List<Form2.Teacher>();
        public List<Subject> subjectss = new List<Subject>();
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem.ToString() == "Add new...")
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
                foreach (Form2.Teacher t in form2.teach)
                {
                    if (t.FIO.Length > 0)
                    {
                        comboBox1.Items.Add(t.FIO);
                        _s.Add(t);
                    }
                    comboBox1.SelectedItem = t.FIO;
                }
            }
        }

        private void SemesterBox_Enter(object sender, EventArgs e)
        {

        }
    }
 

}
