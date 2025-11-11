using System;
using System;
using DAL;
using DAL.Entities;
using BLL.ModelsForBLL;
using BLL.MappersForBLL;
using System.Data;

namespace BLL.EntityServices
{
    public class PhotographerService
    {
        private readonly EntityContext _context = new();

        public void AddPhotographer(PhotographerModelBLL model, string type, string path)
        {
            var photographers = _context.LoadAll<PhotographerEntity>(type, path) ?? new List<PhotographerEntity>();
            photographers.Add(model.ToEntity());
            _context.SaveAll(photographers, type, path);
        }

        public List<PhotographerModelBLL> GetPhotographers(string type, string path)
        {
            var photographers = _context.LoadAll<PhotographerEntity>(type, path) ?? new List<PhotographerEntity>();
            return photographers.Select(p => p.ToModel()).ToList();
        }

        public void DeletePhotographer(string surname, string type, string path)
        {
            var photographers = _context.LoadAll<PhotographerEntity>(type, path) ?? new List<PhotographerEntity>();
            var toRemove = photographers.FirstOrDefault(p => p.Surname == surname);

            if (toRemove == null)
                throw new Exception("Photographer not found");

            photographers.Remove(toRemove);
            _context.SaveAll(photographers, type, path);
        }
    }
}
