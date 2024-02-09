using System;

namespace MedicalPlusFront.WebModels
{
    [Serializable]
    public class PatientModel
    {
        public int IdPatient { get; set; }  
        public int PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public virtual FioModel Fio { get; set; }
        public virtual GenderModel Gender { get; set; }

        public PatientModel()
        {
            IdPatient = 0;
            PhoneNumber = 0;
            BirthDate = DateTime.MinValue;
            ApplicationDate = DateTime.MinValue;
            Fio = new FioModel();  
            Gender = new GenderModel();
        }
    }
}
