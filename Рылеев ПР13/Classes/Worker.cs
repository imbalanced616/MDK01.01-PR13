using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рылеев_ПР13.Classes
{
    class Worker
    {
        // Поля класса
        private string fio;
        private string post;
        private int entrance;
        private int experience;

        // Свойства для доступа к полям
        public string FIO
        {
            get { return fio; }
            set { fio = value; }
        }
        public string POST
        {
            get { return post; }
            set { post = value; }
        }
        public int ENTRANCE
        {
            get { return entrance; }
            set { entrance = value; }
        }
        public int EXPERIENCE
        {
            get { return experience; }
            set { experience = value; }
        }

        // Конструктор по умолчанию
        public Worker()
        {
            fio = "Иванов И.И.";
            post = "Грузчик";
            entrance = 2020;
            experience = DateTime.Today.Year - entrance;
        }

        // Конструктор с параметрами
        public Worker(string f, string p, int entr)
        {
            fio = f;
            post = p;
            entrance = entr;
            experience = DateTime.Today.Year - entr;
        }
    }
}
