using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public static class DataFilters
    {
        // Фильтр по дате
        public static bool FilterByDate(DataItem item, DateTime date)
        {
            return item.Date.Date == date.Date;
        }

        // Фильтр по ключевому слову
        public static bool FilterByKeyword(DataItem item, string keyword)
        {
            return item.Description.Contains(keyword);
        }
    }
}
