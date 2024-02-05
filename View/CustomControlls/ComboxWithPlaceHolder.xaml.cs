using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ComboxWithPlaceHolder.xaml
    /// </summary>
    public partial class ComboxWithPlaceHolder : UserControl
    {
        private static readonly DependencyProperty PlaceHolderTextProperty =
            DependencyProperty.Register("PlaceHolderText", typeof(string), typeof(ComboxWithPlaceHolder));

        public string PlaceHolderText
        {
            get { return (string)GetValue(PlaceHolderTextProperty); }
            set { SetValue(PlaceHolderTextProperty, value); }
        }

        private static readonly DependencyProperty ComboxContentProperty =
            DependencyProperty.Register("ComboxContent", 
                typeof(IEnumerable), 
                typeof(ComboxWithPlaceHolder), new PropertyMetadata(default));

        public IEnumerable ComboxContent
        {
            get { return (IEnumerable)GetValue(ComboxContentProperty); }
            set { SetValue(ComboxContentProperty, value); }
        }

        private static readonly DependencyProperty ComboxSelectedProperty =
            DependencyProperty.Register("ComboxSelectedItem",
                typeof(object),
                typeof(ComboxWithPlaceHolder), new PropertyMetadata(default));

        public object ComboxSelectedItem
        {
            get { return (object)GetValue(ComboxSelectedProperty); }
            set { SetValue(ComboxSelectedProperty, value); }
        }

        public ComboxWithPlaceHolder()
        {
            InitializeComponent();
        }
    }
}
