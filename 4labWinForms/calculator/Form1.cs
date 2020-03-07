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
    public partial class Calculator : Form, ICalculate
    {
        public Calculator()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Calculator_Load(object sender, EventArgs e)
        {
           
        }

        public void VvodButton_Click(object sender, EventArgs e)
        {
            string stroka = Console.ReadLine();
            sender = stroka;
            textBox1.Text += (sender as Button);
        } 
       

        public void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text += (sender as Button).Text;

        }

        private void button36_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        char space = ' ';
        private void button32_Click(object sender, EventArgs e)
        {
            textBox1.Text += space;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            textBox1.Text+= "Длина строки " + textBox1.TextLength;
        }

        int glas, sogl = 0;
        const string sogl_lett = "ЙйЦцКкНнГгшШщЩзЗхХъЪФфВвПпрРЛлдДЖжЧчСсМмТтЬьбБ";
        const string glas_lett = "УуЕеЫыАаОоЭэЯяИиЮю";

        private void button40_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Text.Length; ++i)
                for (int j = 0; j < sogl_lett.Length; ++j)
                    if (textBox1.Text[i] == sogl_lett[j])
                        ++sogl;
            textBox1.Clear();
            textBox1.Text += "Соласных: " + sogl;
            sogl = 0;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            int predl = 0;
            char dot = '.';
            for (int i = 0; i < textBox1.Text.Length; ++i)
                    if (textBox1.Text[i] == dot)
                        ++predl;
            textBox1.Clear();
            textBox1.Text += "Предложений: " + predl;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            int words = 1;
            char space = ' ';
            for (int i = 0; i < textBox1.Text.Length; ++i)
                if (textBox1.Text[i] == space)
                    ++words;
            textBox1.Clear();
            textBox1.Text += "Слов: " + words;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Text.Length; ++i)
                for (int j = 0; j < glas_lett.Length; ++j)
                    if (textBox1.Text[i] == glas_lett[j])
                        ++glas;
            textBox1.Clear();
            textBox1.Text += "Гласных: " + glas;
            glas = 0;
        }

        int index = 0;

        private void button43_Click(object sender, EventArgs e)
        {
            char letter=' ';
            index = Convert.ToInt32(textBox1.Text.Substring(textBox1.Text.Length-1, 1));
            letter = textBox1.Text[index-1];
            textBox1.Text += ($"    Буква с индексом {index} : {letter}");
        }
    }
}
