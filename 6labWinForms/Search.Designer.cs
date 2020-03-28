namespace WindowsFormsApp1
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SearchByGrade = new System.Windows.Forms.RadioButton();
            this.SearchBySemester = new System.Windows.Forms.RadioButton();
            this.SearchByLecture = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.resultRB = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(35, 42);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(213, 26);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите значение";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SearchByGrade);
            this.groupBox1.Controls.Add(this.SearchBySemester);
            this.groupBox1.Controls.Add(this.SearchByLecture);
            this.groupBox1.Location = new System.Drawing.Point(897, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 127);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск по:";
            // 
            // SearchByGrade
            // 
            this.SearchByGrade.AutoSize = true;
            this.SearchByGrade.Location = new System.Drawing.Point(7, 87);
            this.SearchByGrade.Name = "SearchByGrade";
            this.SearchByGrade.Size = new System.Drawing.Size(73, 24);
            this.SearchByGrade.TabIndex = 2;
            this.SearchByGrade.Text = "курсу";
            this.SearchByGrade.UseVisualStyleBackColor = true;
            this.SearchByGrade.CheckedChanged += new System.EventHandler(this.SearchByGrade_CheckedChanged);
            // 
            // SearchBySemester
            // 
            this.SearchBySemester.AutoSize = true;
            this.SearchBySemester.Location = new System.Drawing.Point(6, 57);
            this.SearchBySemester.Name = "SearchBySemester";
            this.SearchBySemester.Size = new System.Drawing.Size(104, 24);
            this.SearchBySemester.TabIndex = 1;
            this.SearchBySemester.Text = "семестру";
            this.SearchBySemester.UseVisualStyleBackColor = true;
            this.SearchBySemester.CheckedChanged += new System.EventHandler(this.SearchBySemester_CheckedChanged);
            // 
            // SearchByLecture
            // 
            this.SearchByLecture.AutoSize = true;
            this.SearchByLecture.Checked = true;
            this.SearchByLecture.Location = new System.Drawing.Point(7, 27);
            this.SearchByLecture.Name = "SearchByLecture";
            this.SearchByLecture.Size = new System.Drawing.Size(95, 24);
            this.SearchByLecture.TabIndex = 0;
            this.SearchByLecture.TabStop = true;
            this.SearchByLecture.Text = "лектору";
            this.SearchByLecture.UseVisualStyleBackColor = true;
            this.SearchByLecture.CheckedChanged += new System.EventHandler(this.SearchByLecture_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(897, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 78);
            this.button2.TabIndex = 6;
            this.button2.Text = "Сортировать по виду контроля";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(897, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 78);
            this.button1.TabIndex = 5;
            this.button1.Text = "Сортировать по кол-ву лекций";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // resultRB
            // 
            this.resultRB.Location = new System.Drawing.Point(35, 86);
            this.resultRB.Name = "resultRB";
            this.resultRB.Size = new System.Drawing.Size(566, 273);
            this.resultRB.TabIndex = 9;
            this.resultRB.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(612, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(257, 343);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 381);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.resultRB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchTextBox);
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SearchByGrade;
        private System.Windows.Forms.RadioButton SearchBySemester;
        private System.Windows.Forms.RadioButton SearchByLecture;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox resultRB;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}