using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp2.Extensions
{
    internal static class ExtensionList
    {

        private static List<T> EveryOtherWordIndex<T>(this List<T> list,int index)
        {
            if (list.Count > index)
            {
//                index++;
                list.RemoveAt(index);
                index++;
                EveryOtherWordIndex(list, index);
            }
            
            return list;
        }

        // Parašykit extension metodą EveryOtherWord List<T> tipui, kuris grąžintų sąrašą sudaryta iš kas antro elemento.
        public static List<T> EveryOtherWord<T>(this List<T> list)
        {
            List<T> result = new List<T>(list);
            return EveryOtherWordIndex(result,0);
        }
    }
}
