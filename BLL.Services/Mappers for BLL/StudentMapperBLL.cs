using System;
using BLL.ModelsForBLL;
using DAL.Entities;

namespace BLL.MappersForBLL
{
    public static class StudentMapperBLL
    {
        public static StudentModelBLL ToModel(this StudentEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new StudentModelBLL
            {
                Surname = entity.Surname,
                Name = entity.Name,
                Course = entity.Course,
                StudentID = entity.StudentID,
                Gender = entity.Gender,
                Address = entity.Address,
                RecordBookNumber = entity.RecordBookNumber
            };
        }

        public static StudentEntity ToEntity(this StudentModelBLL model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new StudentEntity
            {
                Surname = model.Surname,
                Name = model.Name,
                Course = model.Course,
                StudentID = model.StudentID,
                Gender = model.Gender,
                Address = model.Address,
                RecordBookNumber = model.RecordBookNumber
            };
        }
    }
}
