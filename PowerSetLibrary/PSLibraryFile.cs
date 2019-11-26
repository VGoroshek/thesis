using System;
using System.Collections.Generic;

namespace PowerSetLibrary
    {
        public class PSLibraryFile
        {

            public static T[][] FastPowerSet<T>(T[] seq)
            {
                var powerSet = new T[1 << seq.Length][]; // двоичный размер множества всех подмножеств
                powerSet[0] = new T[0]; // первый в любом случае пустой
                for (var i = 0; i < seq.Length; i++) 
                {
                    var cur = seq[i]; //элемент, что сейчас добавляем в подмножество
                    Console.WriteLine(seq[i]);
                    var count = 1 << i;
                    for (var j = 0; j < count; j++)
                    {
                        var source = powerSet[j];
                        var destination = powerSet[count + j] = new T[source.Length + 1];
                        for (var q = 0; q < source.Length; q++)
                            destination[q] = source[q];
                        destination[source.Length] = cur;
                    }
                }
                return powerSet;
            }
    }
    }

