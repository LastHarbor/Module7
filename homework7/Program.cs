namespace HomeWork7;

internal class Programm
{

    static void Main()
    {
        string path = "DB.csv";
        Repository rep = new Repository(path);
        rep.IsFileExist();
        char y = 'y';
        char n = 'n';
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("Нажмите 1 - Запись 1 сотрудника");
            Console.WriteLine("Нажмите 2 - Пересоздать файл");
            Console.WriteLine("Нажмите 3 - Просмотр списка сотрудников");
            Console.WriteLine("Нажмите 4 - Создание списка тестовых сотрудников");
            Console.WriteLine("Нажмите 5 - Вывод сотрудника по ID");
            Console.WriteLine("Нажмите 6 - Удаление сотрудника по ID");
            Console.WriteLine("Нажмите 7 - Вывод сотрудников в диапозоне дат");
            Console.WriteLine("Нажмите s - Сохранить или выйти");
            char switcher = Convert.ToChar(Console.ReadLine());
            switch (switcher)
            {
                case '1':
                    Console.Clear();
                    rep.CreateWorker(new Worker());
                    Console.WriteLine("Продолжить? y,n - вернуться в меню");
                    char select = char.Parse(Console.ReadLine());
                    if (select == y) rep.CreateWorker(new Worker());
                    else if (select == n) Console.Clear();
                    break;
                case '2':
                    File.Delete(path);
                    Main();
                    break;
                case '3':
                    rep.GetWorkers();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case '4':
                    rep.CreateTestWorkers(new Worker());
                    Console.Clear();
                    break;
                case '5':
                    rep.GetWorkerByID();
                    Console.WriteLine("Продолжить? y - да, n - в меню");
                    char select2 = char.Parse(Console.ReadLine());
                    if (select2 == 'y') rep.GetWorkerByID();
                    else Console.Clear();
                    break;
                case '6':
                    rep.DeleteById();
                    Console.WriteLine("Продолжить? y - да, n - в меню");
                    char select3 = char.Parse(Console.ReadLine());
                    if (select3 == 'y') rep.DeleteById();
                    else Console.Clear();
                    break;
                case '7':
                    rep.GetWorkersBetweenDate();
                    break;
                case 's':
                    Console.WriteLine("y - Продолжить?, n - Сохранить и выйти");
                    char tmp = char.Parse(Console.ReadLine());
                    if (tmp == 'y') continue;
                    if (tmp == 'n')
                    {
                        File.WriteAllText(path, String.Empty);
                        rep.Save();
                        flag = false;
                    }
                    break;
            }

        }
    }
}
