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
                new MyTestClass(1),
                new MyTestClass(2),
                new MyTestClass(3),
                new MyTestClass(4)
                //,
                //new MyTestClass(5),
                //new MyTestClass(6)
            };
            
            Stopwatch sw = Stopwatch.StartNew();//Засекаем время выполнения
            //MyTestClass[][] result = PSLibraryFile.FastPowerSet(testArr);//Выполняем
            var res1 = PSLibraryFile.CreateTuples(testArr);
            var result1 = PSLibraryFile.CreateStrSubsets(testArr, res1);

            sw.Stop();
            //Вывод результатов
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);//Пример форматированного вывода
            //for(int i = 0; i< result.Length;i++)
            //    Console.WriteLine(String.Join(',', result[i].Select(r => r.Id).ToArray()));
            //Console.WriteLine();
            for (int i = 0; i < res1.Count; i++)
                Console.WriteLine(String.Join(',', res1[i].Select(r => r.Id).ToArray()));
            Console.WriteLine();
            for (int i = 0; i < result1.Count; i++)
                Console.WriteLine(String.Join(',', result1[i].Select(r => r.Id).ToArray()));
            //Для вывода используем конкатенацию, для преобразования числа в строку используем лямбда выражения
            //В C# этот раздел называется LINQ, в Java - Stream API. В Python, насколько я знаю, тоже есть лямбда-выражения

            Console.ReadKey();
            
        }
    }
}
