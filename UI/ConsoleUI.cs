class ConsoleUI
{
    public ConsoleKey ShowMainMenu()
    {
        Console.WriteLine("Нажми \"V\" для появления все задач");
        Console.WriteLine("Нажми \"B\" для появления меню создания задачи");
        Console.WriteLine("Нажми \"Esc\" для выхода из меню");
        var key = Console.ReadKey(true).Key;
        return key;
    }

    public (string? name, string? description) GetNewTaskData()
    {
        Console.WriteLine("Введите название здаача: ");
        string? name = Console.ReadLine();
        Console.WriteLine("Введите описание(необязательно): ");
        string? desription = "";
        desription = Console.ReadLine();
        return (name, desription);
    }

        public void WaitUserInput()
    {
        
        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if(key != ConsoleKey.Enter)
                break;
        }
    }

    public void PrintTasks(Task[] tasks)
    {
        foreach (var task in tasks){
            Console.WriteLine(task);
        }
    }
}