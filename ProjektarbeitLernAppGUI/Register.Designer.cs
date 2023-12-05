namespace ProjektarbeitLernAppGUI
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 391);
            button1.Name = "button1";
            button1.Size = new Size(228, 23);
            button1.TabIndex = 15;
            button1.Text = "Registrieren";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 304);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "E-Mail";
            textBox2.Size = new Size(228, 23);
            textBox2.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 333);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Passwort";
            textBox1.Size = new Size(228, 23);
            textBox1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(228, 228);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 362);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Passwort wiederholen";
            textBox3.Size = new Size(228, 23);
            textBox3.TabIndex = 16;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 246);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Vorname";
            textBox4.Size = new Size(228, 23);
            textBox4.TabIndex = 17;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(12, 275);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Nachname";
            textBox5.Size = new Size(228, 23);
            textBox5.TabIndex = 18;
            // 
            // button2
            // 
            button2.Location = new Point(12, 420);
            button2.Name = "button2";
            button2.Size = new Size(228, 23);
            button2.TabIndex = 19;
            button2.Text = "Du hast ein Profil? Hier einloggen";
            button2.UseVisualStyleBackColor = true;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 455);
            Controls.Add(button2);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Register";
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button2;
    }
}