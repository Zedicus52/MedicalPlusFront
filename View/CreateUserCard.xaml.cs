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
    /// Логика взаимодействия для CreateUserCard.xaml
    /// </summary>
    public partial class CreateUserCard : UserControl
    {
        public static readonly DependencyProperty IdCreateProperty =
            DependencyProperty.Register("TextIdCreate", typeof(string), typeof(CreateUserCard));

        public string TextIdCreate
        {
            get { return (string)GetValue(IdCreateProperty); } 
            set { SetValue(IdCreateProperty, value);}
        }

        public CreateUserCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
