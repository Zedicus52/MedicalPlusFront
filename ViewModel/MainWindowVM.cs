﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MedicalPlusFront.Utils;
using MedicalPlusFront.WebModels;

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

        public Visibility AdminComponentsVisibility
        {
            get => _adminComponentsVisibility;
            set
            {
                _adminComponentsVisibility = value;
                OnPropertyChanged("AdminComponentsVisibility");
            }
        }

        private BaseVM _selectedVM;

        private LoginResult _loginResult;

        private Visibility _adminComponentsVisibility;

        private CancellationTokenSource _checkExpirationTokenSource;
        private Task _checkExpirationTask;
        private TimeSpan _queryDelay;

        public MainWindowVM()
        {
            _queryDelay = new TimeSpan(0, 1, 0);
            _adminComponentsVisibility = Visibility.Collapsed;
            _selectedVM = new LoginPageVM();
        }

        public void SetViewModel(BaseVM baseVM)
        {
            if (baseVM == null)
                return;
            _selectedVM = baseVM;
            OnPropertyChanged("SelectedViewModel");
        }

        public async void SetLoginResult(LoginResult loginResult)
        {
            _loginResult = loginResult;
            
            var res = await ApiAccessPoint.Instance.CheckAccess("ADMIN", _loginResult.Token);
            if (res != null)
            {
                if (res.StatusCode == 200)
                    AdminComponentsVisibility = Visibility.Visible;
            }
                
            _checkExpirationTokenSource = new CancellationTokenSource();
            _checkExpirationTask = new Task(CheckExpirationTime, _checkExpirationTokenSource.Token);
            _checkExpirationTask.Start();
        }

        private async void CheckExpirationTime()
        {
            while (_checkExpirationTokenSource.Token.IsCancellationRequested == false)
            {
                DateTime now = DateTime.UtcNow;
                if (now > _loginResult.Expiration)
                {
                    _checkExpirationTokenSource.Cancel();
                    break;
                }
                await Task.Delay(_queryDelay);
            }
            SetViewModel(new LoginPageVM());
            _loginResult = new LoginResult();
        }
    }
}
