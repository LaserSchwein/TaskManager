interface IAppAction
{
    AppState Execute(ITasksRepository repository, ConsoleUI ui);
}