using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Search : Form
    {
        Form data;
        XmlSerializer serializer = new XmlSerializer(typeof(List<Form1.Subject>));
        public List<Form1.Subject> searchacc;
        int SearchBY = 1;
        private List<Form1.Subject> subjects;
        private List<Form2.Teacher> teachers;
        public List<Form1.Subject> result = new List<Form1.Subject>();
        private List<Form1.Subject> sortSub = new List<Form1.Subject>();
        public List<Form2.Teacher> searchsub = new List<Form2.Teacher>();
        public List<Form1.Subject> searchsub2 = new List<Form1.Subject>();
        public List<Form1.Subject> searchsub3 = new List<Form1.Subject>();

        public Search(List<Form1.Subject> subjectlist, List<Form2.Teacher> teachlist)
        {
            InitializeComponent();
            this.subjects = subjectlist;
            this.teachers = teachlist;
        }


        private void Search_Load(object sender, EventArgs e)
        {

        }
           
        private void SearchByLecture_CheckedChanged(object sender, EventArgs e)
        {
            SearchTextBox.Clear();
            resultRB.Clear();
            SearchBY = 1;
        }

        private void SearchBySemester_CheckedChanged(object sender, EventArgs e)
        {
            SearchTextBox.Clear();
            resultRB.Clear();
            SearchBY = 2;
        }

        private void SearchByGrade_CheckedChanged(object sender, EventArgs e)
        {
            SearchTextBox.Clear();
            resultRB.Clear();
            SearchBY = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sortSub.Clear();
            richTextBox1.Clear();
            var sorted = subjects.OrderBy(p => p.lectureCount).Select(p => p);
            foreach (Form1.Subject sub in sorted)
            {
                sortSub.Add(sub);
                richTextBox1.Text += Environment.NewLine + "Предмет: " + sub.subjectName + Environment.NewLine  + "Вид контроля: " + sub.exam + Environment.NewLine +"Специальность: " +
                    sub.specialty + Environment.NewLine + "Семестр: " + sub.semester + Environment.NewLine + "Часов лекции: " + sub.lectureCount +
                    Environment.NewLine + "Часов лаб: " + sub.labsCount + Environment.NewLine + "Курс: " + sub.grade + Environment.NewLine;
            }
            using (FileStream fs = new FileStream("SortLecture.xml", FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Form1.Subject>));
                formatter.Serialize(fs, sortSub);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sortSub.Clear();
            richTextBox1.Clear();
            var sorted = subjects.OrderBy(p => p.exam).Select(p => p);
            foreach (Form1.Subject sub in sorted)
            {
                sortSub.Add(sub);
                richTextBox1.Text += Environment.NewLine +  "Предмет: " + sub.subjectName + Environment.NewLine + "Вид контроля: " + sub.exam + Environment.NewLine+ "Специальность: " +
                    sub.specialty + Environment.NewLine + "Семестр: " + sub.semester + Environment.NewLine + "Часов лекции: " + sub.lectureCount +
                    Environment.NewLine + "Часов лаб: " + sub.labsCount + Environment.NewLine + "Курс: " + sub.grade + Environment.NewLine;
            }
            using (FileStream fs = new FileStream("SortExam.xml", FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Form1.Subject>));
                formatter.Serialize(fs, sortSub);
            }

        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchByGrade.Checked) SearchBY = 3;
            if (SearchBySemester.Checked) SearchBY = 2; 
            
            switch (SearchBY)
            {
                case 1:
                    
                    resultRB.Clear();
                    Regex regex = new Regex($"^{SearchTextBox.Text}$");

                    foreach (Form2.Teacher p in teachers)
                    {
                         MatchCollection match = regex.Matches(p.FIO);

                         if (match.Count > 0)
                         {
                            searchsub.Add(p);
                         }
                        }
                    foreach(Form2.Teacher tch in searchsub)
                    {
                        resultRB.Update();
                        resultRB.Text += Environment.NewLine + Environment.NewLine + tch.ToString();
                    }
                    SearchTextBox.Update();

                    using (FileStream fs = new FileStream("SearchResultTeacher.xml", FileMode.Create))
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(List<Form2.Teacher>));
                        formatter.Serialize(fs, searchsub);
                    }
                    break;

                case 2:
                    
                    resultRB.Clear();


                    Regex regex1 = new Regex($"^{SearchTextBox.Text}$");
                    
                    foreach (Form1.Subject p in subjects)
                    {
                        MatchCollection match = regex1.Matches(p.semester.Trim());

                        if (match.Count > 0)
                        {
                            searchsub2.Add(p);
                        }
                    }
                    foreach (Form1.Subject sub in searchsub2)
                    {
                        resultRB.Update();
                        resultRB.Text += Environment.NewLine + Environment.NewLine + sub.ToString();
                    }

                    resultRB.Update();

                    using (FileStream fs = new FileStream("SearchResultSemester.xml", FileMode.Create))
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(List<Form1.Subject>));
                        formatter.Serialize(fs, searchsub2);
                    }
                    break;
                case 3:
                    Regex regex2 = new Regex($"^{SearchTextBox.Text}$");

                    foreach (Form1.Subject p in subjects)
                    {
                        MatchCollection match = regex2.Matches(p.grade.Trim());

                        if (match.Count > 0)
                        {
                            searchsub3.Add(p);
                        }
                    }
                    foreach (Form1.Subject sub in searchsub3)
                    {
                        resultRB.Update();
                        resultRB.Text += Environment.NewLine + Environment.NewLine + sub.ToString();
                    }

                    SearchTextBox.Update();

                    using (FileStream fs = new FileStream("SearchResultGrade.xml", FileMode.Create))
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(List<Form1.Subject>));
                        formatter.Serialize(fs, searchsub3);
                    }
                    break;
            }

        }


    }
}