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

namespace Filter
{
    public partial class MainWindow : Window
    {
        private List<DataItem> _dataItems;

        public MainWindow()
        {
            InitializeComponent();

            // Пример данных
            _dataItems = new List<DataItem>
            {
                new DataItem(DateTime.Now, "Встреча с друзьями"),
                new DataItem(DateTime.Now.AddDays(-1), "Поход к врачу"),
                new DataItem(DateTime.Now.AddDays(2), "Завершение проекта"),
                new DataItem(DateTime.Now.AddDays(-5), "Просмотр сериала"),
                new DataItem(DateTime.Now.AddDays(1), "Просмотр фильма")
            };

            DataListBox.ItemsSource = _dataItems;
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = DatePicker.SelectedDate;
            string keyword = KeywordTextBox.Text;

            // Логика фильтрации
            IEnumerable<DataItem> filteredItems = _dataItems;

            // Применение фильтра по дате
            if (selectedDate.HasValue)
            {
                filteredItems = filteredItems.Where(item => DataFilters.FilterByDate(item, selectedDate.Value));
            }

            // Применение фильтра по ключевому слову
            if (!string.IsNullOrEmpty(keyword))
            {
                filteredItems = filteredItems.Where(item => DataFilters.FilterByKeyword(item, keyword));
            }

            DataListBox.ItemsSource = filteredItems.ToList();
        }
    }
}

