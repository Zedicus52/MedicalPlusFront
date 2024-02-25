using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.WebModels
{
    [Serializable]
    public class FioModel
    {
        public int IdFio { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public FioModel()
        {
            IdFio = 0;
            Name = string.Empty;
            Surname = string.Empty;
            Patronymic = string.Empty;
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}";
        }

    }
}
