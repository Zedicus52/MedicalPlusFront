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

namespace MedicalPlusFront.View.CustomControlls
{
    /// <summary>
    /// Interaction logic for ResearchCard.xaml
    /// </summary>
    public partial class ResearchCard : UserControl
    {
        #region MainTitleProperty

        public static readonly DependencyProperty MainTitleProperty =
            DependencyProperty.Register("MainTitleText", typeof(string), typeof(ResearchCard));

        public string MainTitleText
        {
            get { return (string)GetValue(MainTitleProperty); }
            set { SetValue(MainTitleProperty, value); }
        }

        #endregion

        #region AdditionInfoProperty
        public static readonly DependencyProperty AdditionInfoProperty =
            DependencyProperty.Register("AdditionInfo", typeof(string), typeof(ResearchCard));

        public string AdditionInfo
        {
            get { return (string)GetValue(AdditionInfoProperty); }
            set { SetValue(AdditionInfoProperty, value); }
        }

        #endregion

        #region IdProperty
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("ResearchIdText", typeof(string), typeof(ResearchCard));

        public string ResearchIdText
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        #endregion

        public ResearchCard()
        {
            InitializeComponent();
        }
    }
}
