using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Flurl;
using Flurl.Http;
using MedicalPlusFront.Utils;

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

        public bool IsInteractable
        {
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                OnPropertyChanged("IsInteractable");
            }
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(() =>
                {
                    if(string.IsNullOrEmpty(PasswordInput) || string.IsNullOrEmpty(LoginInput))
                        return;
                    
                    IsInteractable = false;
                    TryLogin();
                }));
            }
        }

        private async void TryLogin()
        {
            var res = await ApiAccessPoint.Instance.Login(_loginInput, _passwordInput);
            OnLoginCompleted(res);
        }

        private string _loginInput;
        private string _passwordInput;
        private bool _isInteractable;

        private RelayCommand _loginCommand;

        public LoginPageVM()
        {
            IsInteractable = true;
        }
        private void OnLoginCompleted(IFlurlResponse response)
        {
            if (response.StatusCode > 199 && response.StatusCode <= 299)
            {
                MainWindowVM.GetInstance().SetViewModel(new CreateEmployeeVM());
                LoginInput = string.Empty;
                PasswordInput = string.Empty;
            }
            else
            {
                if(response.StatusCode == 401)
                    ShowMessageBox("Неправильний логін або пароль!", "Помилка авторизації", MessageBoxButton.OK,
                        MessageBoxImage.Warning);
            }
            
            IsInteractable = true;

            
        }
    }
    
}
