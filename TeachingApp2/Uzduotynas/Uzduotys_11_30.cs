using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingApp2.Extensions;

namespace TeachingApp2.Uzduotynas
{
    internal class Uzduotys_11_30
    {
        public void Uzd1()
        {
            List<int> intai = new List<int>() { 1, 2, 4, 6, 8, 9, 10, 11, 12, 13 };
            intai.EveryOtherWord().ForEach(i => Console.WriteLine(i));
        }

        public void Uzd2()
        {
            StringBuilder reversedText = new StringBuilder();
            string userInput = Console.ReadLine();

            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            for (int i = userInput.Length - 1; i >= 0; i--)
                reversedText.Append(userInput[i]);

            sw.Stop();
            string rezultatas = reversedText.ToString();
            Console.WriteLine(rezultatas);

            Console.WriteLine(sw.Elapsed);
        }

        public void Uzd3()
        {
            Dog dog = new Dog();
            dog.SetName("ciucis");
            Console.WriteLine(dog.GetName());
            dog.SetName("sparkis");
            Console.WriteLine(dog.GetName());
            dog.Eat();
        }

        public void Uzd4()
        {
            Validation<string> validation = new Validation<string>();
            validation.Validate("kkkk");
            validation.Validate(null);

            Validation<int> validation2 = new Validation<int>();
            validation2.Validate(1);
        }

        public delegate string Delegatas1(string firstName, string lastName, int age);

        private string Delegatas1Metodas1(string firstName, string lastName, int age)
        {
            Console.WriteLine(firstName);
            return firstName;
        }
        private string Delegatas1Metodas2(string firstName, string lastName, int age)
        {
            Console.WriteLine(lastName);
            return lastName;
        }

        public void Uzd5()
        {
            Delegatas1 delegatas1 = new Delegatas1 (Delegatas1Metodas1);
            Delegatas1 delegatas2 = new Delegatas1(Delegatas1Metodas2);

            delegatas1("aa", "BB", 5);
            delegatas2("aa", "BB", 5);

        }

        public void Uzd6()
        {
            Delegatas1 delegatas1 = delegate (string firstName, string lastName, int age)
            {
                    Console.WriteLine(firstName);
                    return firstName;
            }; 
            Delegatas1 delegatas2 = delegate (string firstName, string lastName, int age)
            {
                Console.WriteLine(lastName);
                return lastName;
            };

            delegatas1("aaB", "BBa", 5);
            delegatas2("aaB", "BBa", 5);

        }
    }
}
