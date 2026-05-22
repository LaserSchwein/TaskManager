class Program
{
    static AppState currentState = AppState.MainMenu;
    public static void Main(string[] args)
    {
        ITasksRepository repository = new TasksRepository();
        repository.Add("bob", "nothing");
        repository.Add("pop", "something");
        ConsoleUI ui = new ConsoleUI();
        while(currentState != AppState.Exiting){
            Console.Clear();
            switch (currentState)
            {
                case AppState.MainMenu:
                    var keyMainMenu = ui.ShowMainMenu();
                    switch (keyMainMenu)
                    {
                        case ConsoleKey.B:
                            currentState = AppState.CreateTask;
                            break;
                        case ConsoleKey.V:
                            currentState = AppState.ViewingTask;
                            break;
                        case ConsoleKey.N:
                            currentState = AppState.ChangeTask;
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
                    repository.Add(data.name, data.description);
                    currentState = AppState.MainMenu;
                    break;
                case AppState.ChangeTask:
                    var dataChangeTask = ui.ChangeTasksMenu();
                    switch (dataChangeTask.key)
                    {
                        case ConsoleKey.D1:
                            repository.Remove(dataChangeTask.id);
                            break;
                        case ConsoleKey.D2:
                            var key = ui.UpdateStatus();
                            if(key == ConsoleKey.D1)
                                repository.UpdateTaskStatus(dataChangeTask.id, ExecutionStatus.Pending);
                            else if(key == ConsoleKey.D2)                            
                                repository.UpdateTaskStatus(dataChangeTask.id, ExecutionStatus.InProgress);
                            else if(key == ConsoleKey.D3)                            
                                repository.UpdateTaskStatus(dataChangeTask.id, ExecutionStatus.Completed);
                            break;
                    }
                    currentState = AppState.MainMenu;
                    break;
                case AppState.Exiting:
                    break;
            }
        }
    }
}