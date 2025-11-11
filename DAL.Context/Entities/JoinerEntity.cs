using System;
using MessagePack;

namespace DAL.Entities
{
    [MessagePackObject]
    public class JoinerEntity : PersonEntity
    {
        [Key(2)]
        public int ExperienceYears { get; set; }

        [Key(3)]
        public string Workshop { get; set; }

        public JoinerEntity() : base() { }

        public JoinerEntity(string surname, string name, int expYears, string workshop)
            : base(surname, name)
        {
            ExperienceYears = expYears;
            Workshop = workshop;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, ExperienceYears: {ExperienceYears}, Workshop:{Workshop}";
        }
    }
}
