using System;

namespace PL.ModelsForPL
{
    public class JoinerModelPL : PersonModelPL
    {
        public int ExperienceYears { get; set; }
        public string Workshop { get; set; }

        public JoinerModelPL() : base() { }

        public JoinerModelPL(string surname, string name, int expYears, string workshop)
            : base(surname, name)
        {
            ExperienceYears = expYears;
            Workshop = workshop;
        }
    }
}
