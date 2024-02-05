using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
	}
}
