namespace ProjektarbeitLernAppGUI
{
    partial class StudentForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            dataGridView2 = new DataGridView();
            lblQuestion = new Label();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            label1 = new Label();
            button10 = new Button();
            label4 = new Label();
            button9 = new Button();
            button8 = new Button();
            button4 = new Button();
            panel2 = new Panel();
            tabControl2 = new TabControl();
            tabPage2 = new TabPage();
            tabPage7 = new TabPage();
            progressBar2 = new ProgressBar();
            tabPage4 = new TabPage();
            button7 = new Button();
            button5 = new Button();
            dateTimePicker2 = new DateTimePicker();
            button3 = new Button();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            tabPage5 = new TabPage();
            panel3 = new Panel();
            label2 = new Label();
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
            timer1 = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage5.SuspendLayout();
            panel3.SuspendLayout();
            tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(button9);
            tabPage1.Controls.Add(button8);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 52);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1097, 489);
            tabPage1.TabIndex = 5;
            tabPage1.Text = "Prüfungssimulation";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Controls.Add(button10);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1091, 486);
            panel4.TabIndex = 8;
            // 
            // label1
            // 
            label1.Location = new Point(0, 216);
            label1.Name = "label1";
            label1.Size = new Size(1091, 23);
            label1.TabIndex = 1;
            label1.Text = "Du hast 30 Minuten Zeit für diese Prüfungssimulation. Wenn du bereit bist, klicke einfach auf \"Jetzt Starten\"";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button10
            // 
            button10.Location = new Point(8, 324);
            button10.Name = "button10";
            button10.Size = new Size(1073, 23);
            button10.TabIndex = 0;
            button10.Text = "Jetzt Starten";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label4
            // 
            label4.Location = new Point(3, 339);
            label4.Name = "label4";
            label4.Size = new Size(1091, 23);
            label4.TabIndex = 9;
            label4.Text = "00:30:00";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button9.Location = new Point(8, 370);
            button9.Name = "button9";
            button9.Size = new Size(179, 116);
            button9.TabIndex = 7;
            button9.Text = "Abgeben";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button8.Enabled = false;
            button8.Location = new Point(724, 373);
            button8.Name = "button8";
            button8.Size = new Size(179, 116);
            button8.TabIndex = 6;
            button8.Text = "Zurück";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(912, 373);
            button4.Name = "button4";
            button4.Size = new Size(179, 116);
            button4.TabIndex = 5;
            button4.Text = "Weiter";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(tabControl2);
            panel2.Controls.Add(progressBar2);
            panel2.Location = new Point(8, 9);
            panel2.Name = "panel2";
            panel2.Size = new Size(1083, 357);
            panel2.TabIndex = 4;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Controls.Add(tabPage7);
            tabControl2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl2.Location = new Point(3, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1077, 309);
            tabControl2.TabIndex = 7;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1069, 279);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 26);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(1069, 279);
            tabPage7.TabIndex = 1;
            tabPage7.Text = "tabPage7";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            progressBar2.Enabled = false;
            progressBar2.Location = new Point(0, 335);
            progressBar2.MarqueeAnimationSpeed = 0;
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(1083, 23);
            progressBar2.TabIndex = 10;
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
            button5.Location = new Point(950, 2);
            button5.Name = "button5";
            button5.Size = new Size(141, 23);
            button5.TabIndex = 5;
            button5.Text = "Entfernen";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(8, 61);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
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
            dataGridView1.Size = new Size(623, 487);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(panel3);
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
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Location = new Point(8, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1086, 483);
            panel3.TabIndex = 4;
            panel3.Visible = false;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(1078, 483);
            label2.TabIndex = 0;
            label2.Text = "Es sind noch keine Daten zum Abbilden vorhanden.";
            label2.TextAlign = ContentAlignment.MiddleCenter;
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
            button6.Location = new Point(912, 367);
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
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 560);
            Controls.Add(pictureBox1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1123, 594);
            Name = "StudentForm";
            Text = "LernApp - für Schüler";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            panel3.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Panel panel3;
        private Label label2;
        private TabControl tabControl2;
        private TabPage tabPage2;
        private TabPage tabPage7;
        private Button button8;
        private Button button9;
        private Panel panel4;
        private Label label1;
        private Button button10;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private ProgressBar progressBar2;
    }
}
