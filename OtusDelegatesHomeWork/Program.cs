namespace OtusDelegatesHomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выбирите демо пример:");
                Console.WriteLine("1 - Демонстрация работы обобщенного метода расширения \"Поиск максимального значения\"");
                Console.WriteLine("2 - Демонстрация работы класса поиска файлов с вызовом событий");
                Console.WriteLine("3 - Выход");
                var keyChar = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (keyChar)
                {
                    case '1':                        
                        RunDemoGetMaxExtention();
                        break;
                    case '2':
                        RunDemoFileSearcher();
                        break;
                    case '3':
                        return;                        
                }
            }
        }

        // Демонстрация работы обобщенного метода расширения "Поиск максимального значения"
        static void RunDemoGetMaxExtention()
        {
            var users = new UsersRepository().GetUsers();
            var maxAgeUser = users.GetMax(x => x.Age);
            var maxNameLengthUser = users.GetMax(x => x.Name.Length);
            Console.WriteLine("Список пользователей:");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i+1}: Id - {users[i].Id}, Name - {users[i].Name}, Surname - {users[i].Surname}, Age - {users[i].Age}.");
            }
            Console.WriteLine($"Самый старший пользователь: Id - {maxAgeUser.Id}, Name - {maxAgeUser.Name}, Surname - {maxAgeUser.Surname}, Age - {maxAgeUser.Age}.");
            Console.WriteLine($"Пользователь с самым длинным именем: Id - {maxNameLengthUser.Id}, Name - {maxNameLengthUser.Name}, Surname - {maxNameLengthUser.Surname}, Age - {maxNameLengthUser.Age}.");
        }
        
        // Демонстрация работы класса поиска файлов с вызовом событий
        static void RunDemoFileSearcher()
        {
            Console.WriteLine("Введите полный путь к дирректории:");
            string directoryPath = Console.ReadLine();
            Console.WriteLine("Введите имя файла или начальные символы имени (без учета регистра):");
            string fileName = Console.ReadLine();
            var fileSearcher = new FileSearcher();
            fileSearcher.FileFoundEventHandler += DisplayFileInfo;
            Task.Run(new Action(() => fileSearcher.Search(directoryPath, fileName)));
            Console.WriteLine("Для отмены нажмите q");
            var key = Console.ReadKey().KeyChar;
            if (key == 'q')
            {
                Console.WriteLine();
                fileSearcher.Cancel = true; 
            }
        }
        static void DisplayFileInfo(FileSearcher sender, FileFoundEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
