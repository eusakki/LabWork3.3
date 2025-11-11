using System;
using DAL;
using DAL.Entities;
using BLL.ModelsForBLL;
using BLL.MappersForBLL;

namespace BLL.EntityServices
{
    public class StudentService
    {
        private readonly EntityContext _context = new();

        public void AddStudent(StudentModelBLL model, string type, string path)
        {
            var students = _context.LoadAll<StudentEntity>(type, path) ?? new List<StudentEntity>();
            students.Add(model.ToEntity());
            _context.SaveAll(students, type, path);
        }

        public List<StudentModelBLL> GetStudents(string type, string path)
        {
            var students = _context.LoadAll<StudentEntity>(type, path) ?? new List<StudentEntity>();
            return students.Select(s => s.ToModel()).ToList();
        }

        public void DeleteStudent(string id, string type, string path)
        {
            var students = _context.LoadAll<StudentEntity>(type, path) ?? new List<StudentEntity>();
            var toRemove = students.FirstOrDefault(s => s.StudentID == id);

            if (toRemove == null)
                throw new Exception("Student not found");

            students.Remove(toRemove);
            _context.SaveAll(students, type, path);
        }

        public List<StudentModelBLL>? Task(string type, string path)
        {
            var students = _context.LoadAll<StudentEntity>(type, path);
            if (students == null || !students.Any())
                return null;

            var filtered = students
                .Where(s => s.Course == 5 && s.Gender == "Female" && s.Address.Contains("Kyiv", StringComparison.OrdinalIgnoreCase))
                .Select(s => s.ToModel())
                .ToList();

            return filtered;
        }
    }
}
