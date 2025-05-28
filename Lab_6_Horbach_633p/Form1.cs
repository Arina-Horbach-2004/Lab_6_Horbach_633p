using System.Text;
using System.IO;


namespace Lab_6_Horbach_633p
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_variant_Click(object sender, EventArgs e)
        {
            // Очистити попередні дані
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Додати колонки
            dataGridView1.Columns.Add("work", "Робота");
            dataGridView1.Columns.Add("prev", "Попередні роботи");
            dataGridView1.Columns.Add("duration", "Тривалість");
            dataGridView1.Columns.Add("people", "Кількість людей");

            // Дані (зображення вручну прочитано)
            string[,] data = new string[,]
            {
        { "1", "-", "9", "3" },
        { "2", "-", "7", "4" },
        { "3", "-", "13", "2" },
        { "4", "1", "8", "3" },
        { "5", "2", "6", "2" },
        { "6", "2", "10", "3" },
        { "7", "3", "9", "3" },
        { "8", "4,5", "13", "5" },
        { "9", "6,7", "9", "2" },
        { "10", "6,7,8", "11", "4" },
        { "11", "9", "9", "6" }
            };

            // Заповнення DataGridView
            for (int i = 0; i < data.GetLength(0); i++)
            {
                dataGridView1.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
            }
            // Встановити кількість у textBox_count
            textBox_count.Text = data.GetLength(0).ToString();
        }

        private void button_pruklad1_Click(object sender, EventArgs e)
        {
            // Очистити попередні дані
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Додати колонки
            dataGridView1.Columns.Add("work", "Робота");
            dataGridView1.Columns.Add("prev", "Попередні роботи");
            dataGridView1.Columns.Add("duration", "Тривалість");
            dataGridView1.Columns.Add("people", "Кількість людей");

            // Дані (зображення вручну прочитано)
            string[,] data = new string[,]
            {
        { "1", "-", "5", "2" },
        { "2", "1", "8", "3" },
        { "3", "1", "3", "2" },
        { "4", "1", "6", "2" },
        { "5", "2", "7", "3" },
        { "6", "2,3", "6", "2" },
        { "7", "4,5,6", "4", "2" },
            };

            // Заповнення DataGridView
            for (int i = 0; i < data.GetLength(0); i++)
            {
                dataGridView1.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
            }

            // Встановити кількість у textBox_count
            textBox_count.Text = data.GetLength(0).ToString();
        }

        private void button_pruklad_2_Click(object sender, EventArgs e)
        {
            // Очистити попередні дані
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Додати колонки
            dataGridView1.Columns.Add("work", "Робота");
            dataGridView1.Columns.Add("prev", "Попередні роботи");
            dataGridView1.Columns.Add("duration", "Тривалість");
            dataGridView1.Columns.Add("people", "Кількість людей");

            // Дані (зображення вручну прочитано)
            string[,] data = new string[,]
            {
        { "1", "-", "3", "2" },
        { "2", "1", "4", "3" },
        { "3", "1", "2", "4" },
        { "4", "2", "5", "3" },
        { "5", "3", "1", "2" },
        { "6", "3", "2", "3" },
        { "7", "4,5", "4", "2" },
        { "8", "6,7", "3", "2", }
            };

            // Заповнення DataGridView
            for (int i = 0; i < data.GetLength(0); i++)
            {
                dataGridView1.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
            }

            // Встановити кількість у textBox_count
            textBox_count.Text = data.GetLength(0).ToString();
        }

        // Кнопка для запуску обчислень (кроки 1–7)
        private void button_fount_critical_path_and_days_Click(object sender, EventArgs e)
        {
            // Крок 1: Уведення даних з таблиці
            List<Metods.WorkItem> workItems = new List<Metods.WorkItem>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int id = int.Parse(row.Cells[0].Value.ToString());
                string predStr = row.Cells[1].Value.ToString();
                int duration = int.Parse(row.Cells[2].Value.ToString());
                int people = int.Parse(row.Cells[3].Value.ToString());

                List<int> predecessors = new List<int>();
                if (predStr != "-")
                {
                    predecessors = predStr.Split(',')
                                          .Select(s => int.Parse(s.Trim()))
                                          .ToList();
                }

                workItems.Add(new Metods.WorkItem
                {
                    Id = id,
                    Predecessors = predecessors,
                    Duration = duration,
                    PeopleRequired = people
                });
            }

            // Крок 3–6: Розрахунок розкладу
            Metods.ProjectScheduler scheduler = new Metods.ProjectScheduler(workItems);
            scheduler.CalculateSchedule();

            // Крок 7: Визначення критичного шляху
            var criticalPath = workItems
                                .Where(w => w.IsCritical)
                                .OrderBy(w => w.EarlyStart)
                                .Select(w => w.Id.ToString());

            // Виведення критичного шляху (крок 9)
            textBox_critical_path.Text = string.Join(" - ", criticalPath);

            // Крок 4: Виведення тривалості проєкту
            int totalDuration = workItems.Max(w => w.EarlyFinish);
            textBox_days.Text = totalDuration.ToString();
        }


        private void button_protokol_Click(object sender, EventArgs e)
        {
            // Зчитування даних з DataGridView
            List<Metods.WorkItem> workItems = new List<Metods.WorkItem>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var item = new Metods.WorkItem
                {
                    Id = int.Parse(row.Cells[0].Value.ToString()),
                    Duration = int.Parse(row.Cells[2].Value.ToString()),
                    PeopleRequired = int.Parse(row.Cells[3].Value.ToString())
                };

                string prev = row.Cells[1].Value.ToString();
                if (prev != "-" && !string.IsNullOrWhiteSpace(prev))
                {
                    item.Predecessors = prev.Split(',').Select(p => int.Parse(p.Trim())).ToList();
                }

                workItems.Add(item);
            }

            // Розрахунок
            var scheduler = new Metods.ProjectScheduler(workItems);
            scheduler.CalculateSchedule();

            var report = new StringBuilder();
            report.AppendLine("Згенерований протокол обчислення:");
            report.AppendLine("Пошук критичного шляху");
            report.AppendLine("виконання робіт:");
            report.AppendLine("Розрахунок ранніх дат робіт:");

            foreach (var task in workItems.OrderBy(w => w.Id))
            {
                report.AppendLine($"Робота {task.Id}:");
                report.AppendLine($"Тривалість робіт: {task.Duration}");
                report.AppendLine($"Ранній старт: {task.EarlyStart}");
                report.AppendLine($"Ранній фініш: {task.EarlyFinish}");
            }

            int projectDuration = workItems.Max(w => w.EarlyFinish);
            report.AppendLine($"Тривалість проєкту: {projectDuration}");
            report.AppendLine();
            report.AppendLine("Розрахунок пізніх дат робіт:");

            foreach (var task in workItems.OrderByDescending(w => w.Id))
            {
                report.AppendLine($"Робота {task.Id}:");
                report.AppendLine($"Пізній фініш: {task.LateFinish}");
                report.AppendLine($"Пізній старт: {task.LateStart}");
                report.AppendLine($"Резерв часу: {task.TotalFloat}");
            }

            report.AppendLine();
            report.AppendLine("Розраховані параметри сіткового графіка робіт:");

            foreach (var task in workItems.OrderBy(w => w.Id))
            {
                string mark = task.IsCritical ? "(K) " : "";
                report.AppendLine($"{mark}Робота {task.Id}:");
                report.AppendLine($"Кількість людей: {task.PeopleRequired}");
                report.AppendLine($"Ранній старт: {task.EarlyStart}");
                report.AppendLine($"Тривалість робіт: {task.Duration}");
                report.AppendLine($"Ранній фініш: {task.EarlyFinish}");
                report.AppendLine($"Пізній старт: {task.LateStart}");
                report.AppendLine($"Резерв часу: {task.TotalFloat}");
                report.AppendLine($"Пізній фініш: {task.LateFinish}");
            }

            var criticalPath = string.Join("-", workItems.Where(w => w.IsCritical).OrderBy(w => w.EarlyStart).Select(w => w.Id));
            report.AppendLine($"Критичний шлях: {criticalPath}");

            // Збереження в текстовий файл
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt";
            saveFileDialog.Title = "Зберегти протокол у файл";
            saveFileDialog.FileName = "protokol.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, report.ToString());
                MessageBox.Show("Протокол успішно збережено у файл:\n" + saveFileDialog.FileName, "Успіх");
            }
        }

    }
}
