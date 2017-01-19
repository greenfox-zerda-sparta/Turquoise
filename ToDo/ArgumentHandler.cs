using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication
{
    class ArgumentHandler
    {
        private TaskManager taskmanager = new TaskManager();

        public ArgumentHandler(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    taskmanager.PrintInstructions();
                    break;
                case 1:
                    if (args[0] == "-l")
                    {
                        taskmanager.ListTasks();
                    }
                    else if (args[0] == "-a")
                    {
                        Console.Error.WriteLine("\nUnable to add task: No task provided!\n");
                    }
                    else if (args[0] == "-r")
                    {
                        Console.Error.WriteLine("\nUnable to remove task: No index or task provided!\n");
                    }
                    else if (args[0] == "-c")
                    {
                        Console.Error.WriteLine("\nUnable to complete task: No index or task provided!\n");
                    }
                    else
                    {
                        Console.Error.WriteLine("\nUnsupported argument provided! Try again!\n");
                        taskmanager.PrintInstructions();
                    }
                    break;
                case 2:
                    if (args[0] == "-a")
                    {
                        taskmanager.AddTask(args[1], " ");
                        taskmanager.WriteToFile();
                    }
                    else if (args[0] == "-r")
                    {
                        taskmanager.RemoveTask(args[1]);
                        taskmanager.WriteToFile();
                    }
                    else if (args[0] == "-c")
                    {
                        taskmanager.CompleteTask(args[1]);
                        taskmanager.WriteToFile();
                    }
                    else
                    {
                        Console.Error.WriteLine("\nUnsupported argument provided! Try again!\n");
                        taskmanager.PrintInstructions();
                    }
                    break;
            }
        }
    }
}
