using Flurl.Http;
using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.Utils;
using MedicalPlusFront.WebModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        public ObservableCollection<GenderModel> AllGenders
        {
            get => _allGenders;
            set
            {
                _allGenders = value;
                OnPropertyChanged("AllGenders");
            }
        }

        public GenderModel SelectedGender
        {
            get => _selectedGender;
            set
            {
                _selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }


        public RelayCommand CreateUserCommand
        {
            get
            {
                return _createUserCommand ?? (_createUserCommand = new RelayCommand(() =>
                {
                    if (string.IsNullOrEmpty(_surnameInput) || string.IsNullOrEmpty(_nameInput)
                    || string.IsNullOrEmpty(_patronymicInput) || string.IsNullOrEmpty(_phoneFaxInput)
                    || string.IsNullOrEmpty(_birthDateInput) || _selectedGender == null)
                        return;

                    PatientModel patientModel = new PatientModel();
                    patientModel.Fio.Surname = _surnameInput;
                    patientModel.Fio.Name = _nameInput;
                    patientModel.Fio.Patronymic = _patronymicInput;
                    patientModel.PhoneNumber = int.Parse(_phoneFaxInput);
                    patientModel.BirthDate = DateTime.Parse(_birthDateInput);
                    patientModel.ApplicationDate = DateTime.Now;
                    patientModel.Gender = _selectedGender;

                    var res = ApiAccessPoint.Instance.CreatePatient(patientModel, 
                        MainWindowVM.GetInstance().JwtToken);
                    res.ContinueWith(t => OnUserCreated(t.Result));

                }));
            }
        }

        private string _surnameInput;
        private string _nameInput;
        private string _patronymicInput;
        private string _phoneFaxInput;
        private string _birthDateInput;
        private string _genderInput;

        private RelayCommand _createUserCommand;
        private GenderModel _selectedGender;
        private ObservableCollection<GenderModel> _allGenders;

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

        public bool IsCreationInteractable
        {
            get => _isCreationInteractable;
            set
            {
                _isCreationInteractable = value;
                OnPropertyChanged("IsCreationInteractable");
            }
        }

        private ObservableCollection<SomeUser> _listPeople;

        private bool _isCreationInteractable;

        public UserPageVM()
        {
            _allGenders = new ObservableCollection<GenderModel>();
            _listPeople = new ObservableCollection<SomeUser>
           {
               new SomeUser { Id = 1, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 2, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 3, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 4, Birthday="2000.02.05", Fio = "Some some some"}
           };
           SendRequests();
        }

        protected override void SendRequests()
        {
            IsCreationInteractable = false;
            var res = ApiAccessPoint.Instance.GetGenders(MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(res => OnGetGenders(res.Result));
        }

        private void OnUserCreated(IFlurlResponse? result)
        {
            IsCreationInteractable = true;
            if (result == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }

            if (result.StatusCode == 200)
                ShowMessageBox("Added", "Responce",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            else
                ShowMessageBox($"Error {result.StatusCode}", "Responce",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);

        }

        private void OnGetGenders(IFlurlResponse? responce)
        {
            IsCreationInteractable = true;
            if(responce == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }

            if(responce.StatusCode == 200)
            {
                List<GenderModel> list = responce.GetJsonAsync<List<GenderModel>>().Result;
                AllGenders = new ObservableCollection<GenderModel>(list);
            }
        }
    }
}
