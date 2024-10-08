using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Tasks
    {
        public string Title { get; set; }
        public Action<Tasks> DelegateAction { get; set; }

        public void Execute()
        {
            DelegateAction?.Invoke(this);
        }
    }

}
