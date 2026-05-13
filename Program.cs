class Program
{
    public static void Main(string[] args)
    {
        TasksRepository repository = new TasksRepository();
        Task task1 = new Task(3, "bob", ExecutionStatus.Pending, "nothing");
        Task task2 = new Task(4, "pop", ExecutionStatus.InProgress, "something");
        repository.Add(task1);
        repository.Add(task2);
        Task task = new Task();
        if (repository.TryGetTask(3, out task))
        {
            Console.WriteLine(task);
        }
    }
}