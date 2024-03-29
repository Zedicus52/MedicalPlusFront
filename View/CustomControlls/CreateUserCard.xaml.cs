﻿using MedicalPlusFront.WebModels;
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
using System.Linq;
using MedicalPlusFront.View.CustomControlls;

namespace MedicalPlusFront.View
{
    /// <summary>
    /// Логика взаимодействия для CreateUserCard.xaml
    /// </summary>
    public partial class CreateUserCard : UserControl
    {
        #region IdTextProperty
        public static readonly DependencyProperty IdCreateProperty =
            DependencyProperty.Register("TextIdCreate", typeof(string), typeof(CreateUserCard));

        public string TextIdCreate
        {
            get { return (string)GetValue(IdCreateProperty); }
            set { SetValue(IdCreateProperty, value); }
        }

        #endregion

        #region SurnameInputPropery
        private static readonly DependencyProperty SurnameInputProperty =
            DependencyProperty.Register("SurnameInput", typeof(string), typeof(CreateUserCard));

        public string SurnameInput
        {
            get { return (string)GetValue(SurnameInputProperty); }
            set { SetValue(SurnameInputProperty, value); }
        }
        #endregion

        #region NameInputProperty
        private static readonly DependencyProperty NameInputProperty =
            DependencyProperty.Register("NameInput", typeof(string), typeof(CreateUserCard));

        public string NameInput
        {
            get { return (string)GetValue(NameInputProperty); }
            set { SetValue(NameInputProperty, value); }
        }
        #endregion

        #region PatronicInputProperty
        private static readonly DependencyProperty PatronymicInputProperty =
            DependencyProperty.Register("PatronymicInput", typeof(string), typeof(CreateUserCard));

        public string PatronymicInput
        {
            get { return (string)GetValue(PatronymicInputProperty); }
            set { SetValue(PatronymicInputProperty, value); }
        }
        #endregion

        #region PhoneNumberProperty
        private static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register("PhoneNumberInput", typeof(string), typeof(CreateUserCard));

        public string PhoneNumberInput
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }
        #endregion

        #region MedicalCardNumberProperty
        private static readonly DependencyProperty MedicalCardNumberProperty =
            DependencyProperty.Register("MedicalCardNumberInput", typeof(string), typeof(CreateUserCard));

        public string MedicalCardNumberInput
        {
            get { return (string)GetValue(MedicalCardNumberProperty); }
            set { SetValue(MedicalCardNumberProperty, value); }
        }
        #endregion

        #region BirthDayProperty
        private static readonly DependencyProperty BirthdayProperty =
            DependencyProperty.Register("BirthdayInput", typeof(string), typeof(CreateUserCard));

        public string BirthdayInput
        {
            get { return (string)GetValue(BirthdayProperty); }
            set { SetValue(BirthdayProperty, value); }
        }
        #endregion

        #region IsSaveInteractable
        private static readonly DependencyProperty IsSaveInteractableProperty =
            DependencyProperty.Register("IsButtonInteractable", typeof(bool), typeof(CreateUserCard));

        public bool IsButtonInteractable
        {
            get { return (bool)GetValue(IsSaveInteractableProperty); }
            set { SetValue(IsSaveInteractableProperty, value); }
        }
        #endregion

        #region GenderProperty
        private static readonly DependencyProperty GenderProperty =
           DependencyProperty.Register("GenderInput",
               typeof(string), typeof(CreateUserCard),
               new PropertyMetadata(default, OnGenderPropertyChanged));

        private static void OnGenderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue is string gender)
                {
                    if (gender.Equals(string.Empty))
                        (d as CreateUserCard).ClearGenderSelection();
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

        #region AllGenders
        private static readonly DependencyProperty AllGenderProperty =
            DependencyProperty.Register("AllGenders", typeof(IEnumerable), typeof(CreateUserCard));

        public IEnumerable<GenderModel> AllGenders
        {
            get { return (IEnumerable<GenderModel>)GetValue(AllGenderProperty); }
            set { SetValue(AllGenderProperty, value); }
        }


        #region Selected Gender
        private static readonly DependencyProperty SelectedGenderProperty =
            DependencyProperty.Register("SelectedGender", typeof(object), typeof(CreateUserCard), new PropertyMetadata(default, OnGenderChanged));

        private static void OnGenderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CreateUserCard).SetSelectedGender(e.NewValue as GenderModel);
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

        #region SaveButtonCommandProperty
        public static readonly DependencyProperty SaveButtonCommandProperty =
            DependencyProperty.Register("SaveCommand", typeof(ICommand),
                typeof(CreateUserCard),
                new FrameworkPropertyMetadata());

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveButtonCommandProperty); }
            set { SetValue(SaveButtonCommandProperty, value); }
        }
        #endregion

        private Button _lastClickedButton;


        public CreateUserCard()
        {
            InitializeComponent();
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            _lastClickedButton = sender as Button;

            if (_lastClickedButton.Name == "SaveBtn")
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
                if (btn.Name != "SaveBtn")
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
    }
}
