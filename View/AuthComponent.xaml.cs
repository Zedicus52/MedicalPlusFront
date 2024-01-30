using System;
using System.Collections.Generic;
using System.Globalization;
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
using MedicalPlusFront.ValidationRules;

namespace MedicalPlusFront.View
{
    /// <summary>
    /// Interaction logic for AuthComponent.xaml
    /// </summary>
    public partial class AuthComponent : UserControl
    {

        private TextBlock _passwordPlaceHolder;
        private TextBlock _passwordErrorText;
        private PasswordBox _passwordBox;
        private PasswordValidator _passwordValidator;

        public AuthComponent()
        {
            InitializeComponent();
            _passwordValidator = new PasswordValidator();
        }

        private void PasswordText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (_passwordPlaceHolder == null)
                _passwordPlaceHolder = (TextBlock)FindName("PasswordPlaceHolder");
            if (_passwordBox == null)
                _passwordBox = (PasswordBox)sender;
            if(_passwordErrorText == null)
                _passwordErrorText = (TextBlock)FindName("PasswordErrorText");


            string pass = ((PasswordBox)sender).Password;
            if (string.IsNullOrEmpty(pass))
                _passwordPlaceHolder.Visibility = Visibility.Visible;
            else
                _passwordPlaceHolder.Visibility = Visibility.Collapsed;

            var res = _passwordValidator.Validate(pass, CultureInfo.CurrentCulture);
            if (res.IsValid)
                _passwordErrorText.Text = string.Empty;
            else
                _passwordErrorText.Text = res.ErrorContent.ToString();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_passwordBox == null)
                return;

            //_passwordBox.Password = "";
        }
    }
}
