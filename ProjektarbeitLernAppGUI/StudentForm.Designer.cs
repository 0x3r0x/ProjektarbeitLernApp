﻿namespace ProjektarbeitLernAppGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            btnNotKnown = new Button();
            btnKnown = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            dataGridView2 = new DataGridView();
            lblQuestion = new Label();
            tabPage1 = new TabPage();
            button4 = new Button();
            panel2 = new Panel();
            tabPage4 = new TabPage();
            button7 = new Button();
            button5 = new Button();
            dateTimePicker2 = new DateTimePicker();
            button3 = new Button();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            tabPage5 = new TabPage();
            label3 = new Label();
            progressBar1 = new ProgressBar();
            pieChart1 = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabPage6 = new TabPage();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            button6 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            dataGridView3 = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage1.SuspendLayout();
            panel2.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.ItemSize = new Size(48, 48);
            tabControl1.Location = new Point(-1, 9);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(10, 3);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1105, 545);
            tabControl1.TabIndex = 6;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnNotKnown);
            tabPage3.Controls.Add(btnKnown);
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(button1);
            tabPage3.Controls.Add(panel1);
            tabPage3.Location = new Point(4, 52);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1097, 489);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Lernen";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnNotKnown
            // 
            btnNotKnown.BackColor = Color.DarkRed;
            btnNotKnown.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNotKnown.ForeColor = Color.White;
            btnNotKnown.Location = new Point(8, 373);
            btnNotKnown.Name = "btnNotKnown";
            btnNotKnown.Size = new Size(710, 116);
            btnNotKnown.TabIndex = 5;
            btnNotKnown.Text = "nicht gewusst";
            btnNotKnown.UseVisualStyleBackColor = false;
            btnNotKnown.Visible = false;
            // 
            // btnKnown
            // 
            btnKnown.BackColor = Color.DarkGreen;
            btnKnown.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnKnown.Location = new Point(8, 373);
            btnKnown.Name = "btnKnown";
            btnKnown.Size = new Size(710, 116);
            btnKnown.TabIndex = 4;
            btnKnown.Text = "gewusst";
            btnKnown.UseVisualStyleBackColor = false;
            btnKnown.Visible = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(724, 373);
            button2.Name = "button2";
            button2.Size = new Size(179, 116);
            button2.TabIndex = 3;
            button2.Text = "Auswerten";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Enabled = false;
            button1.Location = new Point(912, 373);
            button1.Name = "button1";
            button1.Size = new Size(179, 116);
            button1.TabIndex = 2;
            button1.Text = "Weiter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(dataGridView2);
            panel1.Controls.Add(lblQuestion);
            panel1.Location = new Point(8, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1083, 362);
            panel1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.BackgroundColor = SystemColors.Control;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView2.Location = new Point(0, 70);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(1083, 285);
            dataGridView2.TabIndex = 4;
            // 
            // lblQuestion
            // 
            lblQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblQuestion.BackColor = SystemColors.Control;
            lblQuestion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion.Location = new Point(0, 0);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(1083, 67);
            lblQuestion.TabIndex = 4;
            lblQuestion.Text = "Wer ist verantwortlich für die Implementierung und Pflege der Definition of Done (DoD) in einem Scrum-Team und warum?";
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 52);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1097, 489);
            tabPage1.TabIndex = 5;
            tabPage1.Text = "Prüfungssimulation";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Enabled = false;
            button4.Location = new Point(912, 373);
            button4.Name = "button4";
            button4.Size = new Size(179, 116);
            button4.TabIndex = 5;
            button4.Text = "Weiter";
            button4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(dataGridView3);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(8, 9);
            panel2.Name = "panel2";
            panel2.Size = new Size(1083, 357);
            panel2.TabIndex = 4;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(button7);
            tabPage4.Controls.Add(button5);
            tabPage4.Controls.Add(dateTimePicker2);
            tabPage4.Controls.Add(button3);
            tabPage4.Controls.Add(dateTimePicker1);
            tabPage4.Controls.Add(textBox1);
            tabPage4.Controls.Add(dataGridView1);
            tabPage4.Location = new Point(4, 52);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1097, 489);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "Routinen";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(950, 37);
            button7.Name = "button7";
            button7.Size = new Size(141, 23);
            button7.TabIndex = 6;
            button7.Text = "Alle Entfernen";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.Location = new Point(950, 8);
            button5.Name = "button5";
            button5.Size = new Size(141, 23);
            button5.TabIndex = 5;
            button5.Text = "Entfernen";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Location = new Point(8, 61);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(307, 23);
            dateTimePicker2.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(8, 90);
            button3.Name = "button3";
            button3.Size = new Size(307, 23);
            button3.TabIndex = 3;
            button3.Text = "Hinzufügen";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            dateTimePicker1.Location = new Point(8, 32);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(307, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Value = new DateTime(2023, 12, 4, 0, 0, 0, 0);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 3);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Routinen Name";
            textBox1.Size = new Size(307, 23);
            textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(321, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(623, 493);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(label3);
            tabPage5.Controls.Add(progressBar1);
            tabPage5.Controls.Add(pieChart1);
            tabPage5.Controls.Add(cartesianChart1);
            tabPage5.Location = new Point(4, 52);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1097, 489);
            tabPage5.TabIndex = 2;
            tabPage5.Text = "Statistiken";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 426);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 3;
            label3.Text = "Prüfungsreife";
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(11, 444);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1081, 23);
            progressBar1.TabIndex = 2;
            progressBar1.Value = 50;
            // 
            // pieChart1
            // 
            pieChart1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pieChart1.InitialRotation = 0D;
            pieChart1.IsClockwise = true;
            pieChart1.Location = new Point(11, 331);
            pieChart1.MaxAngle = 360D;
            pieChart1.MaxValue = null;
            pieChart1.MinValue = 0D;
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new Size(1078, 92);
            pieChart1.TabIndex = 1;
            pieChart1.Total = null;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cartesianChart1.Location = new Point(8, 3);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(1081, 322);
            cartesianChart1.TabIndex = 0;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(textBox6);
            tabPage6.Controls.Add(textBox5);
            tabPage6.Controls.Add(textBox4);
            tabPage6.Controls.Add(textBox3);
            tabPage6.Controls.Add(textBox2);
            tabPage6.Controls.Add(button6);
            tabPage6.Location = new Point(4, 52);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1097, 489);
            tabPage6.TabIndex = 3;
            tabPage6.Text = "Mein Profil";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox6.Location = new Point(8, 119);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Passwort wiederholen";
            textBox6.Size = new Size(1083, 23);
            textBox6.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox5.Location = new Point(8, 61);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "E-Mail";
            textBox5.Size = new Size(1083, 23);
            textBox5.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox4.Location = new Point(8, 90);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Passwort";
            textBox4.Size = new Size(1083, 23);
            textBox4.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Enabled = false;
            textBox3.Location = new Point(8, 32);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Nachname";
            textBox3.Size = new Size(1083, 23);
            textBox3.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Enabled = false;
            textBox2.Location = new Point(8, 3);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Vorname";
            textBox2.Size = new Size(1083, 23);
            textBox2.TabIndex = 7;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button6.Enabled = false;
            button6.Location = new Point(912, 373);
            button6.Name = "button6";
            button6.Size = new Size(179, 116);
            button6.TabIndex = 6;
            button6.Text = "Speichern";
            button6.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1056, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(46, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 3);
            label1.Name = "label1";
            label1.Size = new Size(1083, 67);
            label1.TabIndex = 5;
            label1.Text = "Wer ist verantwortlich für die Implementierung und Pflege der Definition of Done (DoD) in einem Scrum-Team und warum?";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView3
            // 
            dataGridView3.BackgroundColor = SystemColors.Control;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(0, 70);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(1083, 287);
            dataGridView3.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 560);
            Controls.Add(pictureBox1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1123, 594);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Panel panel1;
        private Label lblQuestion;
        private Button button2;
        private Button button1;
        private TabPage tabPage1;
        private Button button4;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button button3;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Button button5;
        private DateTimePicker dateTimePicker2;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChart1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private Label label3;
        private ProgressBar progressBar1;
        private Button button6;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private CheckBox checkBox9;
        private PictureBox pictureBox1;
        private DataGridView dataGridView2;
        private Button btnNotKnown;
        private Button btnKnown;
        private Button button7;
        private Label label1;
        private DataGridView dataGridView3;
    }
}