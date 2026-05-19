class Program
{
    static AppState currentState = AppState.MainMenu;
    public static void Main(string[] args)
    {
        TasksRepository repository = new TasksRepository();
        Task task1 = new Task(3, "bob", ExecutionStatus.Pending, "nothing");
        Task task2 = new Task(4, "pop", ExecutionStatus.InProgress, "something");
        repository.Add(task1);
        repository.Add(task2);
        while(currentState != AppState.Exiting){
            Console.Clear();
            switch (currentState)
            {
                case AppState.MainMenu:
                    ShowMainMenu(); 
                    break;
                case AppState.ViewingTask:
                    foreach (var task in repository.GetAll()){
                        Console.WriteLine(task);
                    }
                    WaitUserInput();
                    currentState = AppState.MainMenu;
                    break;
                case AppState.CreateTask:
                    CreateTask(repository);
                    break;
                case AppState.Exiting:
                    break;
            }
        }
    }

    public static void ShowMainMenu()
    {
        Console.WriteLine("Нажми \"V\" для появления все задач");
        Console.WriteLine("Нажми \"B\" для появления меню создания задачи");
        Console.WriteLine("Нажми \"Esc\" для выхода из меню");
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.V:
                currentState = AppState.ViewingTask;
                break;
            case ConsoleKey.B:
                currentState = AppState.CreateTask;
                break;
            case ConsoleKey.Escape:
                currentState = AppState.Exiting;
                break;
            default:
                Console.WriteLine("Неопознаная кнопка");
                break;
        }   
    }
    public static void WaitUserInput()
    {
        var key = Console.ReadKey(true).Key;
        while (key != ConsoleKey.Enter)
        {
            
        }
    }

    public static void CreateTask(TasksRepository repository)
    {
        Console.WriteLine("Введите название здаача: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите описание(необязательно): ");
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.Escape:
                repository.Add(new Task(10, name, ExecutionStatus.Pending, ""));
                currentState = AppState.MainMenu;
                return;
        }
        string  description = Console.ReadLine();
        repository.Add(new Task(10, name, ExecutionStatus.Pending, description));
        currentState = AppState.MainMenu;
        return;
    }
}