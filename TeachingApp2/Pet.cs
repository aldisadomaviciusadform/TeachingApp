using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp2
{
    internal class Pet
    {
        public string Name { get; set; }

        public int Age {  get; set; }

        public Pet()
        {

        }

        public Pet(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            string text = Name + " " + Age.ToString();
            return text;
        }
    }
}
