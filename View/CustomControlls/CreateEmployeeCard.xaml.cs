using MedicalPlusFront.ValidationRules;
using MedicalPlusFront.View.CustomControlls;
using MedicalPlusFront.WebModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для CreateEmployeeCard.xaml
    /// </summary>
    public partial class CreateEmployeeCard : UserControl
    {
        #region IdTextProperty
        private static readonly DependencyProperty IdTextProperty =
            DependencyProperty.Register("TextIdCreate", typeof(string), typeof(CreateEmployeeCard));

        public string TextIdCreate
        {
            get { return (string)GetValue(IdTextProperty); }
            set { SetValue(IdTextProperty, value);}
        }
        #endregion

        #region SurnameInputPropery
        private static readonly DependencyProperty SurnameInputProperty =
            DependencyProperty.Register("SurnameInput", typeof(string), typeof(CreateEmployeeCard));

        public string SurnameInput
        {
            get { return (string)GetValue(SurnameInputProperty); }
            set { SetValue(SurnameInputProperty, value); }
        }
        #endregion

        #region NameInputProperty
        private static readonly DependencyProperty NameInputProperty =
            DependencyProperty.Register("NameInput", typeof(string), typeof(CreateEmployeeCard));

        public string NameInput
        {
            get { return (string)GetValue(NameInputProperty); }
            set { SetValue(NameInputProperty, value); }
        }
        #endregion

        #region PatronicInputProperty
        private static readonly DependencyProperty PatronymicInputProperty =
            DependencyProperty.Register("PatronymicInput", typeof(string), typeof(CreateEmployeeCard));

        public string PatronymicInput
        {
            get { return (string)GetValue(PatronymicInputProperty); }
            set { SetValue(PatronymicInputProperty, value); }
        }
        #endregion

        #region LoginInputProperty
        private static readonly DependencyProperty LoginInputProperty =
            DependencyProperty.Register("LoginInput", typeof(string), typeof(CreateEmployeeCard));

        public string LoginInput
        {
            get { return (string)GetValue(LoginInputProperty); }
            set { SetValue(LoginInputProperty, value); }
        }
        #endregion

        #region PasswordInputProperty
        private static readonly DependencyProperty PasswordInputProperty =
            DependencyProperty.Register("PasswordInput", typeof(string), 
                typeof(CreateEmployeeCard), new PropertyMetadata(default,PasswordInputChanged));

        private static void PasswordInputChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue != null) 
            {
                if (e.NewValue is string s)
                {
                    if(s.Equals(string.Empty))
                        (d as CreateEmployeeCard).ClearPasswordBox();
                }
            }
        }

        private void ClearPasswordBox()
        {
            _mainPasswordBox.Password = string.Empty;
        }

        public string PasswordInput
        {
            get { return (string)GetValue(PasswordInputProperty); }
            set { SetValue(PasswordInputProperty, value); }
        }
        #endregion

        #region RolesProperty
        private static readonly DependencyProperty RolesProperty =
            DependencyProperty.Register("UserRoles", typeof(IEnumerable), typeof(CreateEmployeeCard));

        public IEnumerable UserRoles
        {
            get { return (IEnumerable)GetValue(RolesProperty); }
            set { SetValue(RolesProperty, value); }
        }
        #endregion

        #region SelectedRoleProperty
        private static readonly DependencyProperty SelectedRoleProperty =
            DependencyProperty.Register("SelectedRole", typeof(object), typeof(CreateEmployeeCard));

        public object SelectedRole
        {
            get { return (object)GetValue(SelectedRoleProperty); }
            set { SetValue(SelectedRoleProperty, value); }
        }
        #endregion

        #region GenderProperty
        private static readonly DependencyProperty GenderProperty =
           DependencyProperty.Register("GenderInput", 
               typeof(string), typeof(CreateEmployeeCard),
               new PropertyMetadata(default, OnGenderPropertyChanged));

        private static void OnGenderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue != null) 
            {
                if(e.NewValue is string gender) 
                {
                    if (gender.Equals(string.Empty))
                        (d as CreateEmployeeCard).ClearGenderSelection();
                }
            }
        }

        private void ClearGenderSelection()
        {
            _lastClickedButton.Background = (Brush)new BrushConverter().ConvertFrom("#0905");
        }

        public string GenderInput
        {
            get { return (string)GetValue(GenderProperty); }
            set { SetValue(GenderProperty, value); }
        }
        #endregion

        #region EmailProperty
        private static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register("EmailInput", typeof(string), typeof(CreateEmployeeCard));

        public string EmailInput
        {
            get { return(string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        #endregion

        #region SaveButtonCommandProperty
        public static readonly DependencyProperty SaveButtonCommandProperty =
            DependencyProperty.Register("SaveCommand", typeof(ICommand),
                typeof(CreateEmployeeCard),
                new FrameworkPropertyMetadata());

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveButtonCommandProperty); }
            set { SetValue(SaveButtonCommandProperty, value); }
        }
        #endregion

        #region AllGenders
        private static readonly DependencyProperty AllGenderProperty =
            DependencyProperty.Register("AllGenders", typeof(IEnumerable), typeof(CreateEmployeeCard));

        public IEnumerable<GenderModel> AllGenders
        {
            get { return (IEnumerable<GenderModel>)GetValue(AllGenderProperty); }
            set { SetValue(AllGenderProperty, value); }
        }


        #region Selected Gender
        private static readonly DependencyProperty SelectedGenderProperty =
            DependencyProperty.Register("SelectedGender", typeof(object), typeof(CreateEmployeeCard), new PropertyMetadata(default, OnGenderChanged));

        private static void OnGenderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CreateEmployeeCard).SetSelectedGender(e.NewValue as GenderModel);
        }

        private void SetSelectedGender(GenderModel v)
        {
            if (v != null)
            {
                ComboxWithPlaceHolder box = (ComboxWithPlaceHolder)FindName("GenderCombox");

                var list = AllGenders.ToList();

                var item = list.FirstOrDefault(x => x.IdGender.Equals(v.IdGender));
                box.SetSelectedIndex(list.IndexOf(item));
            }
        }

        public object SelectedGender
        {
            get { return (IEnumerable)GetValue(SelectedGenderProperty); }
            set { SetValue(SelectedGenderProperty, value); }
        }
        #endregion
        #endregion


        private PasswordBox _mainPasswordBox;
        private Button _lastClickedButton;


        public CreateEmployeeCard()
        {
            InitializeComponent();
            _mainPasswordBox = (PasswordBox)FindName("PasswordEmployeeText");
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            _lastClickedButton = sender as Button;

            if (_lastClickedButton.Name == "SaveEmployeeBtn")
            {
                return;
            }

            if (_lastClickedButton.Name.Contains(Genders.Female))
                SetValue(GenderProperty, Genders.Female);
            else if (_lastClickedButton.Name.Contains(Genders.Male))
                SetValue(GenderProperty, Genders.Male);
            else
                SetValue(GenderProperty, Genders.Other);

            foreach (var btn in CreateUserCard.FindVisualButton<Button>(this))
            {
                if (btn.Name != "SaveEmployeeBtn")
                {
                    btn.Background = (Brush)new BrushConverter().ConvertFrom("#0905");
                }
            }

            _lastClickedButton.Background = (Brush)new BrushConverter().ConvertFrom("#575176");
        }

        public static IEnumerable<T> FindVisualButton<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childofChild in FindVisualButton<T>(child))
                    {
                        yield return childofChild;
                    }
                }
            }
        }

        private void PasswordText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            /*if (_passwordBox == null)
                _passwordBox = (PasswordBox)sender;
            if (_passwordPlaceHolder == null)
                _passwordPlaceHolder = (TextBlock)FindName("PasswordPlaceHolder");
            _passwordErrorText = (TextBlock)FindName("PasswordErrorText");*/

            string pass = ((PasswordBox)sender).Password;
            SetValue(PasswordInputProperty, pass);
            
            /*if (string.IsNullOrEmpty(pass))
                _passwordPlaceHolder.Visibility = Visibility.Visible;
            else
                _passwordPlaceHolder.Visibility = Visibility.Collapsed;
            
            var res = _passwordValidator.Validate(pass, CultureInfo.CurrentCulture);
            if(res.IsValid)
                _passwordErrorText.Text = string.Empty;
            else
                _passwordErrorText.Text = res.ErrorContent.ToString();*/
        }

    }
}
