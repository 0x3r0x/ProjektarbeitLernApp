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
    /// Bietet Dienste zum Registrieren, Einloggen und Editieren an.
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

        /// <summary>
        /// Speichert den übergebenen Benutzer in der Datenbank, falls nicht vorhanden
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Einen boolschen Wert, ob der Benutzer sich erfolgreich registriert hat</returns>
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

        /// <summary>
        /// Loggt den übergebenen Benutzer bei erfolgreicher authentifizierung ein.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Einen boolschen Wert, ob der Benutzer sich erfolgreich authenthifiziert hat</returns>
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

        /// <summary>
        /// Asynchrone Login Methode, damit der UI-Thread nicht geblockt wird
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Einen boolschen Wert, ob der Benutzer sich erfolgreich authenthifiziert hat</returns>
        public async Task<bool> LoginAsync(User user)
        {
            return await Task.Run(() => Login(user));
        }

        /// <summary>
        /// Alle Studenten zurückgeben
        /// </summary>
        /// <returns>Eine Liste mit allen Studenten</returns>
        public List<User> GetAllStudents()
        {
            return dbContext.User.Where(e => e.Role.Equals((int)Role.Student)).ToList();
        }

        /// <summary>
        /// UserID über E-Mail abfragen
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Gibt die UserId eines gegebenen Users zurück</returns>
        public int GetUserId(User user)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Email.Equals(user.Email));
            if (findUser == null)
                return -1;

            return findUser.Id;
        }

        /// <summary>
        /// E-Mail des Users editieren
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Gibt den User nach dem ändern zurück</returns>
        public User EditMail(User user)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Id.Equals(user.Id));
            findUser.Email = user.Email;
            dbContext.SaveChanges();
            return findUser;
        }

        /// <summary>
        /// User über die ID abfragen
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Gibt den User einer angegebenen ID zurück</returns>
        public User GetUserById(int userId)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Id.Equals(userId));
            return findUser;
        }

        /// <summary>
        /// Überprüft ob der User ein Lehrer ist
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolscher Wert ob der User ein Lehrer ist</returns>
        public bool IsTeacher(User user)
        {
            var findUser = dbContext.User.FirstOrDefault(e => e.Email == user.Email);
            if(findUser == null) 
                return false;

            if(findUser.Role == (int)Role.Teacher)
                return true;

            return false;
        }

        /// <summary>
        /// Überprüft ob der User ein Student ist
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolscher Wert ob der User ein Student ist</returns>
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
