using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    /// Stellt das Registrierungsformular der Anwendung dar und verarbeitet die Benutzerregistrierung.
    /// </summary>
    public partial class Register : Form
    {
        private UserService userService;
        private DatabasePLAContext dbContext;
        private LearnProgressService learnProgressService;
        private MultipleChoiceSetService multipleChoiceSetService;

        /// <summary>
        /// Konstruktor für das Registrierungsformular. Initialisiert benötigte Services.
        /// </summary>
        /// <param name="dbContext">Datenbankkontext für Datenbankoperationen.</param>
        public Register(DatabasePLAContext dbContext)
        {
            var userService = new UserService(dbContext);
            var statisticService = new StatisticService(dbContext);
            multipleChoiceSetService = new MultipleChoiceSetService(dbContext);
            learnProgressService = new LearnProgressService(dbContext, statisticService);

            this.dbContext = dbContext;
            this.userService = userService;

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Zeigt das Login-Formular an und verbirgt das aktuelle Registrierungsformular.
        /// </summary>
        private void btnShowLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new Login(dbContext);
            loginForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Verarbeitet die Benutzerregistrierung und initiiert den Lernfortschritt.
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword1.Text != txtPassword2.Text) {
                MessageBox.Show("Die Passwörter stimmen nicht überein");
                return;
            }
            
            var user = new User();
            user.Email = txtEmail.Text;
            user.Password = txtPassword1.Text;
            user.Role = 0;
            user.Name = txtName.Text;
            user.LastName = txtLastName.Text;

            var registered = userService.Register(user);

            if (registered)
            {
                var questions = multipleChoiceSetService.GetAllQuestions();
                learnProgressService.InitiateLearnProgress(questions, user);
                var loginForm = new Login(dbContext);
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Fehler bei der Registrierung. Eventuell ist die E-Mail bereits vergeben");
            }
        }
    }
}
