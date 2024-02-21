using Flurl.Http;
using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.Utils;
using MedicalPlusFront.WebModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace MedicalPlusFront.ViewModel
{
    public class DisasePageVM : BaseVM
    {
        public string DiagnosisInput
        {
            get => _diagnosisInput;
            set 
            {
                _diagnosisInput = value;
                OnPropertyChanged("DiagnosisInput");    
            }
        }
        public string ResearchNumberInput
        {
            get => _researchNumberInput;
            set
            {
                _researchNumberInput = value;
                OnPropertyChanged("ResearchNumberInput");
            }
        }
        public string MicroDescInput
        {
            get => _microDescInput;
            set
            {
                _microDescInput = value;
                OnPropertyChanged("MicroDescInput");
            }
        }
        public string MacroDescInput
        {
            get => _macroDescInput;
            set
            {
                _macroDescInput = value;
                OnPropertyChanged("MacroDescInput");
            }
        }
        public DifficultyModel? SelectedDifficulty
        {
            get => _selectedDifficulty;
            set
            {
                _selectedDifficulty = value;
                OnPropertyChanged("SelectedDifficulty");
            }
        }
        public string CreatedDate
        {
            get => _creationDate;
            set
            {
                _creationDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }
        public string ModifiedDate
        {
            get => _modifiedDate;
            set
            {
                _modifiedDate = value;
                OnPropertyChanged("ModifiedDate");
            }
        }

        public string OperationDateInput
        {
            get => _operationDateInput;
            set
            {
                _operationDateInput = value;
                OnPropertyChanged("OperationDateInput");
            }
        }

        public string OperationTypeInput
        {
            get => _operationTypeInput;
            set
            {
                _operationTypeInput = value;
                OnPropertyChanged("OperationTypeInput");
            }
        }

        public string ClinicalDataInput
        {
            get => _clinicalDataInput;
            set
            {
                _clinicalDataInput = value;
                OnPropertyChanged("ClinicalDataInput");
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


        public ObservableCollection<DifficultyModel> AllDifficults
        {
            get => _allDifficults;
            set
            {
                _allDifficults = value;
                OnPropertyChanged("AllDifficults");
            }
        }

        public ObservableCollection<ProblemModel> AllProblems
        {
            get => _allProblems;
            set
            {
                _allProblems = value;
                OnPropertyChanged("AllProblems");
            }
        }

        public ProblemModel SelectedProblem
        {
            get => _selectedProblem;
            set
            {
                _selectedProblem = value;
                OnPropertyChanged("SelectedProblem");
                if (value != default)
                {
                    SetDataToInputs();
                    _isUpdating = true;
                }
            }
        }


        public PatientModel SelectedPatient => MainWindowVM.GetInstance().SelectedPatient;


        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
            }
        }

        public RelayCommand CreateCommand
        {
            get
            {
                return _createCommand ?? (_createCommand = new RelayCommand(() =>
                {
                    if (string.IsNullOrEmpty(_diagnosisInput) || string.IsNullOrEmpty(_researchNumberInput)
                    || string.IsNullOrEmpty(_clinicalDataInput) || _selectedDifficulty == null)
                        return;

                    if (_isUpdating == false)
                        TryCreateProblem();
                    else
                        TryUpdateProblem();
                }));
            }
        }

        public RelayCommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new RelayCommand(() =>
                {
                    _isUpdating = false;
                    ClearCreatingInput();
                    _selectedProblem = new ProblemModel();
                }));
            }
        }



        private bool _isCreationInteractable;
        private bool _isUpdating;

        private string _diagnosisInput;
        private string _researchNumberInput;
        private string _creationDate;
        private string _modifiedDate;
        private string _operationDateInput;
        private string _operationTypeInput;
        private string _clinicalDataInput;
        private string _macroDescInput;
        private string _microDescInput;
        private DifficultyModel _selectedDifficulty;
        private bool _isEditing;
        private ObservableCollection<DifficultyModel> _allDifficults;
        private ObservableCollection<ProblemModel> _allProblems;
        private ProblemModel? _selectedProblem;

        private RelayCommand _createCommand;
        private RelayCommand _clearCommand;

        public Visibility AdminComponentsVisibility
        {
            get => MainWindowVM.GetInstance().AdminComponentsVisibility;
            set
            {
                MainWindowVM.GetInstance().AdminComponentsVisibility = value;
                OnPropertyChanged("AdminComponentsVisibility");
            }
        }

        public DisasePageVM()
        {
            _isUpdating = false;
            _selectedDifficulty = new DifficultyModel();
            _selectedProblem = new ProblemModel();
            _allDifficults = new ObservableCollection<DifficultyModel>();
            _allProblems = new ObservableCollection<ProblemModel>();
            SendRequests();
        }


        private void SetDataToInputs()
        {
            ResearchNumberInput = _selectedProblem.ResearchNumber;
            DiagnosisInput = _selectedProblem.Diagnosis;
            ClinicalDataInput = _selectedProblem.ClinicalData;
            SelectedDifficulty = _allDifficults.FirstOrDefault(d => d.IdDifficulty.Equals(_selectedProblem.IdDifficulty));

            MacroDescInput = _selectedProblem.MacroDesc;
            MicroDescInput= _selectedProblem.MicroDesc;
            OperationTypeInput = _selectedProblem.OperationType;
            OperationDateInput = _selectedProblem.OperationDate.Equals(DateTime.MinValue) ? "" : _selectedProblem.OperationDate.ToShortDateString();
        }
        private void OnProblemCreated(IFlurlResponse? result)
        {
            IsCreationInteractable = true;

            if(result == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }

            if(result.StatusCode == 200)
            {
                ShowMessageBox("Нова проблема була додана!", "Результат",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                ClearCreatingInput();
                GetAllPatientProblems();
            }
            else
            {
                ShowMessageBox($"Шось пішло не так. Статус код:{result.StatusCode}", "Результат",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void OnProblemUpdated(IFlurlResponse? result)
        {
            IsCreationInteractable = true;


            if (result == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }

            if (result.StatusCode == 200)
            {
                ShowMessageBox("Дані дослідження були оновленні!", "Результат",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                ClearCreatingInput();
                _isUpdating = false;
                GetAllPatientProblems();

            }
            else
            {
                ShowMessageBox($"Шось пішло не так. Статус код:{result.StatusCode}", "Результат",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void OnGetAllDifficulties(IFlurlResponse? response)
        {
            IsCreationInteractable = true;

            if(response == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }

            if(response.StatusCode == 200)
            {
                List<DifficultyModel> model = response.GetJsonAsync<List<DifficultyModel>>().Result;
                AllDifficults = new ObservableCollection<DifficultyModel>(model);
            }
        }

        private void OnGetPatientProblems(IFlurlResponse? response)
        {
            if (response == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }

            if (response.StatusCode == 200)
            {
                List<ProblemModel> model = response.GetJsonAsync<List<ProblemModel>>().Result;
                AllProblems = new ObservableCollection<ProblemModel>(model);    
            }
        }


        private void ClearCreatingInput()
        {
            DiagnosisInput = string.Empty;
            ClinicalDataInput = string.Empty;
            ResearchNumberInput = string.Empty;
            MicroDescInput = string.Empty;
            MacroDescInput = string.Empty;
            SelectedDifficulty = default;
            OperationDateInput = string.Empty;
            OperationTypeInput = string.Empty;
        }


        private void GetAllDifficulties()
        {
            var res = ApiAccessPoint.Instance.GetDifficulties(MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(t => OnGetAllDifficulties(res.Result));
        }

        private void GetAllPatientProblems()
        {
            var res = ApiAccessPoint.Instance.GetPatientsProblems(SelectedPatient.IdPatient,MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(t => OnGetPatientProblems(t.Result));    
        }

        private void TryUpdateProblem()
        {
            _selectedProblem.ResearchNumber = _researchNumberInput;
            _selectedProblem.Diagnosis = _diagnosisInput;
            _selectedProblem.ClinicalData = _clinicalDataInput;
            _selectedProblem.IdDifficulty = _selectedDifficulty.IdDifficulty;
            _selectedProblem.IdPatient = SelectedPatient.IdPatient;

            _selectedProblem.MacroDesc = _macroDescInput;
            _selectedProblem.MicroDesc = _microDescInput;

            _selectedProblem.OperationType = _operationTypeInput;
            _selectedProblem.OperationDate = DateTime.Parse(_operationDateInput);

            var res = ApiAccessPoint.Instance.UpdateProblem(_selectedProblem,
                MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(x => OnProblemUpdated(x.Result));
        }

        private void TryCreateProblem()
        {
            ProblemModel model = new();
            model.ResearchNumber = _researchNumberInput;
            model.Diagnosis = _diagnosisInput;
            model.ClinicalData = _clinicalDataInput;
            model.IdDifficulty = _selectedDifficulty.IdDifficulty;
            model.IdPatient = SelectedPatient.IdPatient;

            model.MacroDesc = _macroDescInput;
            model.MicroDesc = _microDescInput;
            model.IdUser = string.Empty;
            model.IdCreateUser = string.Empty;
            model.OperationType = _operationTypeInput;
            model.OperationDate = string.IsNullOrEmpty(_operationDateInput) ? DateTime.MinValue : DateTime.Parse(_operationDateInput);

            var res = ApiAccessPoint.Instance.CreateProblem(model,
                MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(x => OnProblemCreated(x.Result));
        }

        protected override void SendRequests()
        {
            GetAllDifficulties();
            GetAllPatientProblems();
        }
    }
}
