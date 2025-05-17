namespace Lab_6_Horbach_633p
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            count_work_label = new Label();
            textBox_count = new TextBox();
            dataGridView1 = new DataGridView();
            textBox_critical_path = new TextBox();
            textBox_days = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button_fount_critical_path_and_days = new Button();
            button_pruklad1 = new Button();
            button_pruklad_2 = new Button();
            button_variant = new Button();
            button_protokol = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // count_work_label
            // 
            count_work_label.AutoSize = true;
            count_work_label.Location = new Point(12, 53);
            count_work_label.Name = "count_work_label";
            count_work_label.Size = new Size(114, 20);
            count_work_label.TabIndex = 0;
            count_work_label.Text = "Кількість робіт:";
            // 
            // textBox_count
            // 
            textBox_count.Location = new Point(132, 53);
            textBox_count.Name = "textBox_count";
            textBox_count.Size = new Size(125, 27);
            textBox_count.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 109);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(550, 493);
            dataGridView1.TabIndex = 2;
            // 
            // textBox_critical_path
            // 
            textBox_critical_path.Location = new Point(603, 109);
            textBox_critical_path.Name = "textBox_critical_path";
            textBox_critical_path.ReadOnly = true;
            textBox_critical_path.Size = new Size(259, 27);
            textBox_critical_path.TabIndex = 3;
            // 
            // textBox_days
            // 
            textBox_days.Location = new Point(709, 167);
            textBox_days.Name = "textBox_days";
            textBox_days.ReadOnly = true;
            textBox_days.Size = new Size(153, 27);
            textBox_days.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(603, 86);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 5;
            label1.Text = "Критичний шлях:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(603, 174);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 6;
            label2.Text = "Тривалість:";
            // 
            // button_fount_critical_path_and_days
            // 
            button_fount_critical_path_and_days.Location = new Point(613, 222);
            button_fount_critical_path_and_days.Name = "button_fount_critical_path_and_days";
            button_fount_critical_path_and_days.Size = new Size(249, 73);
            button_fount_critical_path_and_days.TabIndex = 7;
            button_fount_critical_path_and_days.Text = "Знайти критичний шлях та тривалість";
            button_fount_critical_path_and_days.UseVisualStyleBackColor = true;
            button_fount_critical_path_and_days.Click += button_fount_critical_path_and_days_Click;
            // 
            // button_pruklad1
            // 
            button_pruklad1.Location = new Point(613, 311);
            button_pruklad1.Name = "button_pruklad1";
            button_pruklad1.Size = new Size(249, 41);
            button_pruklad1.TabIndex = 8;
            button_pruklad1.Text = "Приклад 1";
            button_pruklad1.UseVisualStyleBackColor = true;
            button_pruklad1.Click += button_pruklad1_Click;
            // 
            // button_pruklad_2
            // 
            button_pruklad_2.Location = new Point(613, 377);
            button_pruklad_2.Name = "button_pruklad_2";
            button_pruklad_2.Size = new Size(249, 41);
            button_pruklad_2.TabIndex = 9;
            button_pruklad_2.Text = "Приклад 2";
            button_pruklad_2.UseVisualStyleBackColor = true;
            button_pruklad_2.Click += button_pruklad_2_Click;
            // 
            // button_variant
            // 
            button_variant.Location = new Point(613, 444);
            button_variant.Name = "button_variant";
            button_variant.Size = new Size(249, 41);
            button_variant.TabIndex = 10;
            button_variant.Text = "Варіант №5";
            button_variant.UseVisualStyleBackColor = true;
            button_variant.Click += button_variant_Click;
            // 
            // button_protokol
            // 
            button_protokol.Location = new Point(613, 539);
            button_protokol.Name = "button_protokol";
            button_protokol.Size = new Size(249, 41);
            button_protokol.TabIndex = 12;
            button_protokol.Text = "Протокол обчислення";
            button_protokol.UseVisualStyleBackColor = true;
            button_protokol.Click += button_protokol_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 614);
            Controls.Add(button_protokol);
            Controls.Add(button_variant);
            Controls.Add(button_pruklad_2);
            Controls.Add(button_pruklad1);
            Controls.Add(button_fount_critical_path_and_days);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_days);
            Controls.Add(textBox_critical_path);
            Controls.Add(dataGridView1);
            Controls.Add(textBox_count);
            Controls.Add(count_work_label);
            Name = "Form1";
            Text = "Lab_6_Horbach_633p";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label count_work_label;
        private TextBox textBox_count;
        private DataGridView dataGridView1;
        private TextBox textBox_critical_path;
        private TextBox textBox_days;
        private Label label1;
        private Label label2;
        private Button button_fount_critical_path_and_days;
        private Button button_pruklad1;
        private Button button_pruklad_2;
        private Button button_variant;
        private Button button_protokol;
    }
}
