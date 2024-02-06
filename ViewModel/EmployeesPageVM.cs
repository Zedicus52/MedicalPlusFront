using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

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

        public string EmployeeRole
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

        public ObservableCollection<string> EmployeesRoles
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
                    EmployeeRole = string.Empty;
                    EmployeeLogin = string.Empty;
                    EmployeePassword = string.Empty;
                    EmployeeGender = string.Empty;
                }));
            }
        }

        private string _employeeSurname;
        private string _employeeName;
        private string _employeePatronymic;
        private string _employeeRole;
        private string _employeeLogin;
        private string _employeePassword;
        private string _employeeGender;
        private ObservableCollection<string> _employeesRoles;

        private RelayCommand _createEmployee;
        #endregion


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
            _employeesRoles = new ObservableCollection<string>()
            {
                "Admin",
                "Ne Admin",
                "User"
            };
            _listPeople = new ObservableCollection<SomeUser>
           {
               new SomeUser { Id = 1, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 2, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 3, Birthday="2000.02.05", Fio = "Some some some"},
               new SomeUser { Id = 4, Birthday="2000.02.05", Fio = "Some some some"}
           };
        }
    }
}
