using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    public class MainWindowVM : BaseVM
    {
        public static MainWindowVM GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MainWindowVM();
            }
            return _instance;
        }
        private static MainWindowVM _instance;

        public BaseVM SelectedViewModel
        {
            get => _selectedVM;
            set
            {
                _selectedVM = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        private BaseVM _selectedVM;

        public MainWindowVM()
        {
            _selectedVM = new LoginPageVM();
        }

        public void SetViewModel(BaseVM baseVM)
        {
            if (baseVM == null)
                return;
            _selectedVM = baseVM;
            OnPropertyChanged("SelectedViewModel");
        }

    }
}
