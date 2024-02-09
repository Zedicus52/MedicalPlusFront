using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MedicalPlusFront.ViewModel
{
    public abstract class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        #region Back Command
        public RelayCommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand(() =>
                {
                    MainWindowVM.GetInstance().BackToPreviousPage();
                }));
            }
        }
        public RelayCommand _backCommand;

        #endregion

        public MessageBoxResult ShowMessageBox(string message, string title, MessageBoxButton buttons, MessageBoxImage image)
        {
            return MessageBox.Show(message, title, buttons, image);
        }

        protected abstract void SendRequests();

        protected void ShowConnectionErrorMessageBox()
        {
            ShowMessageBox("Немає відповіді від сервера!", "Помилка доступу до сервера", MessageBoxButton.OK,
    MessageBoxImage.Warning);
        }


    }
}
