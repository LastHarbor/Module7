using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using HomeWork7;

namespace HomeWork7;

    internal class Programm
    {
        
        static void Main()
        {
            string path = "DB.csv";
            Repository rep = new Repository(path);
            rep.IsFileExist();
            Console.WriteLine("Нажмите 1 - для записи");
            Console.WriteLine("Нажмите 2 - для удаления");
            Console.WriteLine("Нажмите 3 - для просмотра списка сотрудников");
            Console.WriteLine("Нажмите 4 - для создания списка тестовых сотрудников");
            Console.WriteLine("Нажмите 5 - для вывода сотрудника по ID");
            Console.WriteLine("Нажмите 6 - для удаления сотрудника по ID");
            Console.WriteLine("Нажмите s - для сохранения или для выхода из программы");
            char y = 'y';
            char n = 'n';
            char switcher = Convert.ToChar(Console.ReadLine());
            switch (switcher)
            {
                case '1':
                    Console.Clear();
                    rep.CreateWorker();
                    Console.WriteLine("Продолжить? y,n - вернуться в меню");
                    char select = char.Parse(Console.ReadLine());
                    if (select == y)
                    {
                        rep.CreateWorker();
                    }
                    else if (select == n) Main();
                    break;
                case '2':
                    File.Delete(path);
                    Main();
                    break;
                case '3':
                    rep.GetWorkers();
                    Console.ReadLine();
                    Main();
                    break;
                case '4':
                    rep.CreateTestWorkers(new Worker());
                    Console.Clear();
                    break;
                case '5':
                    rep.GetWorkerByID();
                    Console.WriteLine("Продолжить? y - да, n - вернуться в мюне");
                    char select2 = char.Parse(Console.ReadLine());
                    if (select2 == 'y')
                    {
                        rep.GetWorkerByID();
                    }
                    else if (select2 == n) Main();

                    break;
                case '6':
                    Console.WriteLine("Продолжить? y - да, n - вернуться в мюне");
                    char select3 = char.Parse(Console.ReadLine());
                    if (select3 == 'y')
                    {
                        rep.DeleteById();
                    }
                    else if (select3 == n) Main();
                    break;
                case 's':
                    Console.WriteLine("y - Сохранить и выйти, n - Сохранить и вернуться");
                    char tmp = char.Parse(Console.ReadLine());
                    if (tmp == 'y')
                    {
                        rep.Save();

                    }
                    else if (tmp == n)
                    {
                        rep.Save();
                        Main();
                    }
                    break;

            }
        }
    }
