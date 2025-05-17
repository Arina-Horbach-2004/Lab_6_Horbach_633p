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
            public int Id { get; set; }
            public List<int> Predecessors { get; set; } = new List<int>();
            public int Duration { get; set; }
            public int PeopleRequired { get; set; }

            public int EarlyStart { get; set; }
            public int EarlyFinish => EarlyStart + Duration;

            public int LateStart { get; set; }
            public int LateFinish => LateStart + Duration;

            public int TotalFloat => LateStart - EarlyStart;

            public bool IsCritical => TotalFloat == 0;
        }

        public class ProjectScheduler
        {
            private Dictionary<int, WorkItem> tasks;

            public ProjectScheduler(List<WorkItem> workItems)
            {
                tasks = workItems.ToDictionary(w => w.Id);
            }

            public void CalculateSchedule()
            {
                foreach (var task in tasks.Values.OrderBy(t => t.Id))
                {
                    if (task.Predecessors.Count == 0)
                    {
                        task.EarlyStart = 0;
                    }
                    else
                    {
                        task.EarlyStart = task.Predecessors.Select(p => tasks[p].EarlyFinish).Max();
                    }
                }

                int projectDuration = tasks.Values.Select(t => t.EarlyFinish).Max();

                foreach (var task in tasks.Values.OrderByDescending(t => t.Id))
                {
                    var successors = tasks.Values.Where(t => t.Predecessors.Contains(task.Id)).ToList();

                    if (successors.Count == 0)
                    {
                        task.LateStart = projectDuration - task.Duration;
                    }
                    else
                    {
                        task.LateStart = successors.Select(s => s.LateStart).Min() - task.Duration;
                    }
                }
            }
        }
    }
}
//public void PrintSchedule()
//{
//    Console.WriteLine($"\nProject Duration: {tasks.Values.Max(t => t.EarlyFinish)} days");
//    Console.WriteLine("Critical Path: " + string.Join(" - ",
//        tasks.Values
//             .Where(t => t.IsCritical)
//             .OrderBy(t => t.EarlyStart)
//             .Select(t => $"Task{t.Id}")));
//}