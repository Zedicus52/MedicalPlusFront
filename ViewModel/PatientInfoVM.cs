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
               new ProblemPatient { Id = 1, Problem = "Some some some"},
               new ProblemPatient { Id = 2, Problem = "Some some some"},
               new ProblemPatient { Id = 3, Problem = "Some some some"},
               new ProblemPatient { Id = 4, Problem = "Some some some"}
           };
        }
    }
}
