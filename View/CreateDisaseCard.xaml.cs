﻿using System;
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
    /// Логика взаимодействия для CreateDisaseCard.xaml
    /// </summary>
    public partial class CreateDisaseCard : UserControl
    {
        private static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("CreateDateText", typeof(string), typeof(CreateDisaseCard));

        public string CreateDateText
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public CreateDisaseCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}