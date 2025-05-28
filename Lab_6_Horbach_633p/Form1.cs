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
            // �������� �������� ���
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // ������ �������
            dataGridView1.Columns.Add("work", "������");
            dataGridView1.Columns.Add("prev", "�������� ������");
            dataGridView1.Columns.Add("duration", "���������");
            dataGridView1.Columns.Add("people", "ʳ������ �����");

            // ��� (���������� ������ ���������)
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

            // ���������� DataGridView
            for (int i = 0; i < data.GetLength(0); i++)
            {
                dataGridView1.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
            }
            // ���������� ������� � textBox_count
            textBox_count.Text = data.GetLength(0).ToString();
        }

        private void button_pruklad1_Click(object sender, EventArgs e)
        {
            // �������� �������� ���
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // ������ �������
            dataGridView1.Columns.Add("work", "������");
            dataGridView1.Columns.Add("prev", "�������� ������");
            dataGridView1.Columns.Add("duration", "���������");
            dataGridView1.Columns.Add("people", "ʳ������ �����");

            // ��� (���������� ������ ���������)
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

            // ���������� DataGridView
            for (int i = 0; i < data.GetLength(0); i++)
            {
                dataGridView1.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
            }

            // ���������� ������� � textBox_count
            textBox_count.Text = data.GetLength(0).ToString();
        }

        private void button_pruklad_2_Click(object sender, EventArgs e)
        {
            // �������� �������� ���
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // ������ �������
            dataGridView1.Columns.Add("work", "������");
            dataGridView1.Columns.Add("prev", "�������� ������");
            dataGridView1.Columns.Add("duration", "���������");
            dataGridView1.Columns.Add("people", "ʳ������ �����");

            // ��� (���������� ������ ���������)
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

            // ���������� DataGridView
            for (int i = 0; i < data.GetLength(0); i++)
            {
                dataGridView1.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
            }

            // ���������� ������� � textBox_count
            textBox_count.Text = data.GetLength(0).ToString();
        }

        // ������ ��� ������� ��������� (����� 1�7)
        private void button_fount_critical_path_and_days_Click(object sender, EventArgs e)
        {
            // ���� 1: �������� ����� � �������
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

            // ���� 3�6: ���������� ��������
            Metods.ProjectScheduler scheduler = new Metods.ProjectScheduler(workItems);
            scheduler.CalculateSchedule();

            // ���� 7: ���������� ���������� �����
            var criticalPath = workItems
                                .Where(w => w.IsCritical)
                                .OrderBy(w => w.EarlyStart)
                                .Select(w => w.Id.ToString());

            // ��������� ���������� ����� (���� 9)
            textBox_critical_path.Text = string.Join(" - ", criticalPath);

            // ���� 4: ��������� ��������� ������
            int totalDuration = workItems.Max(w => w.EarlyFinish);
            textBox_days.Text = totalDuration.ToString();
        }


        private void button_protokol_Click(object sender, EventArgs e)
        {
            // ���������� ����� � DataGridView
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

            // ����������
            var scheduler = new Metods.ProjectScheduler(workItems);
            scheduler.CalculateSchedule();

            var report = new StringBuilder();
            report.AppendLine("������������ �������� ����������:");
            report.AppendLine("����� ���������� �����");
            report.AppendLine("��������� ����:");
            report.AppendLine("���������� ����� ��� ����:");

            foreach (var task in workItems.OrderBy(w => w.Id))
            {
                report.AppendLine($"������ {task.Id}:");
                report.AppendLine($"��������� ����: {task.Duration}");
                report.AppendLine($"����� �����: {task.EarlyStart}");
                report.AppendLine($"����� ����: {task.EarlyFinish}");
            }

            int projectDuration = workItems.Max(w => w.EarlyFinish);
            report.AppendLine($"��������� ������: {projectDuration}");
            report.AppendLine();
            report.AppendLine("���������� ���� ��� ����:");

            foreach (var task in workItems.OrderByDescending(w => w.Id))
            {
                report.AppendLine($"������ {task.Id}:");
                report.AppendLine($"ϳ��� ����: {task.LateFinish}");
                report.AppendLine($"ϳ��� �����: {task.LateStart}");
                report.AppendLine($"������ ����: {task.TotalFloat}");
            }

            report.AppendLine();
            report.AppendLine("���������� ��������� �������� ������� ����:");

            foreach (var task in workItems.OrderBy(w => w.Id))
            {
                string mark = task.IsCritical ? "(K) " : "";
                report.AppendLine($"{mark}������ {task.Id}:");
                report.AppendLine($"ʳ������ �����: {task.PeopleRequired}");
                report.AppendLine($"����� �����: {task.EarlyStart}");
                report.AppendLine($"��������� ����: {task.Duration}");
                report.AppendLine($"����� ����: {task.EarlyFinish}");
                report.AppendLine($"ϳ��� �����: {task.LateStart}");
                report.AppendLine($"������ ����: {task.TotalFloat}");
                report.AppendLine($"ϳ��� ����: {task.LateFinish}");
            }

            var criticalPath = string.Join("-", workItems.Where(w => w.IsCritical).OrderBy(w => w.EarlyStart).Select(w => w.Id));
            report.AppendLine($"��������� ����: {criticalPath}");

            // ���������� � ��������� ����
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "������� ����� (*.txt)|*.txt";
            saveFileDialog.Title = "�������� �������� � ����";
            saveFileDialog.FileName = "protokol.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, report.ToString());
                MessageBox.Show("�������� ������ ��������� � ����:\n" + saveFileDialog.FileName, "����");
            }
        }

    }
}
