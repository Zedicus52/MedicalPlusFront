using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    public class UserPageVM : BaseVM
    {
        #region Sort Users Props

        public ObservableCollection<string> Difficulties
        {
            get => _difficulties;
            set
            {
                _difficulties = value;
                OnPropertyChanged("Difficulties");
            }
        }
        public string SelectedDifficulty
        {
            get => _selectedDiffuculty;
            set
            {
                _selectedDiffuculty = value;
                OnPropertyChanged("SelectedDifficulty");
            }
        }

        private ObservableCollection<string> _difficulties;
        private string _selectedDiffuculty;

        public ObservableCollection<string> CreationTimes
        {
            get => _creationTimes;
            set
            {
                _creationTimes = value;
                OnPropertyChanged("CreationTimes");
            }
        }
        public string SelectedCreationTime
        {
            get => _selectedCreationTime;
            set
            {
                _selectedCreationTime = value;
                OnPropertyChanged("SelectedCreationTime");
            }
        }

        private ObservableCollection<string> _creationTimes;
        private string _selectedCreationTime;

        public ObservableCollection<string> PatientFios
        {
            get => _patientFios;
            set
            {
                _patientFios = value;
                OnPropertyChanged("PatientFios");
            }
        }
        public string SelectedPatientFio
        {
            get => _selectedPatientFio;
            set
            {
                _selectedPatientFio = value;
                OnPropertyChanged("SelectedPatientFio");
            }
        }

        private ObservableCollection<string> _patientFios;
        private string _selectedPatientFio;

        #endregion

        #region Create User Props
        public string SurnameInput
        {
            get => _surnameInput;
            set
            {
                _surnameInput = value;
                OnPropertyChanged("SurnameInput");
            }
        }

        public string NameInput
        {
            get => _nameInput;
            set
            {
                _nameInput = value;
                OnPropertyChanged("NameInput");
            }
        }


        public string PatronymicInput
        {
            get => _patronymicInput;
            set
            {
                _patronymicInput = value;
                OnPropertyChanged("PatronymicInput");
            }
        }

        public string PhoneFaxInput
        {
            get => _phoneFaxInput;
            set
            {
                _phoneFaxInput = value;
                OnPropertyChanged("PhoneFaxInput");
            }
        }

        public string BirthDateInput
        {
            get => _birthDateInput;
            set
            {
                _birthDateInput = value;
                OnPropertyChanged("BirthDateInput");
            }
        }

        public string GenderInput
        {
            get => _genderInput;
            set
            {
                _genderInput = value;
                OnPropertyChanged("GenderInput");
            }
        }


        public RelayCommand CreateUserCommand
        {
            get
            {
                return _createUserCommand ?? (_createUserCommand = new RelayCommand(() =>
                {

                }));
            }
        }


        private string _surnameInput;
        private string _nameInput;
        private string _patronymicInput;
        private string _phoneFaxInput;
        private string _birthDateInput;
        private string _genderInput;

        public RelayCommand _createUserCommand;
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

        public UserPageVM()
        {

            _listPeople = new ObservableCollection<SomeUser>
           {
               new SomeUser { Id = 1, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 2, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 3, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 4, Birthday="2000.02.05", Fio = "Some some some"}
           };
        }

        protected override void SendRequests()
        {
        }
    }
}
