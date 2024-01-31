using MedicalPlusFront.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlusFront.ViewModel
{
    internal class ListOfPeopleVM : BaseVM
    {
        public ObservableCollection<UserCard> ListOfPeople
        {
            get => _listPeople;
            set
            {
                _listPeople = value;
                OnPropertyChanged("ListOfPeople");
            }
        }

        private ObservableCollection<UserCard> _listPeople;

        public ListOfPeopleVM()
        {
            _listPeople = new ObservableCollection<UserCard>
            {
                new UserCard{ UserImg="/View/Icons/man.png", PatientName="Іванов Іван Іванович", PatientBirth="20.10.2014", PatientId="ID: 423"},
                new UserCard{ UserImg="/View/Icons/man.png", PatientName="Іванов Іван Іванович", PatientBirth="20.10.2014", PatientId="ID: 231"},
                new UserCard{ UserImg="/View/Icons/man.png", PatientName="Іванов Іван Іванович", PatientBirth="20.10.2014", PatientId="ID: 534"},
                new UserCard{ UserImg="/View/Icons/man.png", PatientName="Іванов Іван Іванович", PatientBirth="20.10.2014", PatientId="ID: 123"},
                new UserCard{ UserImg="/View/Icons/man.png", PatientName="Іванов Іван Іванович", PatientBirth="20.10.2014", PatientId="ID: 111"},
                new UserCard{ UserImg="/View/Icons/man.png", PatientName="Іванов Іван Іванович", PatientBirth="20.10.2014", PatientId="ID: 333"}
            };
        }
    }
}
