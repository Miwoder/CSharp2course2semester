using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //public interface IComparable
        //{
        //    int CompareTo(object o);
        //}

        public class Student : IComparable<Student>
        {
            public int year;
            public Student(int year)
            {
                this.year = year;
            }
            public int CompareTo(Student obj)
            {
                if (this.year > obj.year)
                    return 1;
                if (this.year < obj.year)
                    return -1;
                else
                    return 0;
            }

        }

        private List<Student> students;
        private void button1_Click(object sender, EventArgs e)
        {
            students = new List<Student>();
            int size = int.Parse(textBox1.Text);
            Random rand = new Random();

            if (listBox2.Items.Count != 0)
                listBox1.Items.Clear();

            for (int i = 0; i < size; i++)
                students.Add(new Student(rand.Next(2000,2020 )));

            foreach (Student student in students)
                listBox2.Items.Add("Год выпуска: "+student.year);
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();

            students.Sort();

            foreach (Student stud in students)
                listBox1.Items.Add("Год выпуска: "+stud.year);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            students.Reverse();

            foreach (Student stud in students)
                listBox1.Items.Add("Год выпуска: " + stud.year);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(students.Max().ToString());
            var lin = students.Select(t=>t.year).Max();
            string c = Convert.ToString(lin);
            //MessageBox.Show(c);
            listBox1.Items.Clear();
            listBox1.Items.Add("Max year: " + c);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(students.Min().ToString());
            var lin = students.Select(t => t.year).Min();
            string c = Convert.ToString(lin);
           // MessageBox.Show(c);
            listBox1.Items.Clear();
            listBox1.Items.Add("Min year: " + c);
        }
    }
}
