using System;
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
        #region Singelton
        public static MainWindowVM GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MainWindowVM();
            }
            return _instance;
        }
        private static MainWindowVM _instance;
        #endregion
        public PatientModel SelectedPatient { get; private set; }

        
        public string JwtToken => _loginResult.Token;

        public BaseVM SelectedViewModel
        {
            get => _selectedVM;
            set
            {
                if (value == null || _selectedVM == value)
                    return;

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
        private BaseVM _previousVM;

        private readonly HashSet<BaseVM> _allVms;
        private readonly TimeSpan _queryDelay;

        private LoginResult _loginResult;

        private Visibility _adminComponentsVisibility;

        private CancellationTokenSource _checkExpirationTokenSource;
        private Task _checkExpirationTask;

        public MainWindowVM()
        {
            _queryDelay = new TimeSpan(0, 1, 0);
            _adminComponentsVisibility = Visibility.Visible;
            _allVms = new HashSet<BaseVM>();
            SetVM<LoginPageVM>();   
        }

        public void SetVM<T>() where T : BaseVM, new()
        {
            BaseVM vm = _allVms.FirstOrDefault(v => v is T);
            if(vm != null)
            {
                _previousVM = _selectedVM;
                SelectedViewModel = vm;
                SelectedViewModel.OnModelSelected();
                return;
            }

            T newVm = new();
            _allVms.Add(newVm);
            _previousVM = _selectedVM;
            SelectedViewModel = newVm;
        }

        public void SetSelectedPatient(PatientModel model) => SelectedPatient = model;

        public void ShowPatientDetails(PatientModel patient)
        {
            SelectedPatient = patient;
            SetVM<SelectUserPageVM>();
        }
        public void LogOut()
        {
            _checkExpirationTokenSource.Cancel();
            ShowAuthPageAndResetToken();
        }

        public async void SetLoginResult(LoginResult loginResult)
        {
            _loginResult = loginResult;
            
            var res = await ApiAccessPoint.Instance.CheckAccess("ADMIN", _loginResult.Token);
            if (res != null)
            {
                if (res.StatusCode == 200)
                    AdminComponentsVisibility = Visibility.Visible;
                else
                    AdminComponentsVisibility = Visibility.Collapsed;
            }
                
            _checkExpirationTokenSource = new CancellationTokenSource();
            _checkExpirationTask = new Task(CheckExpirationTime, _checkExpirationTokenSource.Token);
            _checkExpirationTask.Start();
        }

        private async void CheckExpirationTime()
        {
            bool cancelFromHere = false;
            while (_checkExpirationTokenSource.Token.IsCancellationRequested == false)
            {
                DateTime now = DateTime.UtcNow;
                if (now > _loginResult.Expiration)
                {
                    _checkExpirationTokenSource.Cancel();
                    cancelFromHere = true;
                    break;
                }
                await Task.Delay(_queryDelay);
            }
            if(cancelFromHere)
                ShowAuthPageAndResetToken();
        }

        private void ShowAuthPageAndResetToken()
        {
            SetVM<LoginPageVM>();
            _loginResult = new LoginResult();
            AdminComponentsVisibility = Visibility.Collapsed;
        }

        public void BackToPreviousPage()
        {
            if(_previousVM != null)
                SelectedViewModel = _previousVM;
        }

        protected override void SendRequests()
        {
        }
    }
}
