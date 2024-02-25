using System;

namespace MedicalPlusFront.WebModels
{
    [Serializable]
    public class EmployeeModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CurrentPassword { get; set; }
        public string Email { get; set; }
        public FioModel Fio { get; set; }
        public GenderModel Gender { get; set; }
        public Role Role { get; set; }


        public EmployeeModel()
        {
            this.UserId = string.Empty;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.CurrentPassword = string.Empty;
            this.Email = string.Empty;
            this.Fio = new FioModel();
            this.Gender = new GenderModel();
            this.Role = new Role();
        }
    }
}
