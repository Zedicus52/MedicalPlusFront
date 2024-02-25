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
using MedicalPlusFront.WebModels;

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
                    //MainWindowVM.GetInstance().SetVM<MainMenuVM>();

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
        private void OnLoginCompleted(IFlurlResponse? response)
        {
            if (response == null)
            {
                ShowMessageBox("Немає відповіді від сервера!", "Помилка доступу до сервера", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                IsInteractable = true;
                return;
            }
            
            if (response.StatusCode > 199 && response.StatusCode <= 299)
            {
                LoginResult data = response.GetJsonAsync<LoginResult>().Result;
                if(data != null)
                    MainWindowVM.GetInstance().SetLoginResult(data);
                MainWindowVM.GetInstance().SetVM<MainMenuVM>();
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

        protected override void SendRequests()
        {
        }
    }
    
}
