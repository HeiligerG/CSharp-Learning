using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A00_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool display = false;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void toggleHWbtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (display)
        {
            hellotxt.Text = "Bye World!";
            toggleHWbtn.Content = "Say Hallo!";
        }
        else
        {
            hellotxt.Text = "Hello World!";
            toggleHWbtn.Content = "Say Bye!";

        }
        display = !display;
    }
}