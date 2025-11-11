using System;
using System.Runtime.CompilerServices;

namespace PL.ModelsForPL
{
    public abstract class PersonModelPL
    {
        public string Surname { get; set; }
        public string Name { get; set; }

        public PersonModelPL() { }

        public PersonModelPL(string surname, string name)
        {
            Surname = surname;
            Name = name;
        }
    }
}
