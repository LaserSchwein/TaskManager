class ConsoleUI
{
    public ConsoleKey ShowMainMenu()
    {
        Console.WriteLine("Нажми \"V\" для появления всех задач");
        Console.WriteLine("Нажми \"B\" для появления меню создания задачи");
        Console.WriteLine("Нажми \"N\" для появления меню изменения задач");
        Console.WriteLine("Нажми \"Esc\" для выхода из меню");
        var key = Console.ReadKey(true).Key;
        return key;
    }

    public (string? name, string? description) GetNewTaskData()
    {
        Console.Write("Введите название задачи: ");
        string? name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Введите корректное имя для задачи(строка должна содержать какие-то символы помимоп пробелов)");
            Console.Write("Введите название задачи: ");
            name = Console.ReadLine();
        }
        Console.Write("Введите описание(необязательно): ");
        string? desription = "";
        desription = Console.ReadLine();
        return (name, desription);
    }
    
    public (ConsoleKey key, int id) ChangeTasksMenu()
    {
        Console.WriteLine("Введите номер задачи и потом нажмите цифру для выбора действия над задачей");
        Console.WriteLine("1 - Удаление задачи по номеру");
        Console.WriteLine("2 - Изменение приоритета задачи по номеру");
        int id = GetIntegerInput();
        var key = Console.ReadKey(true).Key;
        return (key, id);
    }

    public void WaitUserInput()
    {
        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if(key == ConsoleKey.Enter)
                break;
        }
    }

    public void PrintTasks(Task[] tasks)
    {
        foreach (var task in tasks){
            Console.WriteLine(task);
        }
    }

    private int GetIntegerInput()
    {
        int num = 0;
        bool isInt = false;
        Console.Write("Введите число: ");
        isInt = int.TryParse(Console.ReadLine(), out num);
        while (!isInt)
        {
            Console.WriteLine("Некорректный ввод, напшиите число");
            Console.Write("Введите число: ");
            isInt = int.TryParse(Console.ReadLine(), out num);
        }
        return num;
    }

    public ConsoleKey UpdateStatus()
    {
        Console.Write("Выберите новый статус: 1 - Pending, 2 - InProgress, 3 - Completed");
        return Console.ReadKey(true).Key;
    }
}