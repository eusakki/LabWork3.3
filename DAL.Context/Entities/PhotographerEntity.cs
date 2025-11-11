using System;
using MessagePack;

namespace DAL.Entities
{
    [MessagePackObject]
    public class PhotographerEntity : PersonEntity
    {
        [Key(2)]
        public string CameraModel { get; set; }

        [Key(3)]
        public string Specialty { get; set; }

        public PhotographerEntity() : base() { }

        public PhotographerEntity(string surname, string name, string cameraModel, string specialty)
            : base(surname, name)
        {
            CameraModel = cameraModel;
            Specialty = specialty;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, CameraModel: {CameraModel}, Specialty: {Specialty}";
        }
    }
}
