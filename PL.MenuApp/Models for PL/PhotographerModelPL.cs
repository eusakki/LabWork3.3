using System;

namespace PL.ModelsForPL
{
    public class PhotographerModelPL : PersonModelPL
    {
        public string CameraModel { get; set; }
        public string Specialty { get; set; }

        public PhotographerModelPL() : base() { }

        public PhotographerModelPL(string surname, string name, string cameraModel, string specialty)
            : base(surname, name)
        {
            CameraModel = cameraModel;
            Specialty = specialty;
        }
    }
}
