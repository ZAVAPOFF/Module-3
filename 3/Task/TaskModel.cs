using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class TaskModel
    {
        public string Name { get; set; }
        public Action<string> TaskDelegate { get; set; }

        public TaskModel(string name, Action<string> taskDelegate)
        {
            Name = name;
            TaskDelegate = taskDelegate;
        }

        public void Execute()
        {
            TaskDelegate?.Invoke(Name);
        }
    }

}
