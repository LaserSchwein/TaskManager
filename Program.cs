class Program
{
    static AppState currentState = AppState.MainMenu;
    public static void Main(string[] args)
    {
        Dictionary<AppState, IAppAction> actions = new Dictionary<AppState, IAppAction>()
        {
            {AppState.MainMenu, new MainMenuAction()},
            {AppState.ChangeTask, new ChangeTaskMenu()},
            {AppState.CreateTask, new CreateTaskMenu()},
            {AppState.ViewingTask, new ViewingTasksMenu()}
        };
        ITasksRepository repository = new TasksRepository();
        ConsoleUI ui = new ConsoleUI();
        repository.Add("bob", "nothing");
        repository.Add("pop", "something");
        while(currentState != AppState.Exiting){
            Console.Clear();
            if(actions.TryGetValue(currentState, out IAppAction action))
            {
                currentState = action.Execute(repository, ui);
            }
        }
    }
}