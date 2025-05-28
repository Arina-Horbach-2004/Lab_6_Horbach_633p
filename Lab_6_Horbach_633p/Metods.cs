using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Horbach_633p
{
    internal class Metods
    {
        public class WorkItem
        {
            public int Id { get; set; }                         // Номер роботи
            public List<int> Predecessors { get; set; } = new(); // Попередні роботи
            public int Duration { get; set; }                   // Тривалість роботи
            public int PeopleRequired { get; set; }             // Кількість людей для виконання

            public int EarlyStart { get; set; }                 // Ранній старт
            public int EarlyFinish => EarlyStart + Duration;    // Ранній фініш
            public int LateStart { get; set; }                  // Пізній старт
            public int LateFinish => LateStart + Duration;      // Пізній фініш

            public int TotalFloat => LateStart - EarlyStart;    // Резерв часу
            public bool IsCritical => TotalFloat == 0;          // Ознака критичної роботи
        }

        public class ProjectScheduler
        {
            private Dictionary<int, WorkItem> tasks;

            public ProjectScheduler(List<WorkItem> workItems)
            {
                tasks = workItems.ToDictionary(w => w.Id);
            }

            // Крок 3: Розрахунок ранніх дат
            public void CalculateSchedule()
            {
                // Крок 3: Розрахунок раннього старту та фінішу
                foreach (var task in tasks.Values.OrderBy(t => t.Id))
                {
                    if (task.Predecessors.Count == 0)
                    {
                        task.EarlyStart = 0; // Якщо немає попередників — початок у 0
                    }
                    else
                    {
                        // Макс. ранній фініш попередників = ранній старт поточної
                        task.EarlyStart = task.Predecessors.Select(p => tasks[p].EarlyFinish).Max();
                    }
                }

                // Крок 4: Визначення тривалості проєкту
                int projectDuration = tasks.Values.Select(t => t.EarlyFinish).Max();

                // Крок 5: Розрахунок пізніх дат
                foreach (var task in tasks.Values.OrderByDescending(t => t.Id))
                {
                    // Знайти наступні роботи
                    var successors = tasks.Values.Where(t => t.Predecessors.Contains(task.Id)).ToList();

                    if (successors.Count == 0)
                    {
                        // Якщо немає наступників — пізній старт = кінець проєкту - тривалість
                        task.LateStart = projectDuration - task.Duration;
                    }
                    else
                    {
                        // Мін. пізній старт наступників - тривалість = пізній старт поточної
                        task.LateStart = successors.Select(s => s.LateStart).Min() - task.Duration;
                    }
                }
            }
        }
    }
}