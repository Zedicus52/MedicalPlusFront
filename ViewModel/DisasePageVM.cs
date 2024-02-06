using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

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
        public string SelectedDifficulty
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
        public ObservableCollection<string> AllDifficults
        {
            get => _allDifficults;
            set
            {
                _allDifficults = value;
                OnPropertyChanged("AllDifficults");
            }
        }
        public RelayCommand SelectPatientCommand
        {
            get
            {
                return _selectPatienCommand ?? (_selectPatienCommand = new RelayCommand(() =>
                {

                }));
            }
        }


        private string _diagnosisInput;
        private string _researchNumberInput;
        private string _creationDate;
        private string _modifiedDate;
        private string _macroDescInput;
        private string _microDescInput;
        private string _selectedDifficulty;
        private ObservableCollection<string> _allDifficults;

        private RelayCommand _selectPatienCommand;


    }
}
