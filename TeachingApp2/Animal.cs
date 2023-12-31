﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp2
{


    internal abstract class Animal
    {
        public string Name { get; set; }

        public Animal()
        {
            
        }

        public Animal(string name)
        {
            Name = name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public abstract void Eat();
    }
}
