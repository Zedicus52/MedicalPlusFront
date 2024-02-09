using MedicalPlusFront.WebModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    class PatientInfoVM : BaseVM
    {
        public ObservableCollection<ProblemPatient> ListOfProblem
        {
            get => _listPromblem;
            set
            {
                _listPromblem = value;
                OnPropertyChanged("ListOfProblem");
            }
        }

        private ObservableCollection<ProblemPatient> _listPromblem;

        public PatientInfoVM()
        {
            _listPromblem = new ObservableCollection<ProblemPatient>
           {
               new ProblemPatient { Id = 1, Problem = "Біль у спині."},
               new ProblemPatient { Id = 2, Problem = "Головна біль."},
               new ProblemPatient { Id = 3, Problem = "Біль у м’язах."},
               new ProblemPatient { Id = 4, Problem = "Біль в нижній частині черевної порожнини."}
           };
        }

        protected override void SendRequests()
        {
            // Логіка відправки запитів
        }
    }
}
