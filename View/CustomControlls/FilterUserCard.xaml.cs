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
    /// Логика взаимодействия для FilterUserCard.xaml
    /// </summary>
    public partial class FilterUserCard : UserControl
    {
        #region PatientFioProperty
        private static readonly DependencyProperty PatientFioProperty =
            DependencyProperty.Register("PatientFioInput", typeof(string), typeof(FilterUserCard));

        public string PatientFioInput
        {
            get { return (string)GetValue(PatientFioProperty); }
            set { SetValue(PatientFioProperty, value); }
        }
        #endregion

        #region DoctorFioProperty
        private static readonly DependencyProperty DoctorFioProperty =
            DependencyProperty.Register("DoctorFioInput", typeof(string), typeof(FilterUserCard));

        public string DoctorFioInput
        {
            get { return (string)GetValue(DoctorFioProperty); }
            set { SetValue(DoctorFioProperty, value); }
        }
        #endregion

        #region DiagnosisProperty
        private static readonly DependencyProperty DiagnosisProperty =
            DependencyProperty.Register("DiagnosisInput", typeof(string), typeof(FilterUserCard));

        public string DiagnosisInput
        {
            get { return (string)GetValue(DiagnosisProperty); }
            set { SetValue(DiagnosisProperty, value); }
        }
        #endregion

        #region ResearchNumberProperty
        private static readonly DependencyProperty ResearchNumberProperty =
            DependencyProperty.Register("ResearchNumberInput", typeof(string), typeof(FilterUserCard));

        public string ResearchNumberInput
        {
            get { return (string)GetValue(ResearchNumberProperty); }
            set { SetValue(ResearchNumberProperty, value); }
        }
        #endregion

        #region CaseSensetiveProperty
        private static readonly DependencyProperty CaseSensetiveProperty =
            DependencyProperty.Register("CaseSensetiveInput", typeof(bool), typeof(FilterUserCard));

        public bool CaseSensetiveInput
        {
            get { return (bool)GetValue(CaseSensetiveProperty); }
            set { SetValue(CaseSensetiveProperty, value); }
        }
        #endregion

        public FilterUserCard()
        {
            InitializeComponent();
        }
    }
}
