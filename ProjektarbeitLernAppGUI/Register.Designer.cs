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
            btnRegister = new Button();
            txtEmail = new TextBox();
            txtPassword1 = new TextBox();
            pictureBox1 = new PictureBox();
            txtPassword2 = new TextBox();
            txtName = new TextBox();
            txtLastName = new TextBox();
            btnShowLogin = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(12, 391);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(228, 23);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Registrieren";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 304);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-Mail";
            txtEmail.Size = new Size(228, 23);
            txtEmail.TabIndex = 5;
            // 
            // txtPassword1
            // 
            txtPassword1.Location = new Point(12, 333);
            txtPassword1.Name = "txtPassword1";
            txtPassword1.PlaceholderText = "Passwort";
            txtPassword1.Size = new Size(228, 23);
            txtPassword1.TabIndex = 6;
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
            // txtPassword2
            // 
            txtPassword2.Location = new Point(12, 362);
            txtPassword2.Name = "txtPassword2";
            txtPassword2.PlaceholderText = "Passwort wiederholen";
            txtPassword2.Size = new Size(228, 23);
            txtPassword2.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 246);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Vorname";
            txtName.Size = new Size(228, 23);
            txtName.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(12, 275);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Nachname";
            txtLastName.Size = new Size(228, 23);
            txtLastName.TabIndex = 4;
            // 
            // btnShowLogin
            // 
            btnShowLogin.Location = new Point(12, 420);
            btnShowLogin.Name = "btnShowLogin";
            btnShowLogin.Size = new Size(228, 23);
            btnShowLogin.TabIndex = 2;
            btnShowLogin.Text = "Du hast ein Profil? Hier einloggen";
            btnShowLogin.UseVisualStyleBackColor = true;
            btnShowLogin.Click += btnShowLogin_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 455);
            Controls.Add(btnShowLogin);
            Controls.Add(txtLastName);
            Controls.Add(txtName);
            Controls.Add(txtPassword2);
            Controls.Add(btnRegister);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Register";
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegister;
        private TextBox txtEmail;
        private TextBox txtPassword1;
        private PictureBox pictureBox1;
        private TextBox txtPassword2;
        private TextBox txtName;
        private TextBox txtLastName;
        private Button btnShowLogin;
    }
}