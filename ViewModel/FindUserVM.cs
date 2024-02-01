using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    class FindUserVM : BaseVM
    {
        public string PhoneNumberInput
        {
            get => _phoneNumberInput;
            set
            {
                _phoneNumberInput = value;
                OnPropertyChanged("PhoneNumberInput");
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

        public string IdNumberInput
        {
            get => _idNumberInput;
            set
            {
                _idNumberInput = value;
                OnPropertyChanged("IdNumberInput");
            }
        }

        public string FullNameInput
        {
            get => _fullNameInput;
            set
            {
                _fullNameInput = value;
                OnPropertyChanged("FullNameInput");
            }
        }

        public string AfterDateInput
        {
            get => _afterDateInput;
            set
            {
                _afterDateInput = value;
                OnPropertyChanged("AfterDateInput");
            }
        }

        public string BeforeDateInput
        {
            get => _beforeDateInput;
            set
            {
                _beforeDateInput = value;
                OnPropertyChanged("BeforeDateInput");
            }
        }

        private string _phoneNumberInput;
        private string _birthDateInput;
        private string _idNumberInput;
        private string _fullNameInput;
        private string _afterDateInput;
        private string _beforeDateInput;

        public FindUserVM()
        {
            PhoneNumberInput = string.Empty;
            IdNumberInput = string.Empty;
            FullNameInput = string.Empty;
            AfterDateInput = string.Empty;
            BeforeDateInput = string.Empty;
        }
    }
}
