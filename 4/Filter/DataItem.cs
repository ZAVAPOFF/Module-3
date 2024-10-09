using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public class DataItem
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public DataItem(DateTime date, string description)
        {
            Date = date;
            Description = description;
        }
    }
}
