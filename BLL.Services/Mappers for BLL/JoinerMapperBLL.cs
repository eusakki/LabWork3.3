using System;
using BLL.ModelsForBLL;
using DAL.Entities;

namespace BLL.MappersForBLL
{
    public static class JoinerMapperBLL
    {
        public static JoinerModelBLL ToModel(this JoinerEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new JoinerModelBLL
            {
                Surname = entity.Surname,
                Name = entity.Name,
                ExperienceYears = entity.ExperienceYears,
                Workshop = entity.Workshop
            };
        }

        public static JoinerEntity ToEntity(this JoinerModelBLL model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            return new JoinerEntity
            {
                Surname = model.Surname,
                Name = model.Name,
                ExperienceYears = model.ExperienceYears,
                Workshop = model.Workshop
            };
        }
    }
}
