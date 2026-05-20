using System.Collections;
class TasksRepository : ITasksRepository
{
    private List<Task> _repository = [];
    public TasksRepository()
    {
        
    }
    public void Add(Task task)
    {
        _repository.Add(task);
    }

    public void Remove(int id)
    {
        _repository.RemoveAll(task => task.ID == id);
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
    public Task[] GetAll()
    {
        Task[] result = new Task[_repository.Count];
        _repository.ToArray().CopyTo(result);
        return result;
    }
}