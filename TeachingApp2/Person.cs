using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp2
{

    

    internal class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public List<Pet> Pets { get; set; }

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
            Pets = new List<Pet>();
        }

        public void AddAnimals(List<string> animalsNames, List <int> ageAnimals)
        {
            Pets = new List<Pet>();
            
            for (int i = 0; i < animalsNames.Count; i++)
            {
                Pets.Add(new Pet(animalsNames[i], ageAnimals[i]));
            }
        }

        public override string ToString()
        {
            string text = Name + " " + Age.ToString() + " Gyvunai:";
            foreach (Pet pet in Pets)
                text += pet.ToString() + " ";
            return text;
        }
    }
}
