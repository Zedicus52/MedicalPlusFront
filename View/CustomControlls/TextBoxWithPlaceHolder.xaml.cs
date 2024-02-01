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

namespace MedicalPlusFront.View.CustomControlls
{
    /// <summary>
    /// Interaction logic for TextBoxWithPlaceHolder.xaml
    /// </summary>
    public partial class TextBoxWithPlaceHolder : UserControl
    {
        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(TextBoxWithPlaceHolder), 
            new FrameworkPropertyMetadata(""));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty PlaceHolderTextProperty =
            DependencyProperty.Register("PlaceHolderText", typeof(string), typeof(TextBoxWithPlaceHolder), new PropertyMetadata(string.Empty));

        public string PlaceHolderText
        {
            get { return (string)GetValue(PlaceHolderTextProperty); }
            set { SetValue(PlaceHolderTextProperty, value); }
        }

        private TextBox _mainTextBox;

        public TextBoxWithPlaceHolder()
        {
            InitializeComponent();
            _mainTextBox = (TextBox)FindName("MainTextBox");
        }


        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetValue(TextProperty, _mainTextBox.Text);

        }
    }
}
