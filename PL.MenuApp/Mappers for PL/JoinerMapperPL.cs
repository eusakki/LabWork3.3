using System;
using PL.ModelsForPL;
using BLL.ModelsForBLL;

namespace PL.MappersForPL
{
    public static class JoinerMapperPL
    {
        public static JoinerModelBLL ToBLL(this JoinerModelPL pl)
        {
            if (pl == null)
            {
                throw new ArgumentNullException(nameof(pl));
            }

            return new JoinerModelBLL
            {
                Name = pl.Name,
                Surname = pl.Surname,
                ExperienceYears = pl.ExperienceYears,
                Workshop = pl.Workshop
            };
        }

        public static JoinerModelPL ToPL(this JoinerModelBLL bll)
        {
            if (bll == null)
            {
                throw new ArgumentNullException(nameof(bll));
            }

            return new JoinerModelPL
            {
                Name = bll.Name,
                Surname = bll.Surname,
                ExperienceYears = bll.ExperienceYears,
                Workshop = bll.Workshop
            };
        }
    }
}
