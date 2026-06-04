class ChangeTaskMenu : IAppAction
{
    public AppState Execute(ITasksRepository repository, ConsoleUI ui)
    {
        var dataChangeTask = ui.ChangeTasksMenu();
        switch (dataChangeTask.key)
        {
            case ConsoleKey.D1:
                repository.Remove(dataChangeTask.id);
                break;
            case ConsoleKey.D2:
                var key = ui.UpdateStatus();
                ExecutionStatus? newStatus = key switch
                {
                    ConsoleKey.D1 => ExecutionStatus.Pending,
                    ConsoleKey.D2 => ExecutionStatus.InProgress,
                    ConsoleKey.D3 => ExecutionStatus.Completed,
                    _ => null
                };
                if (newStatus.HasValue)
                {
                    repository.UpdateTaskStatus(dataChangeTask.id, newStatus.Value);
                }
                break;
        }
        return AppState.MainMenu;
    }
}