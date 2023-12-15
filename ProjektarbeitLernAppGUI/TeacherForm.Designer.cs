namespace ProjektarbeitLernAppGUI
{
    partial class TeacherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherForm));
            dataGridView1 = new DataGridView();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            pieChart1 = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 174);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += DataGridView_SelectionChanged;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(12, 255);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(776, 151);
            cartesianChart1.TabIndex = 1;
            // 
            // pieChart1
            // 
            pieChart1.InitialRotation = 0D;
            pieChart1.IsClockwise = true;
            pieChart1.Location = new Point(12, 462);
            pieChart1.MaxAngle = 360D;
            pieChart1.MaxValue = null;
            pieChart1.MinValue = 0D;
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new Size(776, 108);
            pieChart1.TabIndex = 2;
            pieChart1.Total = null;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 613);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(776, 23);
            progressBar1.TabIndex = 3;
            progressBar1.Value = 20;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 645);
            panel1.TabIndex = 4;
            panel1.Visible = false;
            // 
            // label1
            // 
            label1.Location = new Point(3, 304);
            label1.Name = "label1";
            label1.Size = new Size(770, 90);
            label1.TabIndex = 0;
            label1.Text = "Es gibt keine Daten zum Auswerten.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TeacherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 669);
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Controls.Add(pieChart1);
            Controls.Add(cartesianChart1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TeacherForm";
            Text = "LernApp - für Lehrer";
            Load += TeacherForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChart1;
        private ProgressBar progressBar1;
        private Panel panel1;
        private Label label1;
    }
}