using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    class SortEmployeeVM : BaseVM
    {
        public string RoleInput
        {
            get => _roleInput;
            set
            {
                _roleInput = value;
                OnPropertyChanged("RoleInput");
            }
        }

        public string IdEmployeeInput
        {
            get => _idEmployeeInput;
            set
            {
                _idEmployeeInput = value;
                OnPropertyChanged("IdEmployeeInput");
            }
        }

        public string FullNameEmployeeInput
        {
            get => _fullNameEmployeeInput;
            set
            {
                _fullNameEmployeeInput = value;
                OnPropertyChanged("IdEmployeeInput");
            }
        }

        public SortEmployeeVM()
        {
            RoleInput = string.Empty;
            IdEmployeeInput = string.Empty;
            FullNameEmployeeInput = string.Empty;
        }

        private string _roleInput;
        private string _idEmployeeInput;
        private string _fullNameEmployeeInput;
    }
}
