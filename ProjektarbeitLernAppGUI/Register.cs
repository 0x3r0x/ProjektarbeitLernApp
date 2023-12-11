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
    public partial class Register : Form
    {
        private UserService userService;
        private DatabasePLAContext dbContext;
        private LearnProgressService learnProgressService;
        private MultipleChoiceSetService multipleChoiceSetService;

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

        private void btnShowLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new Login(dbContext);
            loginForm.Show();
            this.Hide();
        }

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
        }
    }
}
