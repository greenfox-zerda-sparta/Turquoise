using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace SmartHomeUI
{
    class HistViewModel : INotifyPropertyChanged
    {
        private string newTask;
        private int selectedShoppingListIndex, selectedDailyTaskIndex, selectedJaneTaskIndex, selectedJoeTaskIndex, selectedTaskListNameIndex;
        private ObservableCollection<string> taskListNames = new ObservableCollection<string>() { "Shopping List", "Daily Task", "Jane's Task", "Joe's Task" };
        private ObservableCollection<Task> shoppingList = new ObservableCollection<Task>();
        private ObservableCollection<Task> dailyTasks = new ObservableCollection<Task>();
        private ObservableCollection<Task> janeToDo = new ObservableCollection<Task>();
        private ObservableCollection<Task> joeToDo = new ObservableCollection<Task>();

        public ICommand RemoveFromShoppingListCommand { get; set; }
        public ICommand RemoveFromDailyTasksCommand { get; set; }
        public ICommand RemoveFromJaneToDoCommand { get; set; }
        public ICommand RemoveFromJoeToDoCommand { get; set; }
        public ICommand AddTaskCommand { get; set; }

        public ObservableCollection<string> TaskListNames
        {
            get { return taskListNames; }
            set { taskListNames = value; RaisePropertyChanged("TaskListNames"); }
        }

        public ObservableCollection<Task> ShoppingList
        {
            get { return shoppingList; }
            set { shoppingList = value; RaisePropertyChanged("ShoppingList"); }
        }

        public ObservableCollection<Task> DailyTasks
        {
            get { return dailyTasks; }
            set { dailyTasks = value; RaisePropertyChanged("DailyTasks"); }
        }

        public ObservableCollection<Task> JaneToDo
        {
            get { return janeToDo; }
            set { janeToDo = value; RaisePropertyChanged("JaneToDo"); }
        }

        public ObservableCollection<Task> JoeToDo
        {
            get { return joeToDo; }
            set { joeToDo = value; RaisePropertyChanged("JoeToDo"); }
        }

        public int SelectedShoppingListIndex
        {
            get { return selectedShoppingListIndex; }
            set { selectedShoppingListIndex = value; RaisePropertyChanged("SelectedShoppingListIndex"); }
        }

        public int SelectedDailyTaskIndex
        {
            get { return selectedDailyTaskIndex; }
            set { selectedDailyTaskIndex = value; RaisePropertyChanged("SelectedDailyTaskIndex"); }
        }

        public int SelectedJaneTaskIndex
        {
            get { return selectedJaneTaskIndex; }
            set { selectedJaneTaskIndex = value; RaisePropertyChanged("SelectedJaneTaskIndex"); }
        }

        public int SelectedJoeTaskIndex
        {
            get { return selectedJoeTaskIndex; }
            set { selectedJoeTaskIndex = value; RaisePropertyChanged("SelectedJoeTaskIndex"); }
        }

        public int SelectedTaskListNameIndex
        {
            get { return selectedTaskListNameIndex; }
            set { selectedTaskListNameIndex = value; RaisePropertyChanged("SelectedTaskListNameIndex"); }
        }

        public string NewTask
        {
            get { return newTask; }
            set { newTask = value; RaisePropertyChanged("NewTask"); }
        }

        public HistViewModel()
        {
            InstantiateCommands();
            LoadToDoLists();
        }

        public void InstantiateCommands()
        {
            RemoveFromShoppingListCommand = new NavigationCommands(param => RemoveTaskAtIndex(ShoppingList, SelectedShoppingListIndex));
            RemoveFromDailyTasksCommand = new NavigationCommands(param => RemoveTaskAtIndex(DailyTasks, SelectedDailyTaskIndex));
            RemoveFromJaneToDoCommand = new NavigationCommands(param => RemoveTaskAtIndex(JaneToDo, SelectedJaneTaskIndex));
            RemoveFromJoeToDoCommand = new NavigationCommands(param => RemoveTaskAtIndex(JoeToDo, SelectedJoeTaskIndex));
            AddTaskCommand = new NavigationCommands(param => AddTask(NewTask));
        }

        public void LoadToDoLists()
        {
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).tasksFromXML(ref shoppingList, "Tasks/ShoppingList.xml");
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).tasksFromXML(ref dailyTasks, "Tasks/DailyTasks.xml");
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).tasksFromXML(ref janeToDo, "Tasks/JaneTodos.xml");
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).tasksFromXML(ref joeToDo, "Tasks/JoeTodos.xml");
        }

        public void AddTask(string newTask)
        {
            Dictionary<string, ObservableCollection<Task>> selectedList = new Dictionary<string, ObservableCollection<Task>>();
            selectedList.Add(taskListNames[0], ShoppingList);
            selectedList.Add(taskListNames[1], DailyTasks);
            selectedList.Add(taskListNames[2], JaneToDo);
            selectedList.Add(taskListNames[3], JoeToDo);

            foreach (string listName in taskListNames)
            {
                if (selectedList.ContainsKey(taskListNames[selectedTaskListNameIndex]))
                {
                    if (newTask != null)
                    {
                        selectedList[taskListNames[selectedTaskListNameIndex]].Add(new Task(newTask));
                        (Instances.Models[(int)Models.Log] as Logger).logToFile("ToDo: Added \"" + newTask + "\" to " + taskListNames[selectedTaskListNameIndex]);
                        break;
                    }
                }
            }
        }

        public void RemoveTaskAtIndex(ObservableCollection<Task> list, int index)
        {
            (Instances.Models[(int)Models.Log] as Logger).logToFile("ToDo: Removed \"" + list[index].TaskName + "\"");
            list.RemoveAt(index);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
