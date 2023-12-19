using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Microsoft.Win32.TaskScheduler.Task;

namespace ProjektarbeitLernApp.Service
{
    /// <summary>
    /// Verwaltet automatisierte Aufgaben mithilfe des Windows-Aufgabenplaners.
    /// Ermöglicht das Erstellen, Löschen und Abrufen geplanter Aufgaben, die mit der Lernanwendung verknüpft sind.
    /// </summary>
    public class RoutineService
    {
        private static string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string exePath = Path.Combine(exeDirectory, AppDomain.CurrentDomain.FriendlyName) + ".exe";
        private static string routinePrefix = "[ProjektarbeitLernApp] ";

        /// <summary>
        /// Löscht eine spezifische Routine basierend auf ihrem Namen.
        /// </summary>
        /// <param name="routineName">Name der zu löschenden Routine.</param>
        public void Delete(string routineName)
        {
            using (TaskService ts = new TaskService())
            {
                foreach (Task task in ts.AllTasks)
                {
                    if (task.Name.StartsWith(routineName, StringComparison.OrdinalIgnoreCase))
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

        /// <summary>
        /// Löscht alle Routinen, die mit dem vordefinierten Präfix beginnen.
        /// </summary>
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

        /// <summary>
        /// Ruft alle Routinen ab, die mit dem vordefinierten Präfix beginnen.
        /// </summary>
        /// <returns>Eine Liste von Tasks, die den Routinen entsprechen.</returns>
        public List<Task> GetAll()
        {
            try
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
            catch (Exception)
            {
                return null;
            }
        }

        /// Erstellt eine neue Routine mit einem gegebenen Namen und Startzeitpunkt.
        /// </summary>
        /// <param name="routineName">Name der neuen Routine.</param>
        /// <param name="startTime">Startzeit der Routine.</param>
        /// <returns>True, wenn die Routine erfolgreich erstellt wurde, sonst False.</returns>
        public bool Create(string routineName, DateTime startTime)
        {
            try
            {
                TaskService ts = new TaskService();
                TaskDefinition td = ts.NewTask();
                Trigger trigger = new DailyTrigger();
                trigger.StartBoundary = startTime; 
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
