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
    public partial class MenuCard : UserControl
    {
        #region PlaceHolderProperty
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(MenuCard));


        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        #endregion

        #region CardIconProperty
        public static readonly DependencyProperty CardIconProperty =
            DependencyProperty.Register("CardIcon", typeof(string), typeof(MenuCard));
        public string CardIcon
        {
            get { return (string)GetValue(CardIconProperty); }
            set  { SetValue(CardIconProperty, value); }
        }
        #endregion

        #region ButtonClickProperty
        public static readonly DependencyProperty ButtonClickProperty =
           DependencyProperty.Register("ButtonClick", typeof(ICommand),
               typeof(MenuCard),
               new FrameworkPropertyMetadata());

        public ICommand ButtonClick
        {
            get { return (ICommand)GetValue(ButtonClickProperty); }
            set { SetValue(ButtonClickProperty, value); }
        }
        #endregion

        public MenuCard()
        {
            InitializeComponent();
        }
    }
}