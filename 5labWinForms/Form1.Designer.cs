namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateTeacherBT = new System.Windows.Forms.Button();
            this.SubjectBox = new System.Windows.Forms.TextBox();
            this.SemesterBox = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.GradeBox = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DepartmentBox = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IsExam2 = new System.Windows.Forms.RadioButton();
            this.IsExam1 = new System.Windows.Forms.RadioButton();
            this.SaveBT = new System.Windows.Forms.Button();
            this.ShowBT = new System.Windows.Forms.Button();
            this.SemesterBox.SuspendLayout();
            this.GradeBox.SuspendLayout();
            this.DepartmentBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateTeacherBT
            // 
            this.CreateTeacherBT.Location = new System.Drawing.Point(229, 185);
            this.CreateTeacherBT.Name = "CreateTeacherBT";
            this.CreateTeacherBT.Size = new System.Drawing.Size(139, 48);
            this.CreateTeacherBT.TabIndex = 0;
            this.CreateTeacherBT.Text = "Лектор";
            this.CreateTeacherBT.UseVisualStyleBackColor = true;
            this.CreateTeacherBT.Click += new System.EventHandler(this.CreateTeacherBT_Click);
            // 
            // SubjectBox
            // 
            this.SubjectBox.Location = new System.Drawing.Point(12, 12);
            this.SubjectBox.Multiline = true;
            this.SubjectBox.Name = "SubjectBox";
            this.SubjectBox.Size = new System.Drawing.Size(222, 44);
            this.SubjectBox.TabIndex = 1;
            this.SubjectBox.Text = "Название дисциплины";
            this.SubjectBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SubjectBox.TextChanged += new System.EventHandler(this.SubjectBox_TextChanged);
            // 
            // SemesterBox
            // 
            this.SemesterBox.Controls.Add(this.checkBox5);
            this.SemesterBox.Controls.Add(this.checkBox6);
            this.SemesterBox.Location = new System.Drawing.Point(106, 62);
            this.SemesterBox.Name = "SemesterBox";
            this.SemesterBox.Size = new System.Drawing.Size(101, 61);
            this.SemesterBox.TabIndex = 4;
            this.SemesterBox.TabStop = false;
            this.SemesterBox.Text = "Семестр";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(57, 26);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(44, 24);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "2";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(6, 26);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(44, 24);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.Text = "1";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // GradeBox
            // 
            this.GradeBox.Controls.Add(this.checkBox4);
            this.GradeBox.Controls.Add(this.checkBox3);
            this.GradeBox.Controls.Add(this.checkBox2);
            this.GradeBox.Controls.Add(this.checkBox1);
            this.GradeBox.Location = new System.Drawing.Point(12, 62);
            this.GradeBox.Name = "GradeBox";
            this.GradeBox.Size = new System.Drawing.Size(88, 147);
            this.GradeBox.TabIndex = 5;
            this.GradeBox.TabStop = false;
            this.GradeBox.Text = "Курс";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 116);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(44, 24);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(7, 86);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(44, 24);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 56);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(44, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(44, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // DepartmentBox
            // 
            this.DepartmentBox.Controls.Add(this.checkBox7);
            this.DepartmentBox.Controls.Add(this.checkBox8);
            this.DepartmentBox.Controls.Add(this.checkBox9);
            this.DepartmentBox.Controls.Add(this.checkBox10);
            this.DepartmentBox.Location = new System.Drawing.Point(12, 215);
            this.DepartmentBox.Name = "DepartmentBox";
            this.DepartmentBox.Size = new System.Drawing.Size(147, 147);
            this.DepartmentBox.TabIndex = 6;
            this.DepartmentBox.TabStop = false;
            this.DepartmentBox.Text = "Специальность";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(6, 116);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(105, 24);
            this.checkBox7.TabIndex = 3;
            this.checkBox7.Text = "ПОИБМС";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.Click += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(7, 86);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(81, 24);
            this.checkBox8.TabIndex = 2;
            this.checkBox8.Text = "ДЭВИ";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.Click += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(7, 56);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(77, 24);
            this.checkBox9.TabIndex = 1;
            this.checkBox9.Text = "ИСИТ";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.Click += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(7, 26);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(79, 24);
            this.checkBox10.TabIndex = 0;
            this.checkBox10.Text = "ПОИТ";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(240, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 44);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Кол-во лекций";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(240, 68);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(128, 44);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Кол-во лаб.раб.";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IsExam2);
            this.groupBox1.Controls.Add(this.IsExam1);
            this.groupBox1.Location = new System.Drawing.Point(106, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Семестр";
            // 
            // IsExam2
            // 
            this.IsExam2.AutoSize = true;
            this.IsExam2.Location = new System.Drawing.Point(6, 48);
            this.IsExam2.Name = "IsExam2";
            this.IsExam2.Size = new System.Drawing.Size(100, 24);
            this.IsExam2.TabIndex = 1;
            this.IsExam2.TabStop = true;
            this.IsExam2.Text = "Экзамен";
            this.IsExam2.UseVisualStyleBackColor = true;
            this.IsExam2.CheckedChanged += new System.EventHandler(this.IsExam1_CheckedChanged);
            // 
            // IsExam1
            // 
            this.IsExam1.AutoSize = true;
            this.IsExam1.Location = new System.Drawing.Point(6, 19);
            this.IsExam1.Name = "IsExam1";
            this.IsExam1.Size = new System.Drawing.Size(81, 24);
            this.IsExam1.TabIndex = 0;
            this.IsExam1.TabStop = true;
            this.IsExam1.Text = "Зачет";
            this.IsExam1.UseVisualStyleBackColor = true;
            this.IsExam1.CheckedChanged += new System.EventHandler(this.IsExam1_CheckedChanged);
            // 
            // SaveBT
            // 
            this.SaveBT.Location = new System.Drawing.Point(229, 239);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Size = new System.Drawing.Size(139, 54);
            this.SaveBT.TabIndex = 12;
            this.SaveBT.Text = "Сохранить";
            this.SaveBT.UseVisualStyleBackColor = true;
            this.SaveBT.Click += new System.EventHandler(this.SaveBT_Click);
            // 
            // ShowBT
            // 
            this.ShowBT.Location = new System.Drawing.Point(229, 299);
            this.ShowBT.Name = "ShowBT";
            this.ShowBT.Size = new System.Drawing.Size(139, 54);
            this.ShowBT.TabIndex = 13;
            this.ShowBT.Text = "Показать";
            this.ShowBT.UseVisualStyleBackColor = true;
            this.ShowBT.Click += new System.EventHandler(this.ShowBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 365);
            this.Controls.Add(this.ShowBT);
            this.Controls.Add(this.SaveBT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DepartmentBox);
            this.Controls.Add(this.GradeBox);
            this.Controls.Add(this.SemesterBox);
            this.Controls.Add(this.SubjectBox);
            this.Controls.Add(this.CreateTeacherBT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SemesterBox.ResumeLayout(false);
            this.SemesterBox.PerformLayout();
            this.GradeBox.ResumeLayout(false);
            this.GradeBox.PerformLayout();
            this.DepartmentBox.ResumeLayout(false);
            this.DepartmentBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateTeacherBT;
        private System.Windows.Forms.TextBox SubjectBox;
        private System.Windows.Forms.GroupBox SemesterBox;
        private System.Windows.Forms.GroupBox GradeBox;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox DepartmentBox;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton IsExam2;
        private System.Windows.Forms.RadioButton IsExam1;
        private System.Windows.Forms.Button SaveBT;
        private System.Windows.Forms.Button ShowBT;
    }
}

