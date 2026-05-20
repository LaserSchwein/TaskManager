interface ITasksRepository
{
    void Add(Task task);
    void Remove(int id);
    bool TryGetTask(int id, out Task result);
    Task[] GetAll();
}