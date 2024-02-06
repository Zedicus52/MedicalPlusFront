using MedicalPlusFront.ViewModel;
using System.Windows;

namespace MedicalPlusFront.View;

public partial class TestWindow : Window
{
    public TestWindow()
    {
        InitializeComponent();
        DataContext = new TestWindowVM();
    }
}