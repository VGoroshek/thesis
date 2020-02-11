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
            return true;
            /*
            MyTestClass other = seq2 as MyTestClass;
            if ((other.Id % 2  == 0) && (this.Id % 2 == 0))
            {
                return true;
            }
            if ((other.Id % 2 != 0) && (this.Id % 2 != 0))
            {
                return true;
            }
            return false;
            /*
                Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            if (randomNumber%2 == 0) return true;
            else return false;
            */
        }
    }
}
