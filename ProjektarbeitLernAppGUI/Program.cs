using ProjektarbeitLernApp.PLAContext;
using ProjektarbeitLernApp.Service;

namespace ProjektarbeitLernAppGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var dbContext = new DatabasePLAContext();

            //var userService = new UserService(dbContext);
            //var multipleChoiceSetService = new MultipleChoiceSetService(dbContext);
            //var statisticService = new StatisticService(dbContext);
            //var learnProgressService = new LearnProgressService(dbContext, statisticService);

            //Application.Run(new Form1());
            Application.Run(new Login(dbContext));
            //Application.Run(new Register(dbContext));

        }

        //private static void 
    }
}