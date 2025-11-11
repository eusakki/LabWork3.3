using System;
using DAL;
using DAL.Entities;
using BLL.ModelsForBLL;
using BLL.MappersForBLL;
using System.Data;

namespace BLL.EntityServices
{
    public class JoinerService
    {
        private readonly EntityContext _context = new();

        public void AddJoiner(JoinerModelBLL model, string type, string path)
        {
            var joiners = _context.LoadAll<JoinerEntity>(type, path) ?? new List<JoinerEntity>();
            joiners.Add(model.ToEntity());
            _context.SaveAll(joiners, type, path);
        }

        public List<JoinerModelBLL> GetJoiners(string type, string path)
        {
            var joiners = _context.LoadAll<JoinerEntity>(type, path) ?? new List<JoinerEntity>();
            return joiners.Select(j => j.ToModel()).ToList();
        }

        public void DeleteJoiner(string surname, string type, string path)
        {
            var joiners = _context.LoadAll<JoinerEntity>(type, path) ?? new List<JoinerEntity>();
            var toRemove = joiners.FirstOrDefault(j => j.Surname == surname);

            if (toRemove == null)
                throw new Exception("Joiner not found");

            joiners.Remove(toRemove);
            _context.SaveAll(joiners, type, path);
        }
    }
}
