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
    public partial class PatientInfoCard : UserControl
    {
        #region IconProperty
        private static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("IconPatientPath", typeof(string), typeof(PatientInfoCard));

        public string IconPatientPath
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        #endregion

        #region NameProperty
        private static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("NamePatient", typeof(string), typeof(PatientInfoCard));

        public string NamePatient
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        #endregion

        #region SurnameProperty
        private static readonly DependencyProperty SurnameProperty =
            DependencyProperty.Register("SurnamePatient", typeof(string), typeof(PatientInfoCard));

        public string SurnamePatient
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }
        #endregion

        #region PatronymicProperty
        private static readonly DependencyProperty PatronymicProperty =
            DependencyProperty.Register("PatronymicPatient", typeof(string), typeof(PatientInfoCard));

        public string PatronymicPatient
        {
            get { return (string)GetValue(PatronymicProperty); }
            set { SetValue(PatronymicProperty, value); }
        }
        #endregion

        #region DateBirthProperty
        private static readonly DependencyProperty DateBirthProperty =
            DependencyProperty.Register("DateBirthPatient", typeof(string), typeof(PatientInfoCard));

        public string DateBirthPatient
        {
            get { return (string)GetValue(DateBirthProperty); }
            set { SetValue(DateBirthProperty, value); }
        }
        #endregion

        #region GenderProperty
        private static readonly DependencyProperty GenderProperty =
            DependencyProperty.Register("GenderPatient", typeof(string), typeof(PatientInfoCard));

        public string GenderPatient
        {
            get { return (string)GetValue(GenderProperty); }
            set { SetValue(GenderProperty, value); }
        }
        #endregion

        #region ApplicationDateProperty
        private static readonly DependencyProperty ApplicationDateProperty =
            DependencyProperty.Register("ApplicationDatePatient", typeof(string), typeof(PatientInfoCard));

        public string ApplicationDatePatient
        {
            get { return (string)GetValue(ApplicationDateProperty); }
            set { SetValue(ApplicationDateProperty, value); }
        }
        #endregion

        public PatientInfoCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
