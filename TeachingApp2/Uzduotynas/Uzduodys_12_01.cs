using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp2.Uzduotynas
{
/*
 * Delegates:
Sukurkite klasę Person su string name ir int age
Main metode sukurkite sąrašą žmonių skirtingais vardais ir amžiaus
Sukurkite delegatą Filter, kuris grąžins bool o per parametrą pasiims Person objektą.
Sukurkite tris metodus kurie grąžins bool reikšmes ir priiminės Person per parametrą, 
vienas metodas tikrins ar žmogus yra vaikas < 18 metų, kitas tikrins ar suaugęs >= 18 metų ir trečias tikrins ar senjoras >= 65 metai.
Sukurkite metodą DisplayPeople, su parametrais title, List<Person> ir delegatu Filter. 
Metodo esmė bus eiti ciklu per asmenys ir paleisdinėti perduotą per parametrus filtrą patikrinti ar žmogus pvz. yra vaikas.

Metodo kvietimas atrodys maždaug taip: DisplayPeople("Children:", people, IsChild);

Metodai gali būti anoniminiai
*/
    internal class Uzduodys_12_01
    {
        public delegate bool Filters(Person person);

        public bool IsChild(Person person)
        {
            return person.Age < 18;
        }

        public bool IsAdult(Person person)
        {
            return person.Age >= 18;
        }

        public bool IsSenior(Person person)
        {
            return person.Age > 65;
        }

        public List<Person> DisplayPeople(string title, List<Person> people, Filters filtras)
        {
            List<Person> newList = new List<Person>();
            foreach (Person person in people)
            {
                if (filtras(person))
                {
                    Console.WriteLine(person);
                    newList.Add(person);
                }                
                else
                    Console.WriteLine("Sitas nera " + person);
            }
            return newList;
        }

        public void Uzd1()
        {
            Uzduotys uzduotys = new Uzduotys();

            int count = 10;
            List<int> ages = uzduotys.RandomizerInt(count, 10, 90);
            List<string> names = uzduotys.RandomizerString(count, 5, 10);

            List<Person> persons = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                persons.Add(new Person(ages[i], names[i]));
    //                Console.WriteLine(names[i] + " " + ages[i]);
            }

            DisplayPeople("Kazkas:", persons, IsSenior);
        }

        /*

Linq:

Sukurkite Person klasę su vardu ir sąrašu gyvūnų(irgi nauja klasė, gyvūnai turi tik vardą). Sukurkite sąrašą su Person objektais ir viduje esančiais gyvūnų sąrašais.
Su LINQ Select ir SelectMany sukurkite sąrašą kurį sudarys visi gyvūnai iš sąrašo.
Kitas sąrašas, kurį sudarys tik gyvūnai, kurių vardai prasideda iš A raidės.
Pridėkite prie Pet klasės amžių int Age, sudarykite kitą sąrašą iš gyvūnų, kurių vardai prasideda iš A raidės ir jų amžius yra virš 5 metų.
Parašykite metodą, kuris priima vieną string parametrą. Parašykite LINQ funkcionalumą, kad grąžintų žodžius kurie yra vien iš didžiųjų raidžių.
*/
        public void Uzd2_1(string input)
        {
            string[] words = input.Split(" ");
            var naujas = words.Where(x => x == x.ToUpper());

            foreach (string word in naujas)
            {
                Console.WriteLine(word);
            }
        }

        public void Uzd2()
        {
            Uzduotys uzduotys = new Uzduotys();

            int count = 50;
            List<int> ages = uzduotys.RandomizerInt(count, 10, 90);
            List<string> names = uzduotys.RandomizerString(count, 5, 10);

            List<Person> persons = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                persons.Add(new Person(ages[i], names[i]));
                int petCount = uzduotys.RandomizerInt(1, 1, 5)[0];
                List<string> petNames = uzduotys.RandomizerString(petCount, 2, 4);
                List<int> petAges = uzduotys.RandomizerInt(petCount, 0, 15);

                persons[i].AddAnimals(petNames, petAges);
                //                Console.WriteLine(names[i] + " " + ages[i]);
            }

            var allPets = persons.SelectMany(person => person.Pets).ToList();
            var allPetsWithA = allPets.Where(pet => pet.Name[0]=='a' || pet.Name[0] == 'A').ToList();
            var allPetsWithAand5 = allPetsWithA.Where(pet => pet.Age >= 5).ToList();

            Uzd2_1("aaaaaaaa bb aaas EE AAS yy5 YY6");
        }

        /*
Asinchroninis programavimas:
Sukurkite bent 10 failų su tekstų, teksto turėtų būti, bent 100+ žodžių (kuo daugiau failų ir teksto tuo daugiau). 
Tuomet asynchroniškai skaitykite visus failus vienu metu (jeigu pritrūkote resursų, galite skaityti po 4 ar 8 failus vienu metu.
Susikurkite sąrašą ieškomų žodžių. Tuo pačiu metu, kai baigiate skaityti failą (vienu metu išvedinėjame kelis failus)
išveskite naują rezultatų failą (atskiras failas kiekvienam skaitomui failui, pvz MyFile1_Results.txt... MyFile2_Results.txt)
Kuriame bus sąrašas žodžių iš jūsų ieškomų žodžių sąrašo kuriuose radote ir kiek kartų juos radote pvz (Herojus:15,Kompiuteris:4).
Failų formatas gali būti keičiamas jūsų nuožiūra, galima naudoti json.
 */
        public void Uzd3GeneratorFiles()
        {
            Uzduotys uzduotys = new Uzduotys();

            int fileCount = 50;

            for (int i = 0; i < fileCount; i++)
            {
                int wordCount = uzduotys.RandomizerInt(1, 100, 5000)[0];

                List<string> texts = uzduotys.RandomizerString(wordCount, 5, 20);

                StringBuilder stringBuilder = new StringBuilder();

                foreach (string text in texts)
                {
                    stringBuilder.Append(text + " ");
                }

                string path = (10 + i).ToString() + ".txt";
                File.WriteAllText(path, stringBuilder.ToString());
            }
        }
    }
}
