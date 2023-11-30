using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp2
{
    internal class Validation<T>
    {
        public void Validate(T input) 
        {
            if (input == null)
            {
                Console.WriteLine("Error");
            }
        }
    }
}
