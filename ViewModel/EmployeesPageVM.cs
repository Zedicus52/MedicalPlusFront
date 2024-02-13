using Flurl.Http;
using GalaSoft.MvvmLight.Command;
using MedicalPlusFront.Utils;
using MedicalPlusFront.WebModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public string EmployeeEmail
        {
            get => _employeeEmail;
            set
            {
                _employeeEmail = value;
                OnPropertyChanged("EmployeeEmail");
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
                    if (string.IsNullOrEmpty(_employeeSurname) || string.IsNullOrEmpty(_employeeName) || string.IsNullOrEmpty(_employeeEmail) ||
                    string.IsNullOrEmpty(_employeePatronymic) || _employeeRole == null || string.IsNullOrEmpty(_employeeLogin) ||
                    string.IsNullOrEmpty(_employeePassword) || string.IsNullOrEmpty(_employeeGender) || _employeesRoles == null)
                        return;

                    TryCreateEmployee();
                }));
            }
        }

        private string _employeeSurname;
        private string _employeeName;
        private string _employeePatronymic;
        private string _employeeEmail;
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

        public bool IsCreationInteractable
        {
            get => _isCreationInteractable;
            set
            {
                _isCreationInteractable = value;
                OnPropertyChanged("IsCreationInteractable");
            }
        }

        public RelayCommand FindEmployee
        {
            get
            {
                return _findCommand ?? (_findCommand = new RelayCommand(() =>
                {
                    EmployeesView = new ObservableCollection<EmployeeModel>();

                    if (!string.IsNullOrEmpty(FilterEmployeeRole))
                        FindByRole();
                    if (!string.IsNullOrEmpty(FilterEmployeeId))
                        FindById();
                    if (!string.IsNullOrEmpty(FilterEmployeeFio))
                        FindByFio();

                }));
            }
        }

        public RelayCommand ClearEmployee
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new RelayCommand(() =>
                {
                    EmployeesView = new ObservableCollection<EmployeeModel>(_allEmployees);
                }));
            }
        }

        private bool _caseSensetive;
        private string _filterEmployeeRole;
        private string _filterEmployeeId;
        private string _filterEmployeeFio;
        private bool _isCreationInteractable;
        private RelayCommand _findCommand;
        private RelayCommand _clearCommand;
        #endregion

        private void GetAllEmployees()
        {
            var employeesTasks = ApiAccessPoint.Instance.GetAllEmployees(MainWindowVM.GetInstance().JwtToken);
            employeesTasks.ContinueWith(task => OnGetAllEmployees(task.Result));
        }

        private ObservableCollection<EmployeeModel> _allEmployees;
        private ObservableCollection<EmployeeModel> EmployeesView;

        private void TryCreateEmployee()
        {
            EmployeeModel employeeModel = new();
            employeeModel.Fio.Name = _employeeName;
            employeeModel.Fio.Surname = _employeeSurname;
            employeeModel.Fio.Patronymic = _employeePatronymic;
            employeeModel.Email = _employeeEmail;
            employeeModel.Role = _employeeRole;
            employeeModel.Login = _employeeLogin;
            employeeModel.Password = _employeePassword;

            var res = ApiAccessPoint.Instance.CreateEmployee(employeeModel, 
                MainWindowVM.GetInstance().JwtToken);
            res.ContinueWith(x => OnEmoloyeeCreated(x.Result));
        }

        private void OnGetAllEmployees(IFlurlResponse? result)
        {
            if (result == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }
            if (result.StatusCode == 200)
            {
                List<EmployeeModel> models = result.GetJsonAsync<List<EmployeeModel>>().Result;
                _allEmployees = new ObservableCollection<EmployeeModel>(models);
                EmployeesView = new ObservableCollection<EmployeeModel>(models);
            }
        }

        private void FindByRole()
        {
            var list = _allEmployees.Where(x => x.Role.Equals(EmployeeRole));
            foreach (var employee in list)
            {
                EmployeesView.Add(employee);
            }
        }

        private void FindById()
        {
            var list = _allEmployees.Where(x => x.IdEmployee.Equals(FilterEmployeeId));
            foreach(var employee in list)
            {
                EmployeesView.Add(employee);
            }
        }

        private void FindByFio()
        {
            var list = _allEmployees.Where(x => x.Fio.ToString().StartsWith(FilterEmployeeFio));
            foreach(var employee in list)
            {
                EmployeesView.Add(employee);
            }
        }

        private void OnEmoloyeeCreated(IFlurlResponse? result)
        {
            IsCreationInteractable = true;
            if (result == null)
            {
                ShowConnectionErrorMessageBox();
                return;
            }

            if (result.StatusCode == 200)
            {
                ShowMessageBox("Новий паціент був доданий!", "Результат",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                GetAllEmployees();
            }
            else
                ShowMessageBox($"Шось пішло не так. Статус код: {result.StatusCode}", "Помилка",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }

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
                ShowConnectionErrorMessageBox();
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
