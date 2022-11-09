using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    struct Worker
    {

        #region Конструктор

        /// <summary>
        /// Конструктор сотрудника
        /// </summary>
        /// <param name="ID">ID сотрудника</param>
        /// <param name="Date">Дата добавления</param>
        /// <param name="Name">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Height">Рост</param>
        /// <param name="Birthday">Дата рождения</param>
        /// <param name="Locate">Место рождения</param>
        public Worker(int ID, DateTime Date, string Name, byte Age, byte Height, DateTime Birthday,
            string Locate) : this()
        {
            this.id = ID;
            this.date = Date;
            this.name = Name;
            this.age = Age;
            this.height = Height;
            this.birthday = Birthday;
            this.locate = Locate;
        }
        #endregion

        #region Свойства

        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Время создания
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        /// <summary>
        /// Рост
        /// </summary>
        public byte Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }
        /// <summary>
        /// Место Рождения
        /// </summary>
        public string Locate
        {
            get { return this.locate; }
            set { this.locate = value; }
        }
        #endregion

        #region Поля
        /// <summary>
        /// Поле "ID"
        /// </summary>
        private int id;
        /// <summary>
        ///Поле "Время создания"
        /// </summary>
        private DateTime date;
        /// <summary>
        /// Поле "Имя"
        /// </summary>
        private string name;
        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private byte age;
        /// <summary>
        /// Поле "Рост"
        /// </summary>
        private byte height;
        /// <summary>
        /// Поле "Дата рождения"
        /// </summary>
        private DateTime birthday;
        /// <summary>
        /// Поле "Место рождения"
        /// </summary>
        private string locate;
        #endregion

        #region Методы
        public void Print()
        {
            string temp = String.Format("{0,10} {1,15} {2,15} {3,10} {4,20} {5,25} {6,20}",
                ID,
                Date,
                Name,
                Age,
                Height,
                Birthday,
                Locate);
            Console.WriteLine(temp);
        }
        #endregion
    }
}