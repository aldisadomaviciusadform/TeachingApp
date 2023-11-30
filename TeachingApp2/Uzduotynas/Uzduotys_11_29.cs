using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp2.Uzduotynas
{
    internal class Uzduotys_11_29
    {
        public void Uzd1()
        {
            List<int> intai = new List<int>() { 1, 2, 4, 6, 8, 9, 10, 11, 12, 13 };
            List<int> nauji = intai.Select(a => a * a).ToList();

            foreach (int item in nauji)
                Console.WriteLine(item);
        }

        public void Uzd2()
        {
            List<int> intai = new List<int>() { 1, 2, 4, 6, 8, 9, 10, 11, 12, 13 };
            List<int> nauji = intai.Where(a => a % 2 == 0).ToList();

            intai.Where(a => a % 2 == 0).ToList().ForEach(a => Console.WriteLine(a));

            foreach (int item in nauji)
                Console.WriteLine(item);
        }

        public class Counter
        {
            public int Count;
            public int Value;

            public Counter(int value)
            {
                Value = value;
                Count = 1;
            }
        }

        public void Uzd3(int[,] inputArray)
        {
            List<Counter> counter = new List<Counter>();
            bool found = false;
            for (int i = 0; i < inputArray.GetLength(0); i++)
            {
                for (int j = 0; j < inputArray.GetLength(1); j++)
                {
                    found = false;
                    foreach (Counter item in counter)
                    {
                        if (item.Value == inputArray[i, j])
                        {
                            item.Count++;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        counter.Add(new Counter(inputArray[i, j]));
                }
            }

            counter.Where(a => a.Count >= 2).ToList().ForEach(a => Console.WriteLine(a.Value));
        }

        public void Uzd4()
        {
            Dictionary<string, int> zmones = new Dictionary<string, int>();

            zmones.Add("Petras", 25);
            zmones.Add("Kazys", 5);
            zmones.Add("Jonas", 88);
            zmones.Add("Zmogus", 3);

            foreach (var item in zmones)
                Console.WriteLine("Vardas: " + item.Key + " amzius: " + item.Value);
        }

        public void Uzd5()
        {
            Dictionary<string, string> sostines = new Dictionary<string, string>();

            sostines.Add("Lietuva", "Vilnius");
            sostines.Add("Latvija", "Ryga");
            sostines.Add("Estija", "Talinas");
            sostines.Add("Lenkija", "Varsuva");

            while (true)
            {
                Console.WriteLine("Iveskit sali");
                string input = Console.ReadLine() ?? "";
                Console.Clear();

                if (sostines.TryGetValue(input, out string sostine))
                {
                    Console.WriteLine(sostine);
                }
                else
                    Console.WriteLine("Nera tokios salies " + input);
            }
        }
    }
}
