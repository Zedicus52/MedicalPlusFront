using Flurl.Http;
using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.Utils;
using MedicalPlusFront.WebModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalPlusFront.ViewModel
{
    public class EmployeesPageVM : BaseVM
    {
        #region Employee Creation Props
        public string EmployeeSurname
        {
            get => _employeeSurname;
            set
            {
                _employeeSurname = value;
                OnPropertyChanged("EmployeeSurname");
            }
        }

        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                _employeeName = value;
                OnPropertyChanged("EmployeeName");
            }
        }

        public string EmployeePatronymic
        {
            get => _employeePatronymic;
            set
            {
                _employeePatronymic = value;
                OnPropertyChanged("EmployeePatronymic");
            }
        }

        public Role EmployeeRole
        {
            get => _employeeRole;
            set
            {
                _employeeRole = value;
                OnPropertyChanged("EmployeeRole");
            }
        }

        public string EmployeeLogin
        {
            get => _employeeLogin;
            set
            {
                _employeeLogin = value;
                OnPropertyChanged("EmployeeLogin");
            }
        }

        public string EmployeeGender
        {
            get => _employeeGender;
            set
            {
                _employeeGender = value;
                OnPropertyChanged("EmployeeGender");
            }
        }

        public string EmployeePassword
        {
            get => _employeePassword;
            set
            {
                _employeePassword = value;
                OnPropertyChanged("EmployeePassword");
            }
        }

        public ObservableCollection<Role> EmployeesRoles
        {
            get => _employeesRoles;
            set
            {
                _employeesRoles = value;
                OnPropertyChanged("EmployeesRoles");
            }
        }

        public RelayCommand CreateEmployee
        {
            get
            {
                return _createEmployee ?? (_createEmployee = new RelayCommand(() =>
                {
                    EmployeeSurname = string.Empty;
                    EmployeeName = string.Empty;
                    EmployeePatronymic = string.Empty;
                    EmployeeRole = new Role();
                    EmployeeLogin = string.Empty;
                    EmployeePassword = string.Empty;
                    EmployeeGender = string.Empty;
                }));
            }
        }

        private string _employeeSurname;
        private string _employeeName;
        private string _employeePatronymic;
        private Role _employeeRole;
        private string _employeeLogin;
        private string _employeePassword;
        private string _employeeGender;
        private ObservableCollection<Role> _employeesRoles;

        private RelayCommand _createEmployee;
        #endregion

        #region Employee Filter Props

        public string FilterEmployeeRole
        {
            get => _filterEmployeeRole;
            set
            {
                _filterEmployeeRole = value;
                OnPropertyChanged("FilterEmployeeRole");
            }
        }
        public string FilterEmployeeId
        {
            get => _filterEmployeeId;
            set
            {
                _filterEmployeeId = value;
                OnPropertyChanged("FilterEmployeeId");
            }
        }
        public string FilterEmployeeFio
        {
            get => _filterEmployeeFio;
            set
            {
                _filterEmployeeFio = value;
                OnPropertyChanged("FilterEmployeeFio");
            }
        }
        public bool CaseSensetive
        {
            get => _caseSensetive;
            set
            {
                _caseSensetive = value;
                OnPropertyChanged("CaseSensetive");
            }
        }

        private bool _caseSensetive;
        private string _filterEmployeeRole;
        private string _filterEmployeeId;
        private string _filterEmployeeFio;

        #endregion

        public ObservableCollection<SomeUser> ListOfPeople
        {
            get => _listPeople;
            set
            {
                _listPeople = value;
                OnPropertyChanged("ListOfPeople");
            }
        }

        private ObservableCollection<SomeUser> _listPeople;

        public EmployeesPageVM()
        {
            _employeesRoles = new ObservableCollection<Role>();
            SendRequests();
            _listPeople = new ObservableCollection<SomeUser>
           {
               new SomeUser { Id = 1, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 2, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 3, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 4, Birthday="2000.02.05", Fio = "Some some some"}
           };
        }

        protected override void SendRequests()
        {
            var res = ApiAccessPoint.Instance.GetUserRoles(MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith((task) => OnGetRoles(task.Result));
        }

        private void OnGetRoles(IFlurlResponse? response)
        {
            if (response == null)
            {
                ShowMessageBox("Немає відповіді від сервера!", "Помилка доступу до сервера", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            if (response.StatusCode == 200)
            {
                List<Role> roles = response.GetJsonAsync<List<Role>>().Result;
                EmployeesRoles = new ObservableCollection<Role>(roles);
            }
        }

    }
}
