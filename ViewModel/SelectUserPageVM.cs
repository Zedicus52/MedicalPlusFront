using Flurl.Http;
using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.Utils;
using MedicalPlusFront.WebModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    class SelectUserPageVM : BaseVM
    {

        #region Find Users Props

        public string FindInput_PhoneNumber
        {
            get => _findInput_PhoneNumber;
            set
            {
                _findInput_PhoneNumber = value;
                OnPropertyChanged(nameof(FindInput_PhoneNumber));
            }
        }

        public string FindInput_PatientId
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

                    List<PatientModel> searchFrom = new List<PatientModel>(_allPatients);

                    if (string.IsNullOrEmpty(FindInput_PatientId) == false)
                        FindById();

                    if (string.IsNullOrEmpty(FindInput_PhoneNumber) == false)
                        searchFrom = new List<PatientModel>(FindByPhoneNumber(searchFrom));

                    if (string.IsNullOrEmpty(FindInput_Fio) == false)
                        searchFrom = new List<PatientModel>(FindByFio(searchFrom));

                    if (string.IsNullOrEmpty(FindInput_BeforeDate) == false || string.IsNullOrEmpty(FindInput_AfterDate) == false)
                        searchFrom = new List<PatientModel>(FindByBirthday(searchFrom));

                    foreach (var patient in searchFrom)
                        PatientsToView.Add(patient);
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
                    ClearFindInputs();
                }));
            }
        }


        private string _findInput_PhoneNumber;
        private string _findInput_PatientId;
        private string _findInput_Fio;
        private bool _findInput_CaseSensetive;
        private string _findInput_AfterDate;
        private string _findInput_BeforeDate;
        private RelayCommand _findCommand;
        private RelayCommand _clearFindCommand;

        #endregion

        #region Create User Props

        public string PatientId
        {
            get => _patientId;
            set
            {
                _patientId = value;
                OnPropertyChanged("PatientId");
            }
        }

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

        public RelayCommand SelectUserCommand
        {
            get
            {
                return _createUserCommand ?? (_createUserCommand = new RelayCommand(() =>
                {
                    if (SelectedPatient != null)
                    {
                        MainWindowVM.GetInstance().ShowPatientDetails(SelectedPatient);
                        MainWindowVM.GetInstance().SetVM<DisasePageVM>();
                    }
                }));
            }
        }

        private string _surnameInput;
        private string _patientId;
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

        public PatientModel SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                OnPropertyChanged("SelectedPatient");
                if (value != default)
                {
                    SetDataToInputs();
                    _isUpdating = true;
                }
            }
        }

        public RelayCommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new RelayCommand(() =>
                {
                    _isUpdating = false;
                    SelectedPatient = new PatientModel();
                    ClearCreatingInputs();
                }));
            }
        }

        private ObservableCollection<PatientModel> _allPatients;
        private ObservableCollection<PatientModel> _patientsToView;

        private bool _isCreationInteractable;
        private bool _isUpdating;
        private PatientModel _selectedPatient;
        private RelayCommand _clearCommand;

        public SelectUserPageVM()
        {
            _selectedPatient = new PatientModel();
            _isUpdating = true;
            _allGenders = new ObservableCollection<GenderModel>();
            _allPatients = new ObservableCollection<PatientModel>();
            _patientsToView = new ObservableCollection<PatientModel>();
            SendRequests();
        }

        protected override void SendRequests()
        {
            IsCreationInteractable = true;
            GetAllGenders();
            GetAllPatients();
        }

        private void SetDataToInputs()
        {
            //IsCreationInteractable = false;
            SurnameInput = _selectedPatient.Fio.Surname;
            NameInput = _selectedPatient.Fio.Name;
            PatronymicInput = _selectedPatient.Fio.Patronymic;
            PhoneFaxInput = _selectedPatient.PhoneNumber.ToString();
            BirthDateInput = _selectedPatient.BirthDate.ToShortDateString();
            SelectedGender = _selectedPatient.Gender;
        }

        private void ClearFindInputs()
        {
            IsCreationInteractable = false;
            FindInput_PatientId = string.Empty;
            FindInput_PhoneNumber = string.Empty;
            FindInput_Fio = string.Empty;
            FindInput_AfterDate = string.Empty;
            FindInput_BeforeDate = string.Empty;
            FindInput_CaseSensetive = false;
        }

        private void ClearCreatingInputs()
        {
            IsCreationInteractable = false;
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

        private List<PatientModel> FindByBirthday(List<PatientModel> currentPatients)
        {

            List<PatientModel> listAfter = new();
            List<PatientModel> listBefore = new();
            if (string.IsNullOrEmpty(FindInput_AfterDate) == false)
            {
                DateTime after = DateTime.Parse(FindInput_AfterDate);
                listAfter.AddRange(currentPatients.Where(p => p.BirthDate > after));
            }

            if (string.IsNullOrEmpty(FindInput_BeforeDate) == false)
            {
                DateTime before = DateTime.Parse(FindInput_BeforeDate);
                listBefore.AddRange(currentPatients.Where(p => p.BirthDate < before));
            }

            IEnumerable<PatientModel> list;
            if (listBefore.Any() && listAfter.Any())
                list = listBefore.Intersect(listAfter);
            else
                list = listAfter.Any() ? listAfter.Union(listBefore) : listBefore;

            var result = new List<PatientModel>();
            foreach (var patient in list)
            {
                result.Add(patient);
            }
            return result;
        }


        private List<PatientModel> FindByFio(List<PatientModel> currentPatients)
        {
            IEnumerable<PatientModel> list;

            if (_findInput_CaseSensetive)
                list = currentPatients.Where(x => x.Fio.ToString().StartsWith(FindInput_Fio));
            else
                list = currentPatients.Where(x => x.Fio.ToString().ToLower().StartsWith(FindInput_Fio.ToLower()));

            var result = new List<PatientModel>();
            foreach (var patient in list)
            {
                result.Add(patient);
            }
            return result;
        }

        private void FindById()
        {
            int id = int.Parse(FindInput_PatientId);
            var list = _allPatients.Where(x => x.IdPatient.Equals(id));
            foreach (var patient in list)
            {
                PatientsToView.Add(patient);
            }
        }

        private List<PatientModel> FindByPhoneNumber(List<PatientModel> currentPatients)
        {
            var list = currentPatients.Where(x => x.PhoneNumber.ToString().StartsWith(FindInput_PhoneNumber.ToString()));

            List<PatientModel> result = new();
            foreach (var patient in list)
            {
                result.Add(patient);
            }
            return result;
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
