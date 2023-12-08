using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Microsoft.Win32.TaskScheduler.Task;

namespace ProjektarbeitLernApp.Service
{
    public class RoutineService
    {
        private static string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string exePath = Path.Combine(exeDirectory, AppDomain.CurrentDomain.FriendlyName) + ".exe";
        private static string routinePrefix = "[ProjektarbeitLernApp] ";

        public void Delete(string routineName)
        {
            using (TaskService ts = new TaskService())
            {
                foreach (Task task in ts.AllTasks)
                {
                    if (task.Name.StartsWith(routinePrefix + routineName, StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            ts.RootFolder.DeleteTask(task.Name);
                            Console.WriteLine($"Task '{task.Name}' wurde gelöscht.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fehler beim Löschen von Task '{task.Name}': {ex.Message}");
                        }
                    }
                }
            }
        }

        public void DeleteAll()
        {
            using (TaskService ts = new TaskService())
            {
                foreach (Task task in ts.AllTasks)
                {
                    if (task.Name.StartsWith(routinePrefix, StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            ts.RootFolder.DeleteTask(task.Name);
                            Console.WriteLine($"Task '{task.Name}' wurde gelöscht.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fehler beim Löschen von Task '{task.Name}': {ex.Message}");
                        }
                    }
                }
            }
        }

        public List<Task> GetAll()
        {
            List<Task> projectWorkTasks = new List<Task>();

            using (TaskService ts = new TaskService())
            {
                foreach (Task task in ts.AllTasks)
                {
                    if (task.Name.StartsWith(routinePrefix, StringComparison.OrdinalIgnoreCase))
                    {
                        projectWorkTasks.Add(task);
                    }
                }
            }

            return projectWorkTasks;
        }

        public bool Create(string routineName, DateTime startTime)
        {
            try
            {
                TaskService ts = new TaskService();
                TaskDefinition td = ts.NewTask();
                Trigger trigger = new DailyTrigger();
                trigger.StartBoundary = startTime; // new DateTime(2023, 12, 8, 9, 57, 00);
                td.Triggers.Add(trigger);
                td.Actions.Add(new ExecAction(exePath, null, null));
                ts.RootFolder.RegisterTaskDefinition(routinePrefix + routineName, td);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



    }
}
