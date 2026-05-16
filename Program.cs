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
                case AppState.Exiting:
                    break;
            }
        }
    }

    public static void ShowMainMenu()
    {
        Console.WriteLine("Нажми \"V\" для появления все задач");
        Console.WriteLine("Нажми \"Esc\" для выхода из меню");
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.V:
                currentState = AppState.ViewingTask;
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
}