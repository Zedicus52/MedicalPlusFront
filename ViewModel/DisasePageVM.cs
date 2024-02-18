using Flurl.Http;
using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.Utils;
using MedicalPlusFront.WebModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        public DifficultyModel SelectedDifficulty
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

        public PatientModel SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                OnPropertyChanged("SelectedPatient");
                if (value != null)
                {
                    IsEditing = false;
                    CheckUserAccess();
                }
            }
        }

        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
            }
        }


        public RelayCommand SelectPatientCommand
        {
            get
            {
                return _selectPatienCommand ?? (_selectPatienCommand = new RelayCommand(() =>
                {
                    MainWindowVM.GetInstance().SetVM<SelectUserPageVM>();
                }));
            }
        }

        public RelayCommand CreateCommand
        {
            get
            {
                return _createCommand ?? (_createCommand = new RelayCommand(() =>
                {
                    if (!string.IsNullOrEmpty(_diagnosisInput) && /*_researchNumberInput != null && *//*!string.IsNullOrEmpty(_creationDate) && !string.IsNullOrEmpty(_modifiedDate) &&*/
                       !string.IsNullOrEmpty(_macroDescInput) && !string.IsNullOrEmpty(_microDescInput) && _selectedDifficulty != null)
                        TryCreateProblem();
                    else if (IsNotUpdating == false && !string.IsNullOrEmpty(_diagnosisInput) && /*_researchNumberInput != null &&*//* !string.IsNullOrEmpty(_creationDate) && !string.IsNullOrEmpty(_modifiedDate) &&*/
                       !string.IsNullOrEmpty(_macroDescInput) && !string.IsNullOrEmpty(_microDescInput) && _selectedDifficulty != null)
                        TryUpdateProblem();
                }));
            }
        }

        private bool _isCreationInteractable;
        private bool _isNotUpdating;
        private ProblemModel _selectedProblem;

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
            ResearchNumberInput = string.Empty;
            MicroDescInput = string.Empty;
            MacroDescInput = string.Empty;
            CreatedDate = string.Empty;
            SelectedDifficulty = default;
            ModifiedDate = string.Empty;
        }

        private void OnUpdatedDifficulties(IFlurlResponse? response)
        {
            IsNotUpdating = true;

            if (response == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }

            if (response.StatusCode == 200)
            {
                ShowMessageBox("Дані проблеми оновлені!", "Результат",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                GetAllDifficulties();
                ClearCreatingInput();
                _selectedProblem = new ProblemModel();
            }
        }

        private void SetDataToInputs()
        {
            DiagnosisInput = _diagnosisInput;
            MacroDescInput = _macroDescInput;
            MicroDescInput = _microDescInput;
            SelectedDifficulty = _selectedDifficulty;
            SelectedPatient = MainWindowVM.GetInstance().SelectedPatient;
        }

        private void GetAllDifficulties()
        {
            var res = ApiAccessPoint.Instance.GetDifficulties(MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(t => OnGetAllDifficulties(res.Result));
        }

        private async Task CheckUserAccess()
        {
            var userId = SelectedPatient.IdPatient;
            var response = await ApiAccessPoint.Instance.GetProblems(MainWindowVM.GetInstance().JwtToken);
            if (response != null && response.StatusCode == 200)
            {
                var problems = await response.GetJsonAsync<List<ProblemModel>>();
                var existingProblem = problems.FirstOrDefault(x => x.IdPatient.Equals(userId));

                if (existingProblem != null)
                {
                    IsEditing = true; 
                    _selectedProblem = existingProblem;
                    SetDataToInputs();
                }
                else
                {
                    ClearCreatingInput();
                }
            }
            else
            {
                ShowConnectionErrorMessageBox();
            }
        }

        private void TryCreateProblem()
        {
            ProblemModel model = new ProblemModel();
            model.Diagnosis = _diagnosisInput;
            model.IdUser = string.Empty;
            model.IdDifficulty = _selectedDifficulty.IdDifficulty;
            model.IdPatient = MainWindowVM.GetInstance().SelectedPatient.IdPatient;
            model.MacroDesc = _macroDescInput;
            model.MicroDesc = _microDescInput;

            var res = ApiAccessPoint.Instance.CreateProblem(model,
                MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(x => OnProblemCreated(x.Result));
        }

        private void TryUpdateProblem()
        {
            _selectedProblem.Diagnosis = _diagnosisInput;
            _selectedProblem.IdUser = string.Empty;
            _selectedProblem.MacroDesc = _macroDescInput;
            _selectedProblem.MicroDesc = _microDescInput;
            _selectedProblem.IdDifficulty = _selectedDifficulty.IdDifficulty;
            _selectedProblem.IdPatient = MainWindowVM.GetInstance().SelectedPatient.IdPatient;

            var res = ApiAccessPoint.Instance.UpdateProblem(_selectedProblem, 
                MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(t => OnUpdatedDifficulties(t.Result));
        }

        public DisasePageVM()
        {
            _isNotUpdating = true;
            _selectedProblem = new ProblemModel();
            _selectedDifficulty = new DifficultyModel();
            _allDifficults = new ObservableCollection<DifficultyModel>();
            SendRequests();
        }

        private string _diagnosisInput;
        private string _researchNumberInput;
        private string _creationDate;
        private string _modifiedDate;
        private string _macroDescInput;
        private string _microDescInput;
        private DifficultyModel _selectedDifficulty;
        private PatientModel _selectedPatient;
        private bool _isEditing;
        private ObservableCollection<DifficultyModel> _allDifficults;

        private RelayCommand _selectPatienCommand;
        private RelayCommand _createCommand;

        protected override void SendRequests()
        {
            IsCreationInteractable = true;
            GetAllDifficulties();
        }
    }
}
