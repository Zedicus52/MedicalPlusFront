using Flurl.Http;
using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.Utils;
using MedicalPlusFront.WebModels;
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

        public bool IsNotUpdating
        {
            get => _isNotUpdating;
            set
            {
                _isNotUpdating = value;
                OnPropertyChanged("IsNotUpdating");
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
                    if (!string.IsNullOrEmpty(_diagnosisInput) && !string.IsNullOrEmpty(_researchNumberInput)
                    && !string.IsNullOrEmpty(_clinicalDataInput) && _selectedDifficulty != null)
                        TryCreateProblem();
                }));
            }
        }

        private bool _isCreationInteractable;
        private bool _isNotUpdating;

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

        private RelayCommand _createCommand;

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
            _isNotUpdating = true;
            _selectedDifficulty = new DifficultyModel();
            _allDifficults = new ObservableCollection<DifficultyModel>();
            SendRequests();
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

        private void ClearCreatingInput()
        {
            DiagnosisInput = string.Empty;
            ClinicalDataInput = string.Empty;
            ResearchNumberInput = string.Empty;
            MicroDescInput = string.Empty;
            MacroDescInput = string.Empty;
            SelectedDifficulty = default;
        }


        private void GetAllDifficulties()
        {
            var res = ApiAccessPoint.Instance.GetDifficulties(MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(t => OnGetAllDifficulties(res.Result));
        }



        private void TryCreateProblem()
        {
            ProblemModel model = new();
            model.Diagnosis = _diagnosisInput;
            model.ClinicalData = _clinicalDataInput;
            model.IdDifficulty = _selectedDifficulty.IdDifficulty;
            model.IdPatient = SelectedPatient.IdPatient;

            model.MacroDesc = string.Empty;
            model.MicroDesc = string.Empty;
            model.IdUser = string.Empty;
            model.IdCreateUser = string.Empty;
            model.OperationType = string.Empty;
            model.OperationDate = System.DateTime.MinValue;

            var res = ApiAccessPoint.Instance.CreateProblem(model,
                MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(x => OnProblemCreated(x.Result));
        }

        protected override void SendRequests()
        {
            IsCreationInteractable = true;
            GetAllDifficulties();
        }
    }
}
