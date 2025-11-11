using System;
using BLL.ModelsForBLL;
using DAL.Entities;

namespace BLL.MappersForBLL
{
    public static class PhotographerMapperBLL
    {
        public static PhotographerModelBLL ToModel(this PhotographerEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new PhotographerModelBLL
            {
                Name = entity.Name,
                Surname = entity.Surname,
                CameraModel = entity.CameraModel,
                Specialty = entity.Specialty
            };
        }

        public static PhotographerEntity ToEntity(this PhotographerModelBLL model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            return new PhotographerEntity
            {
                Name = model.Name,
                Surname = model.Surname,
                CameraModel = model.CameraModel,
                Specialty = model.Specialty
            };
        }
    }
}
