using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task
{
    public partial class MainWindow : Window
    {
        private List<Action<string>> _delegates;

        public MainWindow()
        {
            InitializeComponent();
            _delegates = new List<Action<string>> { SendNotification, LogTask };
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskInput.Text;
            if (!string.IsNullOrEmpty(task))
            {
                TaskList.Items.Add(task);
                TaskInput.Clear();

                // Выберите делегата для выполнения задачи
                foreach (var del in _delegates)
                {
                    del(task);
                }
            }
        }

        private void SendNotification(string task)
        {
            MessageBox.Show($"Уведомление: Задача '{task}' добавлена.");
        }

        private void LogTask(string task)
        {
            // Здесь можно добавить код для записи задачи в журнал
            Console.WriteLine($"Задача '{task}' записана в журнал.");
        }
    }
}

