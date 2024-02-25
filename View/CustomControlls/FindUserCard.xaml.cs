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
    /// Логика взаимодействия для FindUserCard.xaml
    /// </summary>
    public partial class FindUserCard : UserControl
    {

        #region PhoneNumberProperty
        private static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register("PhoneNumberInput", typeof(string), typeof(FindUserCard));

        public string PhoneNumberInput
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }
        #endregion

        #region IdNumberProperty
        private static readonly DependencyProperty IdNumberProperty =
            DependencyProperty.Register("IdNumberInput", typeof(string), typeof(FindUserCard));

        public string IdNumberInput
        {
            get { return (string)GetValue(IdNumberProperty); }
            set { SetValue(IdNumberProperty, value); }
        }
        #endregion

        #region FioProperty
        private static readonly DependencyProperty FioProperty =
            DependencyProperty.Register("FioInput", typeof(string), typeof(FindUserCard));

        public string FioInput
        {
            get { return (string)GetValue(FioProperty); }
            set { SetValue(FioProperty, value); }
        }
        #endregion

        #region CaseSensetiveProperty
        private static readonly DependencyProperty CaseSensetiveProperty =
            DependencyProperty.Register("CaseSensetiveInput", typeof(bool), typeof(FindUserCard));

        public bool CaseSensetiveInput
        {
            get { return (bool)GetValue(CaseSensetiveProperty); }
            set { SetValue(CaseSensetiveProperty, value); }
        }
        #endregion

        #region AfterDateProperty
        private static readonly DependencyProperty AfterDateProperty =
            DependencyProperty.Register("AfterDateInput", typeof(string), typeof(FindUserCard));

        public string AfterDateInput
        {
            get { return (string)GetValue(AfterDateProperty); }
            set { SetValue(AfterDateProperty, value); }
        }
        #endregion

        #region BeforeDateProperty
        private static readonly DependencyProperty BeforeDateProperty =
            DependencyProperty.Register("BeforeDateInput", typeof(string), typeof(FindUserCard));

        public string BeforeDateInput
        {
            get { return (string)GetValue(BeforeDateProperty); }
            set { SetValue(BeforeDateProperty, value); }
        }
        #endregion

        #region FindCommandProperty
        public static readonly DependencyProperty FindCommandProperty =
           DependencyProperty.Register("FindCommand", typeof(ICommand),
               typeof(FindUserCard),
               new FrameworkPropertyMetadata());

        public ICommand FindCommand
        {
            get { return (ICommand)GetValue(FindCommandProperty); }
            set { SetValue(FindCommandProperty, value); }
        }
        #endregion

        #region ClearCommandProperty
        public static readonly DependencyProperty ClearCommandProperty =
           DependencyProperty.Register("ClearCommand", typeof(ICommand),
               typeof(FindUserCard),
               new FrameworkPropertyMetadata());

        public ICommand ClearCommand
        {
            get { return (ICommand)GetValue(ClearCommandProperty); }
            set { SetValue(ClearCommandProperty, value); }
        }
        #endregion

        public FindUserCard()
        {
            InitializeComponent();
        }
    }
}
