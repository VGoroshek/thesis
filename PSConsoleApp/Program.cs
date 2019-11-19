using System;
using PowerSetLibrary;
using System.Collections.Generic;

namespace PSConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] StrategyArray = new int[] { 99, 98, 92, 97, 95 }; // inputfile of strategies (type Strategy [])
            int [][] StrategySubarrayArray = PSLibraryFile.FastPowerSet(StrategyArray);
            for (int i = 0; i < Math.Pow(2, StrategyArray.GetLength(0)); i++)
            {
                Console.Write((i+1).ToString() + " subarray:" + " ");
                for (int j = 0; j < StrategySubarrayArray[i].GetLength(0); j++)
                {
                    Console.Write(StrategySubarrayArray[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

        }
    }
}
