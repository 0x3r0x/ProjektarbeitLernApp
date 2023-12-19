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
    /// <summary>
    /// Diese Klasse repräsentiert das Login-Fenster der Anwendung.
    /// Benutzer können sich hier anmelden und ihre Anmeldeinformationen speichern.
    /// </summary>
    public partial class Login : Form
    {
        private UserService userService;
        private DatabasePLAContext dbContext;

        /// <summary>
        /// Initialisiert eine neue Instanz des Login-Fensters.
        /// </summary>
        /// <param name="dbContext">Die Datenbankkontext-Instanz.</param>
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

        /// <summary>
        /// Zeigt das Registrierungsformular an und blendet das Login-Fenster aus.
        /// </summary>
        private void btnShowRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new Register(dbContext);
            registerForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Lädt zuvor gespeicherte Anmeldeinformationen aus der Datei "login.txt".
        /// </summary>
        /// <returns>Ein Tupel mit dem Benutzernamen und dem Passwort oder null, wenn keine gespeicherten Informationen vorhanden sind.</returns>
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

        /// <summary>
        /// Speichert die übergebenen Anmeldeinformationen (Benutzernamen und Passwort) in der Datei "login.txt".
        /// </summary>
        /// <param name="username">Der Benutzername, der gespeichert werden soll.</param>
        /// <param name="password">Das Passwort, das gespeichert werden soll.</param>

        private void SaveLoginData(string username, string password)
        {
            string filePath = "login.txt";
            File.WriteAllText(filePath, $"{username},{password}");
        }

        /// <summary>
        /// Behandelt den Anmeldevorgang, überprüft die Anmeldeinformationen und zeigt das entsprechende Hauptformular an.
        /// </summary>
        /// <param name="sender">Das auslösende Steuerelement.</param>
        /// <param name="e">Die Ereignisargumente.</param>
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
