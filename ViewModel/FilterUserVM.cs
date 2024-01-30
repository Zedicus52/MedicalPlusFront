using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    class FilterUserVM : BaseVM
    {
        public string FullNamePatientInput
        {
            get => _fullNamePatientInput;
            set
            {
                _fullNamePatientInput = value;
                OnPropertyChanged("FullNamePatientInput");
            }
        }

        public string FullNameDoctorInput
        {
            get => _fullNameDoctorOutput;
            set
            {
                _fullNameDoctorOutput = value;
                OnPropertyChanged("FullNameDoctorInput");
            }
        }

        public string DiagnosisInput
        {
            get => _diagnosisInput;
            set
            {
                _diagnosisInput = value;
                OnPropertyChanged("DiagnosisInput");
            }
        }

        public string NumberResearchInput
        {
            get => _numberResearchInput;
            set
            {
                _numberResearchInput = value;
                OnPropertyChanged("NumberResearchInput");
            }
        }

        public FilterUserVM()
        {
            FullNamePatientInput = string.Empty;
            FullNameDoctorInput = string.Empty;
            DiagnosisInput = string.Empty;
            NumberResearchInput = string.Empty;
        }

        private string _fullNamePatientInput;
        private string _fullNameDoctorOutput;
        private string _diagnosisInput;
        private string _numberResearchInput;
    }
}
