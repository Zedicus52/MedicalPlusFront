﻿using MedicalPlusFront.ValidationRules;
using System;
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
        private PasswordBox _passwordBox;
        private PasswordValidator _passwordValidator;
        public CreateEmployeeCard()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            var clickedBtn = sender as Button;

            if (clickedBtn.Name == "SaveEmployeeBtn")
            {
                return;
            }

            foreach (var btn in CreateUserCard.FindVisualButton<Button>(this))
            {
                if (btn.Name != "SaveEmployeeBtn")
                {
                    btn.Background = (Brush)new BrushConverter().ConvertFrom("#0905");
                }
            }

            clickedBtn.Background = (Brush)new BrushConverter().ConvertFrom("#575176");
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
            if (_passwordBox == null)
                _passwordBox = (PasswordBox)sender;

            string pass = ((PasswordBox)sender).Password;
            var res = _passwordValidator.Validate(pass, CultureInfo.CurrentCulture);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_passwordBox == null)
                return;

            _passwordBox.Password = "";
        }
    }
}
