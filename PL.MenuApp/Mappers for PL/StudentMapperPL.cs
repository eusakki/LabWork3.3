using System;
using PL.ModelsForPL;
using BLL.ModelsForBLL;

namespace PL.MappersForPL
{
    public static class StudentMapperPL
    {
        public static StudentModelBLL ToBLL(this StudentModelPL pl)
        {
            if (pl == null)
            {
                throw new ArgumentNullException(nameof(pl));
            }

            return new StudentModelBLL
            {
                Name = pl.Name,
                Surname = pl.Surname,
                Course = pl.Course,
                StudentID = pl.StudentID,
                Gender = pl.Gender,
                Address = pl.Address,
                RecordBookNumber = pl.RecordBookNumber
            };
        }

        public static StudentModelPL ToPL(this StudentModelBLL bll)
        {
            if (bll == null)
            {
                throw new ArgumentNullException(nameof(bll));
            }

            return new StudentModelPL
            {
                Name = bll.Name,
                Surname = bll.Surname,
                Course = bll.Course,
                StudentID = bll.StudentID,
                Gender = bll.Gender,
                Address = bll.Address,
                RecordBookNumber = bll.RecordBookNumber
            };
        }
    }
}
