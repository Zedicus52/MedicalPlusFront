using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    public class LoginPageVM : BaseVM
    {
        public string LoginInput
        {
            get => _loginInput;
            set 
            { 
                _loginInput = value;
                OnPropertyChanged("LoginInput");
            }
        }

        public string PasswordInput
        {
            get => _passwordInput;
            set
            {
                _passwordInput = value;
                OnPropertyChanged("PasswordInput");
            }
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(() =>
                {
                    LoginInput = string.Empty;
                    PasswordInput = string.Empty;
                    MainWindowVM.GetInstance().SetViewModel(new MainMenuVM());
                }));
            }
        }

        private string _loginInput;
        private string _passwordInput;

        private RelayCommand _loginCommand;
    }
}
