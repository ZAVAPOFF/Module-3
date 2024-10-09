using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Task
{
    public partial class MainWindow : Window
    {
        private List<TaskModel> tasks = new List<TaskModel>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskName = TaskNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(taskName))
            {
                MessageBox.Show("Введите имя задачи.");
                return;
            }

            Action<string> selectedDelegate = null;

            if (DelegateComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Уведомление":
                        selectedDelegate = Notify;
                        break;
                    case "Запись в журнал":
                        selectedDelegate = LogToFile;
                        break;
                }
            }

            TaskModel task = new TaskModel(taskName, selectedDelegate);
            tasks.Add(task);
            TaskListBox.Items.Add(taskName);
            TaskNameTextBox.Clear();
        }

        private void Notify(string taskName)
        {
            MessageBox.Show($"Уведомление: задача '{taskName}' выполнена!");
        }

        private void LogToFile(string taskName)
        {
            // Здесь можно добавить код для записи в файл
            MessageBox.Show($"Запись в журнал: задача '{taskName}' выполнена!");
        }
    }
}
