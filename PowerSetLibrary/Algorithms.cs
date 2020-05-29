using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PowerSetLibrary
{

    public class Algorithms
    { 
        public static List<List<T>> graphToStrategies<T>(List<List<int>> comp, T[] seq) where T : IInput
        {
            List<List<T>> res = new List<List<T>>();
            for (int i = 0; i < comp.Count; i++)
            {
                List<T> resLine = new List<T>();
                for (int j = 0; j < comp[i].Count; j++)
                {
                    resLine.Add(seq[comp[i][j]]);
                }
                res.Add(resLine);
            }
            return res;
        }

        public static List<List<T>> CreateComponents<T>(T[] seq) where T : IInput
        {
            List<List<T>> ComponentsList = new List<List<T>>();

            Graph g = new Graph(seq.Length); //isWeaker
            //проверять, если один сильнее другого, то 
            for (int i = 0; i < seq.Length; i++)
            {

                for (int j = i + 1; j < seq.Length; j++)
                {
                    bool checkInc = (seq[i].CheckInconsistency(seq[j]));
                    if (checkInc)
                    {
                        g.addEdgeUndir(i, j);
                    }

                }

                //bool? isWeaker = seq[i].IsWeaker(seq[j]);
            }


            return graphToStrategies(g.connectedComponents(), seq);

        }

        public static List<List<T>> CreateStrongComponents<T>(T[] seq) where T : IInput
        {
            List<List<T>> ComponentsList = new List<List<T>>();

            Graph g = new Graph(seq.Length); //isWeaker
            //проверять, если один сильнее другого, то 
            for (int i = 0; i < seq.Length; i++)
            {

                for (int j = i + 1; j < seq.Length; j++)
                {
                    bool checkInc = (seq[i].CheckInconsistency(seq[j]));
                    if (checkInc)
                    {
                        g.addEdgeDir(i, j);
                    }

                }

            }

            return graphToStrategies(g.stronglyConnectedComponents(), seq);

        }

        public static List<List<T>> GreedySetCover<T>(T[]seq) where T: IInput
        {


            return null;
        }

        public static List<List<T>> PowerSetCover<T>(T[]seq) where T: IInput
        {
            return null;
        }

        public static List<T> cliqueToStrategies<T>(int[] clique, T[]seq)
        {
            List<T> maxClique = new List<T>();
            for (int i = 0; i<clique.Length;i++)
            {
                if (clique[i] == 1)
                {
                    maxClique.Add(seq[i]);
                }
            }
            return maxClique;
        }
        public static List<T> MaxClique<T>(T[] seq) where T : IInput
        {
            
            Graph g = new Graph(seq.Length); 

            for (int i = 0; i < seq.Length; i++)
            {

                for (int j = i + 1; j < seq.Length; j++)
                {
                    bool checkInc = (seq[i].CheckInconsistency(seq[j]));
                    if (checkInc)
                    {
                        g.addEdgeUndir(i, j);
                    }

                }

            }

            g.search();

            int[] clique = g.solution;
            Console.WriteLine("[{0}]", string.Join(", ", clique));

            return cliqueToStrategies(clique, seq);
        }



    }

}