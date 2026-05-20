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
        taskResult = _repository.FirstOrDefault(r => r.ID == id);
        return taskResult != null;
    }
    public Task[] GetAll()
    {
        return  _repository.ToArray();
    }
}