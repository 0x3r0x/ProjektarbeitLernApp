using Microsoft.EntityFrameworkCore;
using ProjektarbeitLernApp.Model.Auth;
using ProjektarbeitLernApp.Model.LearnApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.PLAContext
{
    public class DatabasePLAContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<MultipleChoiceSet> MultipleChoiceSet { get; set; }
        public DbSet<LearnProgress> LearnProgress { get; set; }
        public DbSet<ExamSimulation> ExamSimulation { get; set; }
        public DbSet<Statistic> Statistic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=projektlernapp;User=root;Password=;",
                                    new MariaDbServerVersion(new Version(10, 4, 28)));
        }

    }
}
