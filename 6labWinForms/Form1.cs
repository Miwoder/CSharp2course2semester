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
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        [Serializable]
        public class Subject
        {
            [Required(ErrorMessage = "Заполните поле название предмета", AllowEmptyStrings = false)]
            [RegularExpression(@"\w", ErrorMessage = "Поле название предмета должно состоять из букв")]
            public string subjectName { get; set; }
            [SemesterValidation]
            public string semester { get; set; }
            public string grade { get; set; }
            public string specialty { get; set; }
            [Required(ErrorMessage = "Заполните поле Часы лекций", AllowEmptyStrings = false)]
            public int lectureCount { get; set; }
            [Required(ErrorMessage = "Заполните поле Часы лаб-х раб.", AllowEmptyStrings = false)]
            public int labsCount { get; set; }
            public string exam { get; set; }
            //public Form2.Teacher teacher{ get; set; }
            public string teacher { get; set; }
            public Subject(Form2.Teacher teach)
            {
                teacher = "a";
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
            public override string ToString()
            {
                return $"Предмет: {subjectName} Семестр:{semester} Курс: {grade} Специальность: {specialty} Часов лекций: {lectureCount} Часов лаб: {labsCount} Контроль: {exam}";
            }
            public Subject() { }
        }


        public Form1()
        {
            InitializeComponent();
            teacher = new Form2.Teacher();
            subject = new Subject(teacher);
            comboBox1.Items.Add("Add new...");



            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }
        Subject subject;
        Form2.Teacher teacher;

        XmlSerializer serializer = new XmlSerializer(typeof(List<Subject>));
        XmlSerializer serializ2 = new XmlSerializer(typeof(List<Form2.Teacher>));

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void ShowBT_Click(object sender, EventArgs e)
        {

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
            last.Text = "Show";

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
        public int countSub = 0;
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
            countSub += 1;
            countStr.Text = countSub.ToString();
            subjectss.Clear();
            last.Text = "Save";
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
            last.Text = "Add new teacher";
        }

        private void SemesterBox_Enter(object sender, EventArgs e)
        {

        }

///////////////////////////////////////////
///////////////////////////////////////////
///////////////////////////////////////////
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + 
                "\nФИО разработчика: Говоронок В.А.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
             last.Text = "Info";
        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search searchform = new Search(subjectss,_s);
            searchform.Activate();
            searchform.Show();
            last.Text = "Search";
        }
        void timer_Tick(object sender, EventArgs e)
        {   
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = true;
            last.Text = "Show";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DeleteTool_Click(object sender, EventArgs e)
        {
            SubjectBox.Clear();
            textBox1.Clear();
            textBox2.Clear();
            last.Text = "Delete";
        }

        private void SearchTool_Click(object sender, EventArgs e)
        {
            Search searchform = new Search(subjectss, _s);
           searchform.Activate();
            searchform.Show();
            last.Text = "Search";
        }

        private void SortTool_Click(object sender, EventArgs e)
        {
            Search searchform = new Search(subjectss, _s);
            searchform.Activate();
            searchform.Show();
            last.Text = "Sort";

        }
    }
 

}
