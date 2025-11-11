using System;

namespace BLL.ModelsForBLL
{
    public class JoinerModelBLL : PersonModelBLL
    {
        public int ExperienceYears { get; set; }
        public string Workshop { get; set; }

        public JoinerModelBLL() : base() { }

        public JoinerModelBLL(string surname, string name, int expYears, string workshop) 
            : base(surname, name)
        {
            ExperienceYears = expYears;
            Workshop = workshop;
        }
    }
}
