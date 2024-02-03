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
        private static readonly DependencyProperty roleProperty =
            DependencyProperty.Register("RoleText", typeof(string), typeof(ProfileCard));

        public string RoleText
        {
            get => (string)GetValue(roleProperty);
            set => SetValue(roleProperty, value);
        }

        public ProfileCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
