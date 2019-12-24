using System;
using System.Collections.Generic;

namespace PowerSetLibrary
    {
        public class PSLibraryFile
        {

            public static T[][] FastPowerSet<T>(T[] seq) where T: IInput
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
    }
    }

//или сделать метакласс-компаратор