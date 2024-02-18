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
        public int IdDifficulty { get; set; }
        public int IdPatient { get; set; }
        public string Diagnosis { get; set; }
        public string MicroDesc { get; set; }
        public string MacroDesc { get; set; }

        public ProblemModel()
        {
            IdProblem = 0;
            IdUser = string.Empty;
            IdDifficulty = 0;
            IdPatient = 0;
            Diagnosis = string.Empty;
            MicroDesc = string.Empty;
            MacroDesc = string.Empty;
        }
    }
}
