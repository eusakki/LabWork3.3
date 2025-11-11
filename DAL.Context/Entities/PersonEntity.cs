using System;
using MessagePack;

namespace DAL.Entities
{
    public abstract class PersonEntity
    {
        [Key(0)]
        public string Surname { get; set; }
        [Key(1)]
        public string Name { get; set; }
        
        protected PersonEntity() { }

        protected PersonEntity(string surname, string name)
        {
            Surname = surname;
            Name = name;
        }

        public override string ToString()
        {
            return $"Surname: {Surname}, Name: {Name}";
        }
    }
}
