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
                new DataItem(DateTime.Now, "Meeting with team"),
                new DataItem(DateTime.Now.AddDays(-1), "Complete project report"),
                new DataItem(DateTime.Now.AddDays(2), "Plan vacation"),
                new DataItem(DateTime.Now.AddDays(-5), "Workshop on development"),
                new DataItem(DateTime.Now.AddDays(1), "Doctor appointment")
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
                string lowerKeyword = keyword.ToLower();
                filteredItems = filteredItems.Where(item => DataFilters.FilterByKeyword(item, lowerKeyword));
            }

            DataListBox.ItemsSource = filteredItems.ToList();
        }
    }
}

