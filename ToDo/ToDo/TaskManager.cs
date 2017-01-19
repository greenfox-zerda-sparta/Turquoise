using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication
{
    class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        public TaskManager()
        {
            ReadFromFile();
        }

        public void PrintInstructions()
        {
            Console.WriteLine(System.IO.File.ReadAllText(@"instructions.txt"));
        }

        public void AddTask(string taskname, string status)
        {
            tasks.Add(new Task(taskname, status));
        }

        public void CompleteTask(string taskname)
        {
            int index;
            if (int.TryParse(taskname, out index))
            {
                if (index <= tasks.Count)
                {
                    tasks.ElementAt(index - 1).Status = "X";
                }
                else
                {
                    Console.Error.WriteLine("\nUnable to complete task: Index is out of bound!\n");
                }
            }
            else
            {
                if (tasks.Find(x => x.TaskName == taskname) != null)
                {
                    tasks.ElementAt(tasks.FindIndex(x => x.TaskName == taskname)).Status = "X";
                }
                else
                {
                    Console.Error.WriteLine("\nUnable to complete task: Task isn't found!\n");
                }
            }
        }

        public void RemoveTask(string taskname)
        {
            int index;
            if (int.TryParse(taskname, out index))
            {
                if (index <= tasks.Count)
                {
                    tasks.RemoveAt(index - 1);
                }
                else
                {
                    Console.Error.WriteLine("\nUnable to remove task: Index is out of bound!\n");
                }
            }
            else
            {
                if (tasks.Find(x => x.TaskName == taskname) != null)
                {
                    tasks.RemoveAt(tasks.FindIndex(x => x.TaskName == taskname));
                }
                else
                {
                    Console.Error.WriteLine("\nUnable to remove task: Task isn't found!\n");
                }
            }
        }

        public void ListTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No todos for today! :)");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine(i + 1 + " - [{0}] - " + tasks.ElementAt(i).TaskName, tasks.ElementAt(i).Status);
                }
            }
        }

        public void WriteToFile()
        {
            string[] tasks_to_file = (tasks.Select(x => x.TaskName)).ToArray();
            System.IO.File.WriteAllLines(@"tasks.txt", tasks_to_file);
            string[] status_to_file = (tasks.Select(x => x.Status)).ToArray();
            System.IO.File.WriteAllLines(@"status.txt", status_to_file);
        }

        public void ReadFromFile()
        {
            string[] tasks_from_file = System.IO.File.ReadAllLines(@"tasks.txt");
            string[] status_from_file = System.IO.File.ReadAllLines(@"status.txt");
            for (int i = 0; i < tasks_from_file.Length; i++)
            {
                AddTask(tasks_from_file[i], status_from_file[i]);
            }
        }
    }
}
