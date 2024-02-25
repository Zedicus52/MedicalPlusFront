using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.WebModels
{
    [Serializable]
    public class ProblemModel
    {
        public int IdProblem { get; set; }

        public string IdUser { get; set; }
        public string IdCreateUser { get; set; }

        public int IdDifficulty { get; set; }
        public int IdPatient { get; set; }
        public string ResearchNumber { get; set; }
        public string Diagnosis { get; set; }
        public string ClinicalData { get; set; }
        public string OperationType { get; set; }
        public DateTime OperationDate { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public string MicroDesc { get; set; }

        public string MacroDesc { get; set; }

        public ProblemModel()
        {
            IdProblem = 0;
            IdUser = string.Empty;
            IdDifficulty = 0;
            IdPatient = 0;
            ResearchNumber = string.Empty;
            Diagnosis = string.Empty;
            MicroDesc = string.Empty;
            MacroDesc = string.Empty;
            ClinicalData = string.Empty;
            OperationType = string.Empty;   
        }
    }
}
