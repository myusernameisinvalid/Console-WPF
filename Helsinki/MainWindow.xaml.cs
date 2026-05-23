using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using helsinki1952;

namespace HelsinkiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Olimpia> adatok = new ObservableCollection<Olimpia>();
        public MainWindow()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("helsinki.txt");
            while (!sr.EndOfStream)
            {
                adatok.Add(new Olimpia(sr.ReadLine()));
            }
            sr.Close();
            dg.ItemsSource = adatok;
        }
        
        private void hozzaad(object sender, RoutedEventArgs e)
        {
            int ujHelyezes = int.Parse(helyezesbox.Text);
            int ujSportoloSzama = int.Parse(sportolobox.Text);
            string ujSportag = sportagbox.Text;
            string ujVersenyszam = versenyszambox.Text;
            Olimpia ujolimpia= new Olimpia(ujHelyezes, ujSportoloSzama, ujSportag, ujVersenyszam);
            adatok.Add(ujolimpia);
            helyezesbox.Clear();
            sportolobox.Clear();
            sportagbox.Clear();
            versenyszambox.Clear();
        }

        private void torol(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                Olimpia kivalasztottEredmeny = (Olimpia)dg.SelectedItem;
                adatok.Remove(kivalasztottEredmeny);
            }
            else
            {
                MessageBox.Show("Kérlek, előbb jelölj ki egy sort a törléshez!", "Infó", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}