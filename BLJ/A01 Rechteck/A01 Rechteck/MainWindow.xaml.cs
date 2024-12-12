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
using System.IO;
using System.Windows.Markup;
using System.Windows;

namespace A01_Rechteck;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        var myGrid = (Grid)FindResource("MyGridTemplate");
    
        var btnBerechnen = (Button)myGrid.FindName("btnBerechnen");
        var btnBeenden = (Button)myGrid.FindName("btnBeenden");

        btnBerechnen.Click += BtnBerechnen_Click;
        btnBeenden.Click += BtnBeenden_Click;
    }

    private void BtnBerechnen_Click(object sender, RoutedEventArgs e)
    {
        var myGrid = (Grid)FindResource("MyGridTemplate");
    
        var inputBreite = (TextBox)myGrid.FindName("inputBreite");
        var inputHoehe = (TextBox)myGrid.FindName("inputHoehe");
        var outputFlaeche = (TextBox)myGrid.FindName("outputFlaeche");

        if (double.TryParse(inputBreite?.Text, out double breite) &&
            double.TryParse(inputHoehe?.Text, out double hoehe))
        {
            var rechteck = new Rectangle(hoehe, breite);
            double flaeche = rechteck.BerechneFlaeche();
            outputFlaeche.Text = flaeche.ToString();
        }
        else
        {
            MessageBox.Show("Bitte gültige Zahlen eingeben!");
        }
    }

    private void BtnBeenden_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}