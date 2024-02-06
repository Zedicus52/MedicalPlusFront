using System;
using System.Collections;
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
    /// Логика взаимодействия для SortEmployeeCard.xaml
    /// </summary>
    public partial class SortEmployeeCard : UserControl
    {
        #region RolesProperty
        private static readonly DependencyProperty RolesProperty =
            DependencyProperty.Register("Roles", typeof(IEnumerable), typeof(SortEmployeeCard));

        public IEnumerable Roles
        {
            get { return (IEnumerable)GetValue(RolesProperty); }
            set { SetValue(RolesProperty, value); }
        }

        #region SelectedRoleProperty
        private static readonly DependencyProperty SelectedRoleProperty =
            DependencyProperty.Register("SelectedRole", typeof(object), typeof(SortEmployeeCard));

        public object SelectedRole
        {
            get { return (object)GetValue(SelectedRoleProperty); }
            set { SetValue(SelectedRoleProperty, value); }
        }
        #endregion
        #endregion

        #region IdNumberInputPropery
        private static readonly DependencyProperty IdNumberInputProperty =
            DependencyProperty.Register("IdNumber", typeof(string), typeof(SortEmployeeCard));

        public string IdNumber
        {
            get { return (string)GetValue(IdNumberInputProperty); }
            set { SetValue(IdNumberInputProperty, value); }
        }
        #endregion

        #region FioInputPropery
        private static readonly DependencyProperty FioInputProperty =
            DependencyProperty.Register("FioInput", typeof(string), typeof(SortEmployeeCard));

        public string FioInput
        {
            get { return (string)GetValue(FioInputProperty); }
            set { SetValue(FioInputProperty, value); }
        }
        #endregion

        #region CaseSensetivePropery
        private static readonly DependencyProperty CaseSensetiveProperty =
            DependencyProperty.Register("CaseSensetive", typeof(bool), typeof(SortEmployeeCard));

        public bool CaseSensetive
        {
            get { return (bool)GetValue(CaseSensetiveProperty); }
            set { SetValue(CaseSensetiveProperty, value); }
        }
        #endregion
        public SortEmployeeCard()
        {
            InitializeComponent();
        }
    }
}
