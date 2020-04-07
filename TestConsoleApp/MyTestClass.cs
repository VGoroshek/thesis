using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleApp
{
    /// <summary>Тестовый класс</summary>
    public sealed class MyTestClass: IInput
    {
        /// <summary>Поле номера</summary>
        public int Id { get; private set; }
        public MyTestClass(int num)
        {
            Id = num;
        }

        public bool CheckInconsistency(IInput seq2)
        {
            
            MyTestClass other = seq2 as MyTestClass;
            ///деление на 4
            if ((other.Id % 4 == 0) && (Id % 4 == 0) || (other.Id % 4 != 0) && (Id % 4 != 0))
                return true;
            else return false;

            /*
            ///непротиворечивость - если одинаковая четность
            if ((other.Id % 2  == 0) && (this.Id % 2 == 0))
            {
                return true;
            }
            if ((other.Id % 2 != 0) && (this.Id % 2 != 0))
            {
                return true;
            }
            return false;
            */

            /*
            ///случайный выбор непротиворечивости
                Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            if (randomNumber%2 == 0) return true;
            else return false;
            */
        }

        public List<IInput> GetChildren()
        {
            return null;
        }
        public List<IInput> GetParents()
        {
            return null;
        }
    }
}
