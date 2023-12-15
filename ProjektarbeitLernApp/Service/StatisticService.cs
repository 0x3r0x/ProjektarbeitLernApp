using ProjektarbeitLernApp.Model.Auth;
using ProjektarbeitLernApp.Model.LearnApp;
using ProjektarbeitLernApp.PLAContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Service
{
    /// <summary>
    /// Es handelt sich um einen Dienst, welcher die Statistiken der Schüler wiedergibt und Statistiken in die Datenbank speichert.
    /// </summary>
    public class StatisticService
    {

        private DatabasePLAContext dbContext;

        /// <summary>
        /// Benötigt den Datenbankcontext.
        /// </summary>
        /// <param name="dbContext"></param>
        public StatisticService(DatabasePLAContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Fügt eine neue Statistik in der Datenbank hinzu.
        /// </summary>
        /// <param name="statistic"></param>
        public void Insert(Statistic statistic)
        {
            if (statistic == null)
                return;

            dbContext.Statistic.Add(statistic);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Suche alle richtig beantworteten Fragen eines Schülers aus der Datenbank
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Gibt die Anzahl an richtig beantworteten Fragen zurück</returns>
        public int GetAllKnown(User user)
        {
            return dbContext.Statistic.Count(e => e.Student_Id.Equals(user.Id) && e.WasKnown.Equals(true));
        }

        /// <summary>
        /// Suche alle falsch beantworteten Fragen eines Schülers aus der Datenbank
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Gibt die Anzahl an falsch beantworteten Fragen zurück</returns>
        public int GetAllNotKnown(User user)
        {
            return dbContext.Statistic.Count(e => e.Student_Id.Equals(user.Id) && e.WasKnown.Equals(false));
        }

        /// <summary>
        /// Fasse die Anzahl an beantworteten Fragen der jeweiligen Tage, an dem der Schüler gelernt hat, aus der Datenbank
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Gibt ein Array zurück mit den gelernten Fragen</returns>
        public double[] GetLearnedPerDay(User user)
        {
            var res = dbContext.Statistic.Where(e => e.Student_Id.Equals(user.Id)).GroupBy(e => e.DateTime.Date).Select(g => (double)g.Count()).ToArray();
            return res;
        }

        /// <summary>
        /// Suche die jeweiligen Tage, an dem der Schüler gelernt hat, aus der Datenbank
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Gibt ein Array zurück mit den Tagen an denen der Schüler gelernt hat</returns>
        public string[] GetDays(User user)
        {
            var res = dbContext.Statistic.Where(e => e.Student_Id.Equals(user.Id)).Select(e => e.DateTime.Date).Distinct().Select(e => e.ToString("dd.MM.")).ToArray();
            return res;
        }

    }
}
