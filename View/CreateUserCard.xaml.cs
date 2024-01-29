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
    /// Логика взаимодействия для CreateUserCard.xaml
    /// </summary>
    public partial class CreateUserCard : UserControl
    {
        public static readonly DependencyProperty IdCreateProperty =
            DependencyProperty.Register("TextIdCreate", typeof(string), typeof(CreateUserCard));

        public string TextIdCreate
        {
            get { return (string)GetValue(IdCreateProperty); } 
            set { SetValue(IdCreateProperty, value);}
        }

        public CreateUserCard()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            var clickedBtn = sender as Button;

            if (clickedBtn.Name == "SaveBtn")
            {
                return;
            }

            foreach (var btn in CreateUserCard.FindVisualButton<Button>(this))
            {
                if (btn.Name != "SaveBtn")
                {
                    btn.Background = (Brush)new BrushConverter().ConvertFrom("#0905");
                }
            }

            clickedBtn.Background = (Brush)new BrushConverter().ConvertFrom("#575176");
        }

        public static IEnumerable<T> FindVisualButton<T>(DependencyObject depObj) where T : DependencyObject
        {
            if(depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if(child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach(T childofChild in FindVisualButton<T>(child))
                    {
                        yield return childofChild;
                    }
                }
            }
        }
    }
}
