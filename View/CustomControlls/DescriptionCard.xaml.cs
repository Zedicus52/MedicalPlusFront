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
    /// Логика взаимодействия для DescriptionCard.xaml
    /// </summary>
    public partial class DescriptionCard : UserControl
    {
        #region MacroProperty
        private static readonly DependencyProperty MacroProperty =
            DependencyProperty.Register("MacroDesc", typeof(string), typeof(DescriptionCard));

        public string MacroDesc
        {
            get { return (string)GetValue(MacroProperty); }
            set { SetValue(MacroProperty, value); }
        }
        #endregion

        #region MicroProperty
        private static readonly DependencyProperty MicroProperty =
            DependencyProperty.Register("MicroDesc", typeof(string), typeof(DescriptionCard));

        public string MicroDesc
        {
            get { return (string)GetValue(MicroProperty); }
            set { SetValue(MicroProperty, value); }
        }
        #endregion
        public DescriptionCard()
        {
            InitializeComponent();
        }
    }
}
