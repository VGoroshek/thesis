using System;
using System.Linq;
using System.Collections.Generic;

namespace PowerSetLibrary
{

    public class PSLibraryFile
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

                //bool? isWeaker = seq[i].IsWeaker(seq[j]);
            }


            return graphToStrategies(g.stronglyConnectedComponents(), seq);

        }
    }

}