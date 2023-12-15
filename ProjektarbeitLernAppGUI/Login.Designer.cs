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
            btnLogin = new Button();
            btnShowRegister = new Button();
            checkBox1 = new CheckBox();
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
            txtPassword.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 246);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-Mail";
            txtEmail.Size = new Size(228, 23);
            txtEmail.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 327);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(228, 23);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnShowRegister
            // 
            btnShowRegister.Location = new Point(12, 356);
            btnShowRegister.Name = "btnShowRegister";
            btnShowRegister.Size = new Size(228, 23);
            btnShowRegister.TabIndex = 2;
            btnShowRegister.Text = "Du hast kein Profil? Hier registrieren";
            btnShowRegister.UseVisualStyleBackColor = true;
            btnShowRegister.Click += btnShowRegister_Click;
            // 
            // checkBox1
            // 
            checkBox1.Location = new Point(12, 302);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(231, 24);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Anmeldedaten speichern";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 383);
            Controls.Add(checkBox1);
            Controls.Add(btnShowRegister);
            Controls.Add(btnLogin);
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
        private Button btnLogin;
        private Button btnShowRegister;
        private CheckBox checkBox1;
    }
}