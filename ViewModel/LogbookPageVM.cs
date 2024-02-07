using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    internal class LogbookPageVM : BaseVM
    {
        #region User Sort props

        public string UserSelectedHeavines
        {
            get { return _selectedHeavines; }
            set
            {
                _selectedHeavines = value;
                OnPropertyChanged("UserSelectedHeavines");
            }
        }

        public string UserSelectedCreationTime
        {
            get { return _selectedCreationTime; }
            set
            {
                _selectedCreationTime = value;
                OnPropertyChanged("UserSelectedCreationTime");
            }
        }

        public string UserSelectedName
        {
            get { return _selectedUserName; }
            set
            {
                _selectedUserName = value;
                OnPropertyChanged("UserSelectedName");
            }
        }

        private string _selectedHeavines;
        private string _selectedCreationTime;
        private string _selectedUserName;

        #endregion

        #region User Filter props

        public string UserFioInput
        {
            get { return _userFioInput; }
            set
            {
                _userFioInput = value;
                OnPropertyChanged("UserFioInput");
            }
        }

        public string EmployeeFioInput
        {
            get { return _employeeFioInput; }
            set
            {
                _employeeFioInput = value;
                OnPropertyChanged("EmployeeFioInput");
            }
        }

        public string UserDiagnosisInput
        {
            get { return _userDiagnosisInput; }
            set
            {
                _userDiagnosisInput = value;
                OnPropertyChanged("UserDiagnosisInput");
            }
        }

        public string UserResearchNumberInput
        {
            get { return _userResearchNumberInput; }
            set
            {
                _userResearchNumberInput = value;
                OnPropertyChanged("UserResearchNumberInput");
            }
        }

        public bool CaseSensetiveInput
        {
            get { return _sensetiveInput; }
            set
            {
                _sensetiveInput = value;
                OnPropertyChanged("UserSensetiveInput");
            }
        }

        private string _userFioInput;
        private string _employeeFioInput;
        private string _userDiagnosisInput;
        private string _userResearchNumberInput;
        private bool _sensetiveInput;

        #endregion

        public ObservableCollection<SomeUser> ListOfPeople
        {
            get => _listPeople;
            set
            {
                _listPeople = value;
                OnPropertyChanged("ListOfPeople");
            }
        }

        private ObservableCollection<SomeUser> _listPeople;

        public LogbookPageVM()
        {
            _listPeople = new ObservableCollection<SomeUser>
           {
               new SomeUser { Id = 1, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 2, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 3, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 4, Birthday="2000.02.05", Fio = "Some some some"}
           };
        }
    }
}
