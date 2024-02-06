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
    /// Логика взаимодействия для ProfileCard.xaml
    /// </summary>
    public partial class ProfileCard : UserControl
    {
        #region RoleProperty
        private static readonly DependencyProperty RoleProperty =
            DependencyProperty.Register("RoleText", typeof(string), typeof(ProfileCard));

        public string RoleText
        {
            get { return (string)GetValue(RoleProperty); }
            set { SetValue(RoleProperty, value); }
        }
        #endregion

        #region ProfileCommandProperty
        public static readonly DependencyProperty ProfileCommandProperty =
           DependencyProperty.Register("ProfileCommand", typeof(ICommand),
               typeof(ProfileCard),
               new FrameworkPropertyMetadata());

        public ICommand ProfileCommand
        {
            get { return (ICommand)GetValue(ProfileCommandProperty); }
            set { SetValue(ProfileCommandProperty, value); }
        }
        #endregion

        #region ExitCommandProperty
        public static readonly DependencyProperty ExitCommandProperty =
           DependencyProperty.Register("ExitCommand", typeof(ICommand),
               typeof(ProfileCard),
               new FrameworkPropertyMetadata());

        public ICommand ExitCommand
        {
            get { return (ICommand)GetValue(ExitCommandProperty); }
            set { SetValue(ExitCommandProperty, value); }
        }
        #endregion

        public ProfileCard()
        {
            InitializeComponent();
        }
    }
}
