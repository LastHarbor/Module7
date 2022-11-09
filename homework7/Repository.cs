using System.Text;
using System.Linq;

namespace HomeWork7
{
    class Repository
    {
        private string[] titles;//Массив заголовков
        private Worker[] Workers; //Массив сотрудников
        int index; // индекс сотрудника
        public Repository(string path)
        {
            this.path = path;
            this.titles = new string[7];
            this.Workers = new Worker[1];
            this.index = 0;
        }
        private string path;


        #region MainMehtods

        public void CreateWorker(Worker w)
        {
            w.ID = Count;
            w.Date = DateTime.Now;
            Console.WriteLine("Введите имя сотрудника - ");
            w.Name = Console.ReadLine();
            Console.WriteLine("Введите возраст сотрудника - ");
            w.Age = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост сотрудника - ");
            w.Height = Byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите дату рождения сотрудника - ");
            w.Birthday = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите место рождения - ");
            w.Locate = Console.ReadLine();
            AddWorker(w);
        }
        
        public void GetWorkers()
        {
            PrintTitles();
            for (int i = 0; i < index; i++)
            {
                Workers[i].Print();
            }
        }

        public void GetWorkerByID()
        {
            Console.Write("Введите ID сотрудника, которого вы хотите найти: ");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < Workers.Length; i++)
            {
                if (Workers[i].ID == id)
                {
                    PrintTitles();
                    Workers[i].Print();
                }
            }
        }

        public void DeleteById()
        {
            Console.Write("Введите ID удаляемого сотрудника - ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (CheckIDRange(id) != 0)
            {
                id--;
                Worker[] newWorkers = new Worker[Workers.Length];
                for (int i = 0, j = 0; i < index; i++, j++)
                {
                    if (id == j)
                        j++;
                    newWorkers[i] = Workers[j];
                    newWorkers[i].ID = i + 1;
                }
                Workers = newWorkers;
                index--;
            }
            GetWorkers();
        }

        private int CheckIDRange(int id)
        {
            for (int i = 0; i < index; i++)
            {
                id = index;
            }
            int countOfID = id;
            return countOfID;
        }

        public void GetWorkersBetweenDate()
        {
            Console.WriteLine("Введите первую дату - ");
            DateTime dateFrom = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите вторую дату - ");
            DateTime dateTo = DateTime.Parse(Console.ReadLine());
            PrintTitles();
            for (int i = 0; i < Workers.Length; i++)
            {
                if (Workers[i].Birthday < dateTo && Workers[i].Birthday>dateFrom )
                {
                    Workers[i].Print();
                }
            }
            
        }

        #endregion

        #region Other methods

        public void ClearMemory()
        {
            Array.Resize(ref Workers, 0);
            Array.Resize(ref titles, 0);
        }
        private void PrintTitles()
        {
            string tmp = String.Format("{0,10} {1,15} {2,19} {3,15} {4,15} {5,20} {6,25}",
                this.titles[0],
                this.titles[1],
                this.titles[2],
                this.titles[3],
                this.titles[4],
                this.titles[5],
                this.titles[6]);
            Console.WriteLine(tmp);
        }

        public void Save()
        {
            using (var sw = new StreamWriter(path, true, Encoding.Unicode))
            {
                string tmp = String.Format("{0,10}, {1,15}, {2,19}, {3,15}, {4,15}, {5,20}, {6,25}",
                    this.titles[0],
                    this.titles[1],
                    this.titles[2],
                    this.titles[3],
                    this.titles[4],
                    this.titles[5],
                    this.titles[6]);
                sw.WriteLine(tmp);
                for (int i = 0; i < index; i++)
                {
                    string temp2 = String.Format("{0,10}# {1,15}# {2,15}# {3,10}# {4,20}# {5,25}# {6,20}#",
                        this.Workers[i].ID,
                        this.Workers[i].Date,
                        this.Workers[i].Name,
                        this.Workers[i].Age,
                        this.Workers[i].Height,
                        this.Workers[i].Birthday,
                        this.Workers[i].Locate);
                    sw.WriteLine(temp2);
                }
            }
        }
        
        public void IsFileExist()
        {
            FileInfo fi = new FileInfo(path);
            // При проверке на существование файла инициализировать массив заголовков, а так же инициализировать массив Работкников, далее записывать в него новых Workers, а после рабоыт с этими массивами, сохранять в форматированном виде.
            //Метод loadDB удалить.
            if (!File.Exists(this.path))
            {
                File.AppendAllText(path, string.Empty);
                string text = "ID, Дата создания, Имя, Возраст, Рост, Дата рождения, Место рождения";
                string[] text2 = text.Split(',');
                Array.Copy(text2, titles, titles.Length);
            }
            else
            {
                string text = "ID, Дата создания, Имя, Возраст, Рост, Дата рождения, Место рождения";
                string[] text2 = text.Split(',');
                Array.Copy(text2, titles, titles.Length);
            }
            if (fi.Length > 0)
            {
                using (var sr = new StreamReader(path, Encoding.Unicode))
                {
                    titles = sr.ReadLine().Split(',');
                    while (!sr.EndOfStream)
                    {   
                        string[] args = sr.ReadLine().Split('#');
                        AddWorker(new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToByte(args[3]),
                            Convert.ToByte(args[4]), Convert.ToDateTime(args[5]), args[6]));
                    }
                }
            }
        }

        private void GetMoreSpace(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref this.Workers, this.Workers.Length * 2);
            }
        }
        public void AddWorker(Worker worker)
        {
            this.GetMoreSpace(index >= this.Workers.Length);
            this.Workers[index] = worker;
            this.index++;
        }


        public int Count
        {
            get { return this.index; }
            set { this.index = value; }
        }

        public void CreateTestWorkers(Worker workerTest)
        {
            Random r = new Random();
            Console.WriteLine("Сколько тестовых сотрудников вы хотите создать?");
            int test1 = Convert.ToInt32(Console.ReadLine());
            string[] names =
            {
                "Александр", "Алексей", "Анатолий", "Андрей", "Антон", "Аркадий", "Артем", "Борислав", "Вадим",
                "Валентин", "Валерий", "Василий", "Виктор",
                "Виталий", "Владимир", "Вячеслав", "Геннадий", "Георгий", "Григорий", "Даниил", "Денис", "Дмитpий",
                "Евгений"
            };
            string[] city = { "Абакан", "Азов", "Александров", "Алексин", "Альметьевск", "Анапа", "Ангарск", "Анжеро-Судженск",
                "Апатиты", "Арзамас", "Армавир", "Арсеньев", "Артем", "Архангельск", "Асбест", "Астрахань", "Ачинск", "Великие Луки"};

            for (int i = 0; i < test1; i++)
            {
                workerTest.ID = Count;
                workerTest.Date = DateTime.Now;
                workerTest.Name = names[new Random().Next(0, names.Length)];
                workerTest.Age = Convert.ToByte(r.Next(21, 65));
                workerTest.Height = Convert.ToByte(r.Next(120, 210));
                workerTest.Birthday = GetRandomeDate();
                workerTest.Locate = city[new Random().Next(0, city.Length)];
                AddWorker(workerTest);
            }
        }

        private DateTime GetRandomeDate()
        {
            var rnd = new Random();
            var startDate = new DateTime(2001, 1, 1);
            Console.WriteLine(startDate.ToString("yyyy.dd.MM"));
            var newDate = startDate.AddDays(rnd.Next(366));
            Console.WriteLine(newDate.ToString("yyyy.dd.MM"));
            return newDate;
        }
        #endregion
    }
}
#region Shit
//List<Worker> Workers = new List<Worker>();
// Workers.Append(new Worker(Convert.ToInt32(employers[0]), Convert.ToDateTime(employers[1]),
//    employers[2], Convert.ToByte(employers[3]), Convert.ToByte(employers[4]), Convert.ToDateTime(employers[5]), 
//    employers[6]));
//using (StreamWriter sw = new StreamWriter(path, true))
//{
//    //var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
//    //{
//    //    Delimiter = "#"// указываем разделитель, который будет использоваться в файле                           НЕ РАБОЧИЙ МЕТОД
//    //};
//    //using (var csv = new CsvWriter(sw,csvConfig))
//    //{
//    //    foreach (var employeers in Workers)
//    //    {
//    //        csv.WriteRecord(employeers);
//    //    }

//    //}
//}
//for (int i = 0; i < countofworkers; i++)
//    sw.WriteLine(workers[i].ID + "#" + workers[i].Date + "#" + workers[i].Name + "#" + workers[i].Age +           ТОЖЕ НЕ РАБОЧИЙ МЕТОД
//    "#" + workers[i].Height + "#" + workers[i].Birthday + "#"
//    + workers[i].Locate);

//StringBuilder scv = new StringBuilder();
//for (int i = 0; i <countofworkers; i++)
//{
//    scv.AppendLine(workers[i].ID + workers[i].Name + workers[i].Date + workers[i].Age + workers[i].Height + workers[i].Birthday + workers[i].Locate);
//    File.AppendAllText(path, scv.ToString());
//}

#endregion