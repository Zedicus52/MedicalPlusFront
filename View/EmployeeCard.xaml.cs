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
    /// Логика взаимодействия для EmployeeCard.xaml
    /// </summary>
    public partial class EmployeeCard : UserControl
    {
        private static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("EmployeeImg", typeof(string), typeof(EmployeeCard));
        private static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("EmployeeName", typeof(string), typeof(EmployeeCard));
        private static readonly DependencyProperty RoleProperty =
            DependencyProperty.Register("EmployeeRole", typeof(string), typeof(EmployeeCard));
        private static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("EmployeeId", typeof(string), typeof(EmployeeCard));

        public string EmployeeImg
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value);}
        }

        public string EmployeeName
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string EmployeeRole
        {
            get { return (string)GetValue(RoleProperty); }
            set { SetValue(RoleProperty, value); }
        }

        public string EmployeeId
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public EmployeeCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
