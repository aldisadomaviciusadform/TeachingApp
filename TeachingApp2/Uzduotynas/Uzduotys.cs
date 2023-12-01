using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TeachingApp2.Extensions;


namespace TeachingApp2.Uzduotynas
{
    internal class Uzduotys
    {
        public List<int> RandomizerInt(int count, int min, int max)
        {
            List<int> list = new List<int>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                list.Add(random.Next(min, max));
            }
            return list;
        }

        public List<string> RandomizerString(int count, int min, int max)
        {
            List<string> list = new List<string>();
            Random random = new Random();
            Random random1 = new Random(); 

            for (int i = 0; i < count; i++)
            {
                List<char> word = new List<char>();
                for (int j = 0; j < random.Next(min, max); j++)
                    word.Add((char)random1.Next(65, 91));

                list.Add(new string(word.ToArray()));
            }
            return list;
        }

    }




}
