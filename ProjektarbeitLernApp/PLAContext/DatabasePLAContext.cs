using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("Database");

            optionsBuilder.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 4, 28)));
        }

    }
}
