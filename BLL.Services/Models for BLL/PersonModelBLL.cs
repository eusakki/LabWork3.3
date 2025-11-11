using System;

namespace BLL.ModelsForBLL
{
    public abstract class PersonModelBLL
    {
        public string Surname { get; set; }
        public string Name { get; set; }

        public PersonModelBLL() { }

        public PersonModelBLL(string surname, string name)
        {
            Surname = surname;
            Name = name;
        }
    }
}
