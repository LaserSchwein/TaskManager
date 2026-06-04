class MainMenuAction : IAppAction
{
    public MainMenuAction(){}
    public AppState Execute(ITasksRepository repository, ConsoleUI ui)
    {
        var keyMainMenu = ui.ShowMainMenu();
        return keyMainMenu switch
        {
            ConsoleKey.B => AppState.CreateTask,
            ConsoleKey.V => AppState.ViewingTask,
            ConsoleKey.N => AppState.ChangeTask,
            _ => AppState.MainMenu
        };
    }
}