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
using VirtualPet.Models;

namespace VirtualPet.UI;

public partial class MainWindow : Window
{
    private Haustier aktuellesHaustier;

    public MainWindow()
    {
        InitializeComponent();
        InitializeHaustier();
    }

    private void InitializeHaustier()
    {
        aktuellesHaustier = new Hund("Bello");
        UpdateUI();
    }

    private void UpdateUI()
    {
        NameLabel.Text = aktuellesHaustier.Name;
        EnergieLabel.Text = aktuellesHaustier.Energie.ToString();
        HungerLabel.Text = aktuellesHaustier.Hunger.ToString();
        StimmungLabel.Text = aktuellesHaustier.Stimmung.ToString();
        GesundheitLabel.Text = aktuellesHaustier.Gesundheit.ToString();
    }

    private void OnFutterClick(object sender, RoutedEventArgs e)
    {
        aktuellesHaustier.Fuettern();
        aktuellesHaustier.ReagiereAufAktion();
        UpdateUI();
    }

    private void OnSchlafenClick(object sender, RoutedEventArgs e)
    {
        aktuellesHaustier.Schlafen();
        UpdateUI();
    }

    private void OnSpaziergangClick(object sender, RoutedEventArgs e)
    {
        aktuellesHaustier.Spaziergang();
        aktuellesHaustier.ReagiereAufAktion();
        UpdateUI();
    }
}