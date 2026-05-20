class Program
{
    static AppState currentState = AppState.MainMenu;
    public static void Main(string[] args)
    {
        ITasksRepository repository = new TasksRepository();
        repository.Add(new Task(3, "bob", ExecutionStatus.Pending, "nothing"));
        repository.Add(new Task(4, "pop", ExecutionStatus.InProgress, "something"));
        ConsoleUI ui = new ConsoleUI();
        while(currentState != AppState.Exiting){
            Console.Clear();
            switch (currentState)
            {
                case AppState.MainMenu:
                    var key = ui.ShowMainMenu();
                    switch (key)
                    {
                        case ConsoleKey.B:
                            currentState = AppState.CreateTask;
                            break;
                        case ConsoleKey.V:
                            currentState = AppState.ViewingTask;
                            break;
                    } 
                    break;
                case AppState.ViewingTask:
                    ui.PrintTasks(repository.GetAll());
                    ui.WaitUserInput();
                    currentState = AppState.MainMenu;
                    break;
                case AppState.CreateTask:
                    var data = ui.GetNewTaskData();
                    repository.Add(new Task(10, data.name, ExecutionStatus.Pending, data.description));
                    currentState = AppState.MainMenu;
                    break;
                case AppState.Exiting:
                    break;
            }
        }
    }
}