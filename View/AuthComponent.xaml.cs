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
        public static readonly DependencyProperty LoginInputProperty =
            DependencyProperty.Register("LoginInput", typeof(string), 
                typeof(AuthComponent), 
                new FrameworkPropertyMetadata(""));

        public string LoginInput
        {
            get { return (string)GetValue(LoginInputProperty); }
            set { SetValue(LoginInputProperty, value); }
        }
        
        public static readonly DependencyProperty PasswordInputProperty =
            DependencyProperty.Register("PasswordInput", typeof(string), 
                typeof(AuthComponent), 
                new FrameworkPropertyMetadata(""));

        public string PasswordInput
        {
            get { return (string)GetValue(PasswordInputProperty); }
            set { SetValue(PasswordInputProperty, value); }
        }
        
        public static readonly DependencyProperty LoginButtonCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(ICommand), 
                typeof(AuthComponent), 
                new FrameworkPropertyMetadata());

        public ICommand LoginCommand
        {
            get { return (ICommand)GetValue(LoginButtonCommandProperty); }
            set { SetValue(LoginButtonCommandProperty, value); }
        }

        
        public AuthComponent()
        {
            InitializeComponent();
        }

        private void PasswordText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string pass = ((PasswordBox)sender).Password;
            SetValue(PasswordInputProperty, pass);
        }
    }
}
