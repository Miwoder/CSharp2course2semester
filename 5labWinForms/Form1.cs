using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        [Serializable]
        class Subject
        {
            public string subjectName { get; set; }
            public string semester { get; set; }
            public string grade { get; set; }
            public string specialty { get; set; }
            public string lectureCount { get; set; }
            public string labsCount { get; set; }
            public string exam { get; set; }
            public Teacher teacher{ get; set; }
            public Subject(Teacher teach)
            {
                teacher = teach;
            }
        }

        public Form1()
        {
            InitializeComponent();
            teacher = new Teacher();
            subject = new Subject(teacher);
            _jsonSerializer = new JsonSerializer<Subject>("data.json");
        }
        Subject subject;
        Teacher teacher;
        JsonSerializer<Subject> _jsonSerializer;

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

            MessageBox.Show("ФИО лектора: " + deser.teacher.FIO + ". Кафедра: " + deser.teacher.Department +
                ". Аудитория: " + deser.teacher.Auditory + ". Название дисциплины: " + deser.subjectName +". Курс: " 
                + deser.grade + ". Семестр: " + deser.semester + ". Тип контроля:" + deser.exam +
                ". Специальность: " + deser.specialty + ". Кол-во часов лаб.: " + deser.labsCount + 
                ". Кол-во часов лекций: " + deser.lectureCount);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            subject.grade +=" " + checkBox.Text;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            subject.semester += " " + checkBox.Text;
        }

        private void IsExam1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            subject.exam = radioButton.Text;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            subject.specialty += " " + checkBox.Text;
        }

        private void SubjectBox_TextChanged(object sender, EventArgs e)
        {
            subject.subjectName = SubjectBox.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            subject.lectureCount = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            subject.labsCount = textBox2.Text;
        }

        private void SaveBT_Click(object sender, EventArgs e)
        {
            _jsonSerializer.Serialize(subject);
        }
    }
    [Serializable]
    public class Teacher
    {
        public string FIO;
        public string Auditory;
        public string Department;
    }

}
