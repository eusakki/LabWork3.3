using System;
using BLL.Exceptions;

namespace BLL.ModelsForBLL
{
    public class StudentModelBLL : PersonModelBLL
    {
        public int Course { get; set; }
        public string StudentID { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string RecordBookNumber { get; set; }

        public StudentModelBLL() : base() { }

        public StudentModelBLL(string surname, string name, int course, string id,
            string gender, string address, string recordBook)
            : base(surname, name)
        {
            Course = course;
            if (id == null || id.Length != 8)
                throw new StudIdException("Student ID must include 8 chars!");
            StudentID = id;
            Gender = gender;
            Address = address;
            RecordBookNumber = recordBook;
        }
    }
}
