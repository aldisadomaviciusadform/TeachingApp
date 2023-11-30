using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp2.Uzduotynas
{
    internal class Uzduotys_11_28
    {
        public void Uzd1()
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
        public void Uzd2()
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
        public bool Uzd3(string inputText, out int number)
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
    }
}
