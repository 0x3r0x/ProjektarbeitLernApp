namespace ProjektarbeitLernAppGUI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(228, 228);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 275);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Passwort";
            txtPassword.Size = new Size(228, 23);
            txtPassword.TabIndex = 9;
            txtPassword.Text = "12345678";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 246);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-Mail";
            txtEmail.Size = new Size(228, 23);
            txtEmail.TabIndex = 10;
            txtEmail.Text = "mail@huelsmann-andreas.de";
            // 
            // button1
            // 
            button1.Location = new Point(12, 304);
            button1.Name = "button1";
            button1.Size = new Size(228, 23);
            button1.TabIndex = 11;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 333);
            button2.Name = "button2";
            button2.Size = new Size(228, 23);
            button2.TabIndex = 20;
            button2.Text = "Du hast kein Profil? Hier registrieren";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 362);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Button button1;
        private Button button2;
    }
}