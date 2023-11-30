using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace TeachingApp2.Extensions
{
    internal static class ExtensionsInt
    {
        public static bool IsEven(this int skaicius)
        {
            return skaicius % 2 == 0;
        }
    }
}
