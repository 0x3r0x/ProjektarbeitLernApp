using ProjektarbeitLernApp.Model.Auth;
using ProjektarbeitLernApp.PLAContext;
using ProjektarbeitLernApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeitLernAppGUI
{
    public partial class Login : Form
    {
        private UserService userService;
        private DatabasePLAContext dbContext;

        public Login(DatabasePLAContext dbContext)
        {
            this.dbContext = dbContext;

            userService = new UserService(dbContext);
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            var (username, password) = LoadLoginData();
            if (username != null && password != null)
            {
                txtEmail.Text = username;
                txtPassword.Text = password;
                checkBox1.Checked = true;
            }
        }

        private void btnShowRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new Register(dbContext);
            registerForm.Show();
            this.Hide();
        }
        private (string, string) LoadLoginData()
        {
            string filePath = "login.txt";
            if (File.Exists(filePath))
            {
                string[] data = File.ReadAllText(filePath).Split(',');
                if (data.Length == 2)
                {
                    return (data[0], data[1]);
                }
            }
            return (null, null);
        }

        private void SaveLoginData(string username, string password)
        {
            string filePath = "login.txt";
            File.WriteAllText(filePath, $"{username},{password}");
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var user = new User();
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;

            if(checkBox1.Checked)
                SaveLoginData(user.Email, user.Password);

            var isValigLogin = await userService.LoginAsync(user);
            if (isValigLogin)
            {
                user.Id = userService.GetUserId(user);
                if (userService.IsStudent(user))
                {
                    var mainForm = new StudentForm(dbContext, user);
                    mainForm.Show();
                    this.Hide();
                } else if(userService.IsTeacher(user)) 
                {
                    var mainForm = new TeacherForm(dbContext, user);
                    mainForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Falsche Logindaten");
            }
        }

    }
}
