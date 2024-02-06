using Newtonsoft.Json.Linq;
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

namespace MedicalPlusFront.View.CustomControlls
{
    /// <summary>
    /// Interaction logic for TextArea.xaml
    /// </summary>
    public partial class TextArea : UserControl
    {

        #region Text Property
        public static readonly DependencyProperty TextAreaProperty =
        DependencyProperty.Register("TextAreaInput", typeof(string), typeof(TextArea),
            new FrameworkPropertyMetadata(""));

        public string TextAreaInput
        {
            get { return (string)GetValue(TextAreaProperty); }
            set { SetValue(TextAreaProperty, value); }
        }
        #endregion

        #region PlaceHolder Text Property
        public static readonly DependencyProperty PlaceHolderTextAreaProperty =
            DependencyProperty.Register("PlaceHolderTextArea", typeof(string), typeof(TextArea), new PropertyMetadata(string.Empty));

        public string PlaceHolderTextArea
        {
            get { return (string)GetValue(PlaceHolderTextAreaProperty); }
            set { SetValue(PlaceHolderTextAreaProperty, value); }
        }
        #endregion

        #region TextBox Height Property
        public static readonly DependencyProperty TextBoxHeightProperty =
            DependencyProperty.Register("TextBoxHeight", typeof(string), typeof(TextArea), new PropertyMetadata(string.Empty, OnHeightChanged));

        private static void OnHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextArea instance = (TextArea)d;
            TextBox b = (TextBox)instance.FindName("TextAreaMainTB");
            instance.UpdateMargin(b);
        }

        public string TextBoxHeight
        {
            get { return (string)GetValue(TextBoxHeightProperty); }
            set 
            { 
                SetValue(TextBoxHeightProperty, value);
            }
        }
        #endregion

        public TextArea()
        {
            InitializeComponent();
        }

        private void TextBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            UpdateMargin(textBox);  
        }

        private void Root_Loaded(object sender, RoutedEventArgs e)
        {
            var comp = (TextBox)FindName("TextAreaMainTB");
            comp.Height = Double.Parse(TextBoxHeight);
            UpdateMargin(comp);
        }

        private void UpdateMargin(TextBox textBox)
        {
            TextBlock block = (TextBlock)FindName("TextAreaPlaceholder");
            block.Margin = new Thickness(block.Margin.Left, -(textBox.Height + 20),
                block.Margin.Right, block.Margin.Bottom);
        }
    }
}
