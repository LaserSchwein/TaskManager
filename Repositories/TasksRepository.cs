using System.Collections;
using System.Net.Http.Headers;
class TasksRepository : ITasksRepository
{
    private List<Task> _repository = [];
    private int _nextId = 0;
    public TasksRepository()
    {
        
    }
    public void Add(string name, string description)
    {
        _repository.Add(new Task(_nextId, name, ExecutionStatus.Pending, description));
        _nextId++;
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
    
    public void UpdateTaskStatus(int id, ExecutionStatus newStatus)
    {
        var task = _repository.FirstOrDefault(r => r.ID == id);
        if(task != null)
        {
            task.Status = newStatus;
        }
    }
}