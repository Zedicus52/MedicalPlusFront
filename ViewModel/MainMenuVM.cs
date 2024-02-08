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

		public RelayCommand ProfileCommand
		{
			get
			{
				return _profileCommand ?? (_profileCommand = new RelayCommand(() =>
				{
                }));
			}
		}

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

		private RelayCommand _profileCommand;
		private RelayCommand _exitCommand;
	}
}
