using PowerSetLibrary;
using System;
using System.Diagnostics;
using System.Linq;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создаем тестовый массив
            MyTestClass[] testArr = new MyTestClass[]
            {
                new MyTestClass(8),
                new MyTestClass(7),
                new MyTestClass(6),
                new MyTestClass(5),
                new MyTestClass(4),
                new MyTestClass(3),
                new MyTestClass(2),
                new MyTestClass(1)
            };

            Stopwatch sw = Stopwatch.StartNew();//Засекаем время выполнения
            var comp = PSLibraryFile.CreateComponents(testArr);
            sw.Stop();
            //Вывод времени выполнения
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            for (int i = 0; i < comp.Count; i++)
                Console.WriteLine(String.Join(',', comp[i].Select(r => r.Id).ToArray()));
            Console.WriteLine();
            //STRONGLY


            var compS = PSLibraryFile.CreateStrongComponents(testArr);
            sw.Stop();
            //Вывод времени выполнения
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            for (int i = 0; i < compS.Count; i++)
                Console.WriteLine(String.Join(',', compS[i].Select(r => r.Id).ToArray()));

            Console.ReadKey();
            
        }
    }
}
