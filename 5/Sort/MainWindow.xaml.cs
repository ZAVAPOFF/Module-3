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

namespace Sort
{
    public partial class MainWindow : Window
    {
        // Делегат для методов сортировки
        public delegate int[] SortMethod(int[] numbers);

        public MainWindow()
        {
            InitializeComponent();
        }

        // Сортировка пузырьком
        private int[] BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }

        // Быстрая сортировка
        private int[] QuickSort(int[] numbers)
        {
            if (numbers.Length <= 1) return numbers;
            int pivot = numbers[numbers.Length / 2];
            int[] less = numbers.Where(x => x < pivot).ToArray();
            int[] equal = numbers.Where(x => x == pivot).ToArray();
            int[] greater = numbers.Where(x => x > pivot).ToArray();
            return QuickSort(less).Concat(equal).Concat(QuickSort(greater)).ToArray();
        }

        // Обработчик события кнопки
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            int[] numbers = input.Split(',')
                                 .Select(n => int.Parse(n.Trim()))
                                 .ToArray();

            SortMethod sortMethod;

            // Выбор метода сортировки
            if (SortingMethodComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Content.ToString() == "Сортировка пузырьком")
                {
                    sortMethod = BubbleSort;
                }
                else
                {
                    sortMethod = QuickSort;
                }
            }
            else
            {
                MessageBox.Show("Выберите метод сортировки!");
                return;
            }

            // Сортировка и отображение результата
            int[] sortedNumbers = sortMethod(numbers);
            ResultTextBlock.Text = string.Join(", ", sortedNumbers);
        }
    }
}

