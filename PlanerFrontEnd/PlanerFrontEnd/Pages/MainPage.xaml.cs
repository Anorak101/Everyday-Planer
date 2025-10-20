using Common.Entities;
using PlanerFrontEnd.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
namespace PlanerFrontEnd
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        TaskToDoService taskService = new TaskToDoService();
        public ObservableCollection<TaskToDo> tasks { get; set; }       


        public MainPage()
        {
            InitializeComponent();
            tasks = new ObservableCollection<TaskToDo>(); 
            
            tasks.Add(new TaskToDo(0, "temp"));
            BindingContext = this;

            updateTasks(); 

            
        }

        private async void updateTasks() 
        {
            List<TaskToDo> newTasks = await taskService.getUpdatedTasksAsync();
            Console.WriteLine(newTasks.Count); 
            tasks.Clear();
            foreach (TaskToDo task in newTasks) 
            {
                Console.WriteLine(task.sName); 
                tasks.Add(task);
            }
        }

    }
}
