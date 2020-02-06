using System;
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

                for (int j = i+1; j < seq.Length; j++)
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


            // убрать перестановки?
            // сделать 4, 5, 6-элементные массивы...

        public static List<List<T>> createStrSubsets<T> (T[] seq, List<List<T>>  TupleList ) where T: IInput
            {
            List<List<T>> StrSubsets = new List<List<T>>();
            
            StrSubsets.AddRange(TupleList);
                for(int i = 0; i < TupleList.Count; i++)
                {
                    for(int j = 0; j < seq.Length; j++)
                    {
                    bool flag = true;
                    for (int k = 0; k < TupleList[i].Count; k++)
                        {
                            if(TupleList[i][k].Equals(seq[j]))
                            {
                                flag = false;
                                break;
                            }                            
                            if (TupleList[i][k].CheckInconsistency(seq[j]))
                            { 
                                continue;
                            }
                           
                            flag = false;
                            break;
                        }
                        if (flag)
                        {
                            List<T> TuplesList1 = new List<T>(TupleList[i]);
                            TuplesList1.Add(seq[j]);   
                            StrSubsets.Add(TuplesList1);
                        }

                    }

                }

            return StrSubsets;
            }
    }
    }

//или сделать метакласс-компаратор