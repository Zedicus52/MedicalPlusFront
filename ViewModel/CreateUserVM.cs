using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    class CreateUserVM : BaseVM
    {
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
            get => _surnameInput;
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

        public RelayCommand CreateUserCommand
        {
            get
            {
                return _createUserCommand ?? (_createUserCommand = new RelayCommand(() =>
                {
                    SurnameInput = string.Empty;
                    NameInput = string.Empty;
                    PatronymicInput = string.Empty;
                    PhoneFaxInput = string.Empty;
                    BirthDateInput = string.Empty;
                }));
            }
        }


        public string _surnameInput;
        public string _nameInput;
        public string _patronymicInput;
        public string _phoneFaxInput;
        public string _birthDateInput;

        public RelayCommand _createUserCommand;
    }
}
