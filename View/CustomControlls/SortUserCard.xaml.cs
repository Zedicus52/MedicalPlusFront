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
    /// Логика взаимодействия для SortUserCard.xaml
    /// </summary>
    public partial class SortUserCard : UserControl
    {

        #region HeavinesProperty
        private static readonly DependencyProperty HeavinesProperty =
            DependencyProperty.Register("Heavines", typeof(IEnumerable), typeof(SortUserCard));

        public IEnumerable Heavines
        {
            get { return (IEnumerable)GetValue(HeavinesProperty); }
            set { SetValue(HeavinesProperty, value); }
        }

        #region SelectedHeavinesProperty
        private static readonly DependencyProperty SelectedHeavinesProperty =
            DependencyProperty.Register("SelectedHeavines", typeof(object), typeof(SortUserCard));

        public object SelectedHeavines
        {
            get { return (object)GetValue(SelectedHeavinesProperty); }
            set { SetValue(SelectedHeavinesProperty, value); }
        }
        #endregion
        #endregion

        #region CreationTimesProperty
        private static readonly DependencyProperty CreationTimesProperty =
            DependencyProperty.Register("CreationTimes", typeof(IEnumerable), typeof(SortUserCard));

        public IEnumerable CreationTimes
        {
            get { return (IEnumerable)GetValue(CreationTimesProperty); }
            set { SetValue(CreationTimesProperty, value); }
        }

        #region SelectedCreationTimeProperty
        private static readonly DependencyProperty SelectedCreationTimeProperty =
            DependencyProperty.Register("SelectedCreationTime", typeof(object), typeof(SortUserCard));

        public object SelectedCreationTime
        {
            get { return (object)GetValue(SelectedCreationTimeProperty); }
            set { SetValue(SelectedCreationTimeProperty, value); }
        }
        #endregion
        #endregion

        #region UserNamesProperty
        private static readonly DependencyProperty UserNamesProperty =
            DependencyProperty.Register("UserNames", typeof(IEnumerable), typeof(SortUserCard));

        public IEnumerable UserNames
        {
            get { return (IEnumerable)GetValue(UserNamesProperty); }
            set { SetValue(UserNamesProperty, value); }
        }

        #region SelectedUserNameProperty
        private static readonly DependencyProperty SelectedUserNameProperty =
            DependencyProperty.Register("SelectedUserName", typeof(object), typeof(SortUserCard));

        public object SelectedUserName
        {
            get { return (object)GetValue(SelectedUserNameProperty); }
            set { SetValue(SelectedUserNameProperty, value); }
        }
        #endregion
        #endregion

        public SortUserCard()
        {
            InitializeComponent();
        }
    }
}
