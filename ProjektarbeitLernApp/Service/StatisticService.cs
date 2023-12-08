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
    public class StatisticService
    {

        private DatabasePLAContext dbContext;

        public StatisticService(DatabasePLAContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Insert(Statistic statistic)
        {
            if (statistic == null)
                return;

            dbContext.Statistic.Add(statistic);
            dbContext.SaveChanges();
        }

        public int GetAllKnown(User user)
        {
            return dbContext.Statistic.Count(e => e.Student_Id.Equals(user.Id) && e.WasKnown.Equals(true));
        }

        public int GetAllNotKnown(User user)
        {
            return dbContext.Statistic.Count(e => e.Student_Id.Equals(user.Id) && e.WasKnown.Equals(false));
        }

        public double[] GetLearnedPerDay(User user)
        {
            var res = dbContext.Statistic.Where(e => e.Student_Id.Equals(user.Id)).GroupBy(e => e.DateTime.Date).Select(g => (double)g.Count()).ToArray();
            return res;
        }

        public string[] GetDays(User user)
        {
            var res = dbContext.Statistic.Where(e => e.Student_Id.Equals(user.Id)).Select(e => e.DateTime.Date).Distinct().Select(e => e.ToString("dd.MM.")).ToArray();
            return res;
        }

        //TODO: - beantwortete Fragen von heute
        //      - gewusst / nicht gewusst von heute
        //      - gesamt gewusst / nicht gewusst
        //      - prüfungsreife
    }
}
