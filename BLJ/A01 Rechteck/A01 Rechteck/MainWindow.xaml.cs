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

namespace A01_Rechteck
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Button btnBerechnen = (Button)FindName("btnBerechnen");
            Button btnBeenden = (Button)FindName("btnBeenden");

            if (btnBerechnen != null)
                btnBerechnen.Click += BtnBerechnen_Click;

            if (btnBeenden != null)
                btnBeenden.Click += BtnBeenden_Click;
        }

        private void BtnBerechnen_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(((TextBox)FindName("inputBreite"))?.Text, out double breite) &&
                double.TryParse(((TextBox)FindName("inputHoehe"))?.Text, out double hoehe))
            {
                double flaeche = breite * hoehe;
                ((TextBox)FindName("outputFlaeche")).Text = flaeche.ToString();
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
}
