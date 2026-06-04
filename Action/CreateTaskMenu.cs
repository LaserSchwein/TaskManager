class CreateTaskMenu : IAppAction
{
    public AppState Execute(ITasksRepository repository, ConsoleUI ui)
    {
        var data = ui.GetNewTaskData();
        repository.Add(data.name, data.description);
        return AppState.MainMenu;
    }
}