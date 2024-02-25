using System;

namespace MedicalPlusFront.WebModels
{
    [Serializable]
    public class GenderModel
    {
        public int IdGender { get; set; }
        public string Name { get; set; }

        public GenderModel()
        {
            IdGender = 0;
            Name = string.Empty;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
