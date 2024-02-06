using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    public class TestWindowVM : BaseVM
    {
        public ObservableCollection<string> List 
        {
            get => _list;
            set
            {
                _list = value;
                OnPropertyChanged("List");
            }
        }


        public string SelectedObj
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged("SelectedObj");
            }
        }

        private string _selected;
        private ObservableCollection<string> _list;

        public TestWindowVM()
        {
            List = new ObservableCollection<string>()
            {
                "Seom",
                "Seom1",
                "Seom2"
            };
        }
    }
}
