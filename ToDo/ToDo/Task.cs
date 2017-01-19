using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication
{
    class Task
    {
        public Task(string taskname, string status)
        {
            this.TaskName = taskname;
            this.Status = status;
        }
        public string TaskName { set; get; }
        public string Status { set; get; }
    }
}
