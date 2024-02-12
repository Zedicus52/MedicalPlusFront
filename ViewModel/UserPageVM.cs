using Flurl.Http;
using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.Utils;
using MedicalPlusFront.WebModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;

namespace MedicalPlusFront.ViewModel
{
    public class UserPageVM : BaseVM
    {
        #region Find Users Props

        public int FindInput_PhoneNumber
        {
            get => _findInput_PhoneNumber;
            set
            {
                _findInput_PhoneNumber = value;
                OnPropertyChanged(nameof(FindInput_PhoneNumber));
            }
        }

        public int FindInput_PatientId
        {
            get => _findInput_PatientId;
            set
            {
                _findInput_PatientId = value;
                OnPropertyChanged(nameof(FindInput_PatientId));
            }
        }

        public string FindInput_Fio
        {
            get => _findInput_Fio;
            set
            {
                _findInput_Fio = value;
                OnPropertyChanged(nameof(FindInput_Fio));
            }

        }

        public bool FindInput_CaseSensetive
        {
            get => _findInput_CaseSensetive;
            set
            {
                _findInput_CaseSensetive = value;
                OnPropertyChanged(nameof(FindInput_CaseSensetive));
            }
        }

        public string FindInput_AfterDate
        {
            get => _findInput_AfterDate;
            set
            {
                _findInput_AfterDate = value;
                OnPropertyChanged(nameof(FindInput_AfterDate));
            }
        }

        public string FindInput_BeforeDate
        {
            get => _findInput_BeforeDate;
            set
            {
                _findInput_BeforeDate = value;
                OnPropertyChanged(nameof(FindInput_BeforeDate));
            }
        }

        public RelayCommand FindCommand
        {
            get
            {
                return _findCommand ?? (_findCommand = new RelayCommand(() =>
                {
                    PatientsToView = new ObservableCollection<PatientModel>();

                    if (FindInput_PatientId != 0)
                        FindById();
                    if (FindInput_PhoneNumber != 0)
                        FindByPhoneNumber();
                    if (string.IsNullOrEmpty(FindInput_Fio) == false)
                        FindByFio();


                }));
            }
        }

        public RelayCommand ClearFindCommand
        {
            get
            {
                return _clearFindCommand ?? (_clearFindCommand = new RelayCommand(() =>
                {
                    PatientsToView = new ObservableCollection<PatientModel>(_allPatients);
                }));
            }
        }


        private int _findInput_PhoneNumber;
        private int _findInput_PatientId;
        private string _findInput_Fio;
        private bool _findInput_CaseSensetive;
        private string _findInput_AfterDate;
        private string _findInput_BeforeDate;
        private RelayCommand _findCommand;
        private RelayCommand _clearFindCommand;

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

        public GenderModel? SelectedGender
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

                    TryCreatePatient();

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

        public ObservableCollection<PatientModel> PatientsToView
        {
            get => _patientsToView;
            set
            {
                _patientsToView = value;
                OnPropertyChanged("PatientsToView");
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

        private ObservableCollection<PatientModel> _allPatients;
        private ObservableCollection<PatientModel> _patientsToView;

        private bool _isCreationInteractable;

        public UserPageVM()
        {
            _allGenders = new ObservableCollection<GenderModel>();
            _allPatients = new ObservableCollection<PatientModel>();
            _patientsToView = new ObservableCollection<PatientModel>();
            SendRequests();
        }

        protected override void SendRequests()
        {
            IsCreationInteractable = false;
            GetAllGenders();
            GetAllPatients();
        }

        private void TryCreatePatient()
        {
            PatientModel patientModel = new();
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
        }

        private void ClearInputs()
        {
            SurnameInput = string.Empty;
            NameInput = string.Empty;
            PatronymicInput = string.Empty;
            PhoneFaxInput = string.Empty;
            BirthDateInput = string.Empty;
            SelectedGender = default;
        }

        #region Sending requests to the server

        private void GetAllGenders()
        {
            var gendersTask = ApiAccessPoint.Instance.GetGenders(MainWindowVM.GetInstance().JwtToken);
            gendersTask.ContinueWith(res => OnGetGenders(res.Result));
        }

        private void GetAllPatients()
        {
            var patientTasks = ApiAccessPoint.Instance.GetAllPatients(MainWindowVM.GetInstance().JwtToken);
            patientTasks.ContinueWith(res => OnGetAllPatients(res.Result));
        }
        #endregion

        #region Finding 
        private void FindByFio()
        {
            var list = _allPatients.Where(x => x.Fio.ToString().StartsWith(FindInput_Fio));
            foreach (var patient in list)
            {
                PatientsToView.Add(patient);
            }
        }

        private void FindById()
        {
            var list = _allPatients.Where(x => x.IdPatient.Equals(FindInput_PatientId));
            foreach (var patient in list)
            {
                PatientsToView.Add(patient);
            }
        }

        private void FindByPhoneNumber()
        {
            var list = _allPatients.Where(x => x.PhoneNumber.ToString().StartsWith(FindInput_PhoneNumber.ToString()));
            foreach (var patient in list)
            {
                PatientsToView.Add(patient);
            }
        }
        #endregion

        #region Receiving responses from the server

        private void OnGetAllPatients(IFlurlResponse? result)
        {
            if (result == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }
            if (result.StatusCode == 200)
            {
                List<PatientModel> models = result.GetJsonAsync<List<PatientModel>>().Result;
                _allPatients = new ObservableCollection<PatientModel>(models);
                PatientsToView = new ObservableCollection<PatientModel>(models);
            }
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
            {
                ShowMessageBox("Новий паціент був доданий!", "Результат",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                GetAllPatients();
                ClearInputs();
            }
            else
                ShowMessageBox($"Шось пішло не так. Статус код: {result.StatusCode}", "Помилка",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }

        private void OnGetGenders(IFlurlResponse? responce)
        {
            IsCreationInteractable = true;
            if (responce == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }

            if (responce.StatusCode == 200)
            {
                List<GenderModel> list = responce.GetJsonAsync<List<GenderModel>>().Result;
                AllGenders = new ObservableCollection<GenderModel>(list);
            }
        }
        #endregion
    }
}
