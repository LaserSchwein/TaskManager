class ViewingTasksMenu : IAppAction
{
    public AppState Execute(ITasksRepository repository, ConsoleUI ui)
    {
        ui.PrintTasks(repository.GetAll());
        ui.WaitUserInput();
        return AppState.MainMenu;
    }
}