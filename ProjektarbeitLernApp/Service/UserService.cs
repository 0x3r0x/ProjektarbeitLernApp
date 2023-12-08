using ProjektarbeitLernApp.Model.Auth;
using ProjektarbeitLernApp.PLAContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ProjektarbeitLernApp.Service
{
    /// <summary>
    /// Bietet Dienste zum Registrieren und Einloggen.
    /// Dieser Service interagiert mit der Datenbank, um Benutzer zu authentifizieren und neue Benutzer zu registrieren.
    /// </summary>
    public class UserService
    {
        private DatabasePLAContext dbContext {  get; set; }

        /// <summary>
        /// Initialisierung des UserService.
        /// Benötigt den Datenbankcontext als Übergabeparameter
        /// </summary>
        /// <param name="dbContext"></param>
        public UserService(DatabasePLAContext dbContext) {
            this.dbContext = dbContext;
        }


        public bool Register(User user)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Email == user.Email);
            if (findUser != null)
                return false;

            user.Password = Crypto.HashPassword(user.Password);

            dbContext.User.Add(user);
            dbContext.SaveChanges();
            return true;
        }

        public bool Login(User user)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Email == user.Email);
            if (findUser == null) 
                return false;

            var isPasswordCorrect = Crypto.VerifyHashedPassword(findUser.Password, user.Password);

            if (isPasswordCorrect)
                return true;
            return false;
        }

        public int GetUserId(User user)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Email.Equals(user.Email));
            if (findUser == null)
                return -1;

            return findUser.Id;
        }

        public User GetUser(User user)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Email.Equals(user.Email));
            return findUser;
        }

        public bool IsTeacher(User user)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Email == user.Email);
            if(findUser == null) 
                return false;

            if(findUser.Role == (int)Role.Teacher)
                return true;

            return false;
        }

        public bool IsStudent(User user)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Email == user.Email);
            if (findUser == null)
                return false;

            if (findUser.Role == (int)Role.Student)
                return true;

            return false;
        }
    }
}
