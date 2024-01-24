using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MedicalPlusFront.View
{
    /// <summary>
    /// Interaction logic for AuthComponent.xaml
    /// </summary>
    public partial class AuthComponent : UserControl
    {

        private TextBlock _passwordPlaceHolder;
        private PasswordBox _passwordBox;

        public AuthComponent()
        {
            InitializeComponent();
        }

        private void PasswordText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (_passwordPlaceHolder == null)
                _passwordPlaceHolder = (TextBlock)FindName("PasswordPlaceHolder");
            if (_passwordBox == null)
                _passwordBox = (PasswordBox)sender;


            string pass = ((PasswordBox)sender).Password;
            if (string.IsNullOrEmpty(pass))
                _passwordPlaceHolder.Visibility = Visibility.Visible;
            else
                _passwordPlaceHolder.Visibility = Visibility.Collapsed;

            if (DataContext != null)
            {
                ((dynamic)DataContext).PasswordInput = pass;
            }

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_passwordBox == null)
                return;

            _passwordBox.Password = "";
        }
    }
}
