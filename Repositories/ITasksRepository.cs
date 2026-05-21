interface ITasksRepository
{
    void Add(string name, string description);
    void Remove(int id);
    bool TryGetTask(int id, out Task result);
    Task[] GetAll();
}