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
    public partial class UserCard : UserControl
    {
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("UserImg", typeof(string), typeof(UserCard));
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("PatientName", typeof(string), typeof(UserCard));
        public static readonly DependencyProperty BirthProperty =
            DependencyProperty.Register("PatientBirth", typeof(string), typeof(UserCard));
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("PatientId", typeof(string), typeof(UserCard));

        public string UserImg
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public string PatientName
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string PatientBirth
        {
            get { return (string)GetValue(BirthProperty); }
            set { SetValue(BirthProperty, value); }
        }

        public string PatientId
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public UserCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
