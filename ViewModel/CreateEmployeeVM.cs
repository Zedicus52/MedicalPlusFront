using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    class CreateEmployeeVM : BaseVM
    {
        public string SurnameEmployeeInput
        {
            get => _surnameEmployeeInput;
            set
            {
                _surnameEmployeeInput = value;
                OnPropertyChanged("SurnameEmployeeInput");
            }
        }

        public string NameEmployeeInput
        {
            get => _nameEmployeeInput;
            set
            {
                _nameEmployeeInput = value;
                OnPropertyChanged("NameEmployeeInput");
            }
        }

        public string PatronymicEmployeeInput
        {
            get => _patronymicEmployeeInput;
            set
            {
                _patronymicEmployeeInput = value;
                OnPropertyChanged("PatronymicEmployeeInput");
            }
        }

        public string RoleEmployeeInput
        {
            get => _roleEmployeeInput;
            set
            {
                _roleEmployeeInput = value;
                OnPropertyChanged("RoleEmployeeInput");
            }
        }

        public string LoginEmployeeInput
        {
            get => _loginEmployeeInput;
            set
            {
                _loginEmployeeInput = value;
                OnPropertyChanged("LoginEmployeeInput");
            }
        }

        public string PasswordEmployeeInput
        {
            get => _passwordEmployeeInput;
            set
            {
                _passwordEmployeeInput = value;
                OnPropertyChanged("PasswordEmployeeInput");
            }
        }

        public RelayCommand SaveEmployeeCommand
        {
            get
            {
                return _createEmployeeCommand ?? (_createEmployeeCommand = new RelayCommand(() =>
                {
                    SurnameEmployeeInput = string.Empty;
                    NameEmployeeInput = string.Empty;
                    PatronymicEmployeeInput = string.Empty;
                    RoleEmployeeInput = string.Empty;
                    LoginEmployeeInput = string.Empty;
                    PasswordEmployeeInput = string.Empty;
                }));
            }
        }

        private string _surnameEmployeeInput;
        private string _nameEmployeeInput;
        private string _patronymicEmployeeInput;
        private string _roleEmployeeInput;
        private string _loginEmployeeInput;
        private string _passwordEmployeeInput;

        private RelayCommand _createEmployeeCommand;
    }
}
