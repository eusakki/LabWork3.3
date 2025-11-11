using System;
using MessagePack;

namespace DAL.Entities
{
    [MessagePackObject]
    public class StudentEntity : PersonEntity, IMulHugeNumbers
    {
        [Key(2)]
        public int Course { get; set; }

        [Key(3)]
        public string StudentID { get; set; }

        [Key(4)]
        public string Gender { get; set; }

        [Key(5)]
        public string Address { get; set; }

        [Key(6)]
        public string RecordBookNumber { get; set; }

        public StudentEntity() : base() { }

        public StudentEntity(string surname, string name, int course, string id, 
            string gender, string address, string recordBook)
            : base(surname, name)
        {
            Course = course;
            StudentID = id;
            Gender = gender;
            Address = address;
            RecordBookNumber = recordBook;
        }

        public string MultiplyingHugeNumbers()
        {
            return "I can multiply huge numbers";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Course:{Course}, ID:{StudentID}, Gender:{Gender}," +
                $"Address:{Address}, RecordBookNumber:{RecordBookNumber}";
        }
    }
}
