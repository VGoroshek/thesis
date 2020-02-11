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


        // убрать перестановки?
        // сделать 4, 5, 6-элементные массивы...

        public static List<List<T>> CreateStrSubsets<T>(T[] seq, List<List<T>> TupleList) where T : IInput {
            List<List<T>> StrSubsets = new List<List<T>>();
            List<List<T>> Check = TupleList;
            StrSubsets.AddRange(TupleList);
            for (int i = 0; i < TupleList.Count; i++) {
                for (int j = 0; j < seq.Length; j++) {  //3
                    bool checkInc = true;
                    bool alreadyElem = false;                    

                    for (int k = 0; k < TupleList[i].Count; k++) //1
                    { 

                        if (TupleList[i][k].Equals(seq[j])) { //false
                            alreadyElem = true;
                            break;
                        }
                        List<T> elem = new List<T>();
                        elem.Add(TupleList[i][k]);
                        elem.Add(seq[j]);
                        //проверка, есть ли уже в исходном списке пар 
                        //(а дальше и исходном списке списков n-непротиворечивых эл-тов проще, 
                        //чем перебор каждого с каждым
                        //т.е. вместо
                        //if (TupleList[i][k].CheckInconsistency(seq[j])) {//true
                        //    continue;
                        //}
                        //вот это
                        if (Check.Contains(elem))
                        {
                            continue;
                        }
                        //но оно не работает
                        
                        checkInc = false;
                    }
                    if (checkInc && !alreadyElem) {
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