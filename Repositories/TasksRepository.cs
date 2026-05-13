using System.Collections;
class TasksRepository
{
    private List<Task> _repository = [];
    public TasksRepository()
    {
        
    }
    public void Add(Task task)
    {
        _repository.Add(task);
    }
    public bool TryGetTask(int id, out Task taskResult)
    {
        foreach (var task in _repository)
        {
            if (task.ID == id)
            {
                taskResult = task;
                return true;
            }
        }
        taskResult = null;
        return false;
    }
}