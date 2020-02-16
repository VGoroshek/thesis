using System;
using System.Linq;
using System.Collections.Generic;

namespace PowerSetLibrary
{
    public class PSLibraryFile
    {


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

        public static T[][] FastPowerSet<T>(T[] seq) where T : IInput
        {
            var powerSet = new T[1 << seq.Length][]; // двоичный размер множества всех подмножеств
            powerSet[0] = new T[0]; // первый в любом случае пустой (мб убрать его)
            for (var i = 0; i < seq.Length; i++) //для каждого элемента исходного массива
            {
                var cur = seq[i]; //элемент, что сейчас добавляем в подмножество
                var count = 1 << i; //размер подмножества
                for (var j = 0; j < count; j++)
                {
                    var source = powerSet[j]; //то, куда кладем элементы
                    var destination = powerSet[count + j] = new T[source.Length + 1];
                    for (var q = 0; q < source.Length; q++)
                    {
                        destination[q] = source[q];
                    }
                    destination[source.Length] = cur;
                }
            }
            return powerSet;
        }

        public static bool CheckInList<T>(T el1, T el2, List<List<T>> seq)
        {

            return seq.Exists(listT => listT[0].Equals(el1) && listT[1].Equals(el2));
        }

        //почему не заходит в итерацию по трехэлементным

        public static List<List<T>> RecStrSubSets<T>(T[] seq, List<List<T>> Pairs, List<List<T>> Sets)
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


        public static List<List<T>> CreateStrSubsets<T>(T[] seq, List<List<T>> TupleList) where T : IInput
        {
            List<List<T>> StrSubsets = new List<List<T>>();
            StrSubsets = RecStrSubSets(seq, TupleList, TupleList);
            return StrSubsets;
        }
    }

}

//или сделать метакласс-компаратор