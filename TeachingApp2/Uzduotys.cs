using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TeachingApp2.Extensions;


namespace TeachingApp2
{
    internal class Uzduotys
    {
        public void Diena_11_28_Uzd1()
        {
            string lyrics = Console.ReadLine();
            string inputTextFrom = Console.ReadLine();
            string inputTextTo = Console.ReadLine();

            string[] words = lyrics.Split(" ");

            string newLyrics = string.Empty;

            Console.WriteLine(lyrics.Replace(inputTextFrom, inputTextTo));

        }

        /*
        Sukurkite programą, kuri priima vartotojo įvestą žodį ir patikrina, ar jis yra "labas". Jei taip,
        atspausdinkite žodį atbulai naudodami metodą Reverse(). Jei žodis nesutampa su "labas", atspausdinkite žodį taip, kaip jis buvo įvestas.
         */
        public void Diena_11_28_Uzd2()
        {
            string inputText = Console.ReadLine();

            if (inputText == "labas")
            {
                string text = string.Empty;
                var reversed = inputText.Reverse().Select(a => text += a);
                Console.WriteLine(reversed.Last());
            }
            else
                Console.WriteLine(inputText);
        }

        /*
        Sukurkite metoda kuris patikrina ar atsiustas tekstas yra skaicius ir grazina skaiciu (kaip int) ir atsakyma ar teisinga
        (is esmes sukurkite savo int.TryParse metoda) NEGALIMA NAUDOTI TRYPARSE
        */
        public bool Diena_11_28_Uzd3(string inputText, out int number)
        {
            try
            {
                number = int.Parse(inputText);
                return true;
            }
            catch (Exception)
            {
                number = 0;
                return false;
            }
        }

        public void Diena_11_29_Uzd1()
        {
            List<int> intai = new List<int>() { 1, 2, 4, 6, 8, 9, 10, 11, 12, 13 };
            List<int> nauji = intai.Select(a => a * a).ToList();

            foreach (int item in nauji)
                Console.WriteLine(item);
        }

        public void Diena_11_29_Uzd2()
        {
            List<int> intai = new List<int>() { 1, 2, 4, 6, 8, 9, 10, 11, 12, 13 };
            List<int> nauji = intai.Where(a => a % 2 == 0).ToList();

            intai.Where(a => a % 2 == 0).ToList().ForEach(a => Console.WriteLine(a));

            foreach (int item in nauji)
                Console.WriteLine(item);
        }

        public  class Counter
        {
            public int Count;
            public int Value;

            public Counter(int value)
            {
                Value = value;
                Count = 1;
            }
        }

        public void Diena_11_29_Uzd3(int[,] inputArray)
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
                        counter.Add(new Counter(inputArray[i,j]));
                }
            }

            counter.Where(a=>a.Count>=2).ToList().ForEach(a => Console.WriteLine(a.Value));
        }

        public void Diena_11_29_Uzd4()
        {
            Dictionary<string,int> zmones = new Dictionary<string,int>();

            zmones.Add("Petras", 25);
            zmones.Add("Kazys", 5);
            zmones.Add("Jonas", 88);
            zmones.Add("Zmogus", 3);

            foreach (var item in zmones)
                Console.WriteLine("Vardas: " + item.Key + " amzius: " + item.Value);
        }

        public void Diena_11_29_Uzd5()
        {
            Dictionary<string, string> sostines = new Dictionary<string, string>();

            sostines.Add("Lietuva", "Vilnius");
            sostines.Add("Latvija", "Ryga");
            sostines.Add("Estija", "Talinas");
            sostines.Add("Lenkija", "Varsuva");

            while(true)
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

        public void Diena_11_30_Uzd1()
        {
            List<int> intai = new List<int>() { 1, 2, 4, 6, 8, 9, 10, 11, 12, 13 };
            intai.EveryOtherWord().ForEach(i=>Console.WriteLine(i));
        }
    }

    


}
