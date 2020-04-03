using System;
using System.Linq;
using System.Collections.Generic;

namespace PowerSetLibrary
{

    public class PSLibraryFile
    {


        // переделать на tuples
        public static List<List<T>> CreateTuples<T>(T[] seq) where T : IInput
        {
            List<List<T>> TuplesList = new List<List<T>>();

            for (int i = 0; i < seq.Length; i++)
            {

                for (int j = i + 1; j < seq.Length; j++)
                {
                    if (seq[i].CheckInconsistency(seq[j]))
                    {
                        List<T> temptuple = new List<T>() { seq[i], seq[j] };
                        TuplesList.Add(temptuple);
                    }

                }
            }
            return TuplesList;
        }

        private static bool CheckInList<T>(T el1, T el2, List<List<T>> seq)
        {

            return seq.Exists(listT => listT[0].Equals(el1) && listT[1].Equals(el2));
        }

        private static List<List<T>> RecStrSubSets<T>(T[] seq, List<List<T>> Pairs, List<List<T>> Sets)
        {
            List<List<T>> StrSubsets = new List<List<T>>();
            for (int i = 0; i < Sets.Count; i++)
            {
                for (int j = 0; j < seq.Length; j++)
                {
                    bool checkInc = true;
                    bool alreadyElem = false;

                    for (int k = 0; k < Sets[i].Count; k++)
                    {

                        if (Sets[i][k].Equals(seq[j]))
                        {
                            alreadyElem = true;
                            break;
                        }
                        List<T> elem = new List<T>();
                        elem.Add(Sets[i][k]);
                        elem.Add(seq[j]);


                        if (CheckInList(Sets[i][k], seq[j], Pairs))
                        {
                            continue;
                        }

                        checkInc = false;
                    }
                    if (checkInc && !alreadyElem)
                    {
                        List<T> TuplesList1 = new List<T>(Sets[i]);
                        TuplesList1.Add(seq[j]); //???
                        StrSubsets.Add(TuplesList1);
                    }
                }

            }
            if (StrSubsets.Count == 0)
                return StrSubsets;
            StrSubsets.AddRange(RecStrSubSets(seq, Pairs, StrSubsets));

            return StrSubsets;
        }


        public static List<T> CreateStrSubsets<T>(T[] seq, List<List<T>> TupleList) where T : IInput
        {
            List<List<T>> StrSubsets = new List<List<T>>();
            StrSubsets = RecStrSubSets(seq, TupleList, TupleList);
            return StrSubsets.Last();
        }
    }

}

//или сделать метакласс-компаратор