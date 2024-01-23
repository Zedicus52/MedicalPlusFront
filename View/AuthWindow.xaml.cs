using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalPlusFront
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private TextBlock _passwordPlaceHolder;

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void PasswordText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (_passwordPlaceHolder == null)
                _passwordPlaceHolder = (TextBlock)this.FindName("PasswordPlaceHolder");


            string pass = ((PasswordBox)sender).Password;
            if (string.IsNullOrEmpty(pass))
                _passwordPlaceHolder.Visibility = Visibility.Visible;
            else
                _passwordPlaceHolder.Visibility = Visibility.Collapsed;

        }
    }
}
