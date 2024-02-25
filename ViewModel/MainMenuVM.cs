using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalPlusFront.ViewModel
{
    public class MainMenuVM : BaseVM
    {
	    public Visibility AdminComponentsVisibility
	    {
		    get => MainWindowVM.GetInstance().AdminComponentsVisibility;
		    set
		    {
			    MainWindowVM.GetInstance().AdminComponentsVisibility = value;
			    OnPropertyChanged("AdminComponentsVisibility");

		    }
	    }

        #region Profile Command

        public RelayCommand ProfileCommand
		{
			get
			{
				return _profileCommand ?? (_profileCommand = new RelayCommand(() =>
				{
                }));
			}
		}

        private RelayCommand _profileCommand;
        #endregion

        #region Exit Command
        public RelayCommand ExitCommand
		{
			get
			{
				return _exitCommand ?? (_exitCommand = new RelayCommand(() =>
				{
					MainWindowVM.GetInstance().LogOut();
                }));
			}
		}

		private RelayCommand _exitCommand;
        #endregion

        #region Open Users Command
        public RelayCommand OpenUsers
        {
            get
            {
                return _openUsersCommand ?? (_openUsersCommand = new RelayCommand(() =>
                {
                    MainWindowVM.GetInstance().SetVM<UserPageVM>();
                }));
            }
        }

        private RelayCommand _openUsersCommand;
        #endregion

        #region Open Journal Command
        public RelayCommand OpenJournal
        {
            get
            {
                return _openJournalCommand ?? (_openJournalCommand = new RelayCommand(() =>
                {
                    MainWindowVM.GetInstance().SetVM<LogbookPageVM>();
                }));
            }
        }

        private RelayCommand _openJournalCommand;
        #endregion

        #region Open Employees Command
        public RelayCommand OpenEmployees
        {
            get
            {
                return _openEmployeesCommand ?? (_openEmployeesCommand = new RelayCommand(() =>
                {
                    MainWindowVM.GetInstance().SetVM<EmployeesPageVM>();
                }));
            }
        }

        private RelayCommand _openEmployeesCommand;
        #endregion


        protected override void SendRequests()
        {
        }
    }
}
