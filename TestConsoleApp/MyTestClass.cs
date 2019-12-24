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
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            if (randomNumber%2 == 0) return true;
            else return false;
        }
    }
}
