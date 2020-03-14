namespace WindowsFormsApp1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.FIOTeacherBox = new System.Windows.Forms.TextBox();
            this.DepartmentTeacherBox = new System.Windows.Forms.TextBox();
            this.AuditoryBox = new System.Windows.Forms.TextBox();
            this.SaveTeacherF2BT = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // FIOTeacherBox
            // 
            this.FIOTeacherBox.Location = new System.Drawing.Point(17, 31);
            this.FIOTeacherBox.Multiline = true;
            this.FIOTeacherBox.Name = "FIOTeacherBox";
            this.FIOTeacherBox.Size = new System.Drawing.Size(378, 59);
            this.FIOTeacherBox.TabIndex = 0;
            this.FIOTeacherBox.Text = "ФИО Лектора";
            this.FIOTeacherBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DepartmentTeacherBox
            // 
            this.DepartmentTeacherBox.Location = new System.Drawing.Point(17, 139);
            this.DepartmentTeacherBox.Multiline = true;
            this.DepartmentTeacherBox.Name = "DepartmentTeacherBox";
            this.DepartmentTeacherBox.Size = new System.Drawing.Size(378, 59);
            this.DepartmentTeacherBox.TabIndex = 1;
            this.DepartmentTeacherBox.Text = "Кафедра лектора";
            this.DepartmentTeacherBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AuditoryBox
            // 
            this.AuditoryBox.Location = new System.Drawing.Point(17, 251);
            this.AuditoryBox.Multiline = true;
            this.AuditoryBox.Name = "AuditoryBox";
            this.AuditoryBox.Size = new System.Drawing.Size(378, 59);
            this.AuditoryBox.TabIndex = 2;
            this.AuditoryBox.Text = "Аудитория лектора";
            this.AuditoryBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveTeacherF2BT
            // 
            this.SaveTeacherF2BT.Location = new System.Drawing.Point(108, 350);
            this.SaveTeacherF2BT.Name = "SaveTeacherF2BT";
            this.SaveTeacherF2BT.Size = new System.Drawing.Size(194, 66);
            this.SaveTeacherF2BT.TabIndex = 3;
            this.SaveTeacherF2BT.Text = "Сохранить";
            this.SaveTeacherF2BT.UseVisualStyleBackColor = true;
            this.SaveTeacherF2BT.Click += new System.EventHandler(this.SaveTeacherF2BT_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 450);
            this.Controls.Add(this.SaveTeacherF2BT);
            this.Controls.Add(this.AuditoryBox);
            this.Controls.Add(this.DepartmentTeacherBox);
            this.Controls.Add(this.FIOTeacherBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FIOTeacherBox;
        private System.Windows.Forms.TextBox DepartmentTeacherBox;
        private System.Windows.Forms.TextBox AuditoryBox;
        private System.Windows.Forms.Button SaveTeacherF2BT;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}