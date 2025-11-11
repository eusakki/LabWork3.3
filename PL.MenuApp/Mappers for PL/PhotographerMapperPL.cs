using System;
using PL.ModelsForPL;
using BLL.ModelsForBLL;

namespace PL.MappersForPL
{
    public static class PhotographerMapperPL
    {
        public static PhotographerModelBLL ToBLL(this PhotographerModelPL pl)
        {
            if (pl == null)
            {
                throw new ArgumentNullException(nameof(pl));
            }

            return new PhotographerModelBLL
            {
                Name = pl.Name,
                Surname = pl.Surname,
                CameraModel = pl.CameraModel,
                Specialty = pl.Specialty
            };
        }

        public static PhotographerModelPL ToPL(this PhotographerModelBLL bll)
        {
            if (bll == null)
            {
                throw new ArgumentNullException(nameof(bll));
            }

            return new PhotographerModelPL
            {
                Name = bll.Name,
                Surname = bll.Surname,
                CameraModel = bll.CameraModel,
                Specialty = bll.Specialty
            };
        }
    }
}
