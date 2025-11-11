using System;

namespace PL.ModelsForPL
{
    public class StudentModelPL : PersonModelPL
    {
        public int Course { get; set; }
        public string StudentID { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string RecordBookNumber { get; set; }

        public StudentModelPL() : base() { }

        public StudentModelPL(string surname, string name, int course, string id,
            string gender, string address, string recordBook)
            : base(surname, name)
        {
            Course = course;
            StudentID = id;
            Gender = gender;
            Address = address;
            RecordBookNumber = recordBook;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Course:{Course}, ID:{StudentID}, Gender:{Gender}," +
                $"Address:{Address}, RecordBookNumber:{RecordBookNumber}";
        }
    }
}
