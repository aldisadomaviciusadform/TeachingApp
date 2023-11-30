using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp2.Extensions
{
    internal static class ExtensionsString
    {
        public static bool HasSpace(this string text)
        {
            return text.Contains(" ");
        }
    }
}
