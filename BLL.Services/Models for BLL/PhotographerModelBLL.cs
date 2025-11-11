using System;

namespace BLL.ModelsForBLL
{
    public class PhotographerModelBLL : PersonModelBLL
    {
        public string CameraModel { get; set; }
        public string Specialty { get; set; }

        public PhotographerModelBLL() : base() { }

        public PhotographerModelBLL(string surname, string name, string cameraModel, string specialty)
            : base(surname, name)
        {
            CameraModel = cameraModel;
            Specialty = specialty;
        }
    }
}
