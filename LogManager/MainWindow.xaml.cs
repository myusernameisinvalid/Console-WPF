using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Linq;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Logok> logok = new ObservableCollection<Logok>();

        public MainWindow()
        {
            InitializeComponent();
            lbLogok.ItemsSource = logok;

            try
            {
                string[] sorok = File.ReadAllLines("server.log");
                foreach (var sor in sorok)
                {
                    logok.Add(new Logok(sor));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a fájl betöltésekor:\n{ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        //Az "Előző" gomb megnyomásával a program az előző, megfelelő szintű bejegyzést jeleníti meg.
        private void elozo(object sender, RoutedEventArgs e)
        {
            string keresettSzint = GetKivalasztottSzint();
            int jelenlegiIndex = lbLogok.SelectedIndex;
            if (jelenlegiIndex == -1)
            {
                jelenlegiIndex = logok.Count;
            }
            for (int i = jelenlegiIndex - 1; i >= 0; i--)
            {
                if (logok[i].Szint == keresettSzint)
                {
                    lbLogok.SelectedIndex = i;
                    lbLogok.ScrollIntoView(lbLogok.SelectedItem);
                    return;
                }
            }

            MessageBox.Show($"Nincs több '{keresettSzint}' szintű bejegyzés felfelé!", "Infó", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //A "Következő" gomb megnyomásával a program a következő olyan bejegyzést jeleníti meg, amely megfelel a kiválasztott szintnek.
        private void kovetkezo(object sender, RoutedEventArgs e)
        {
            string keresettSzint = GetKivalasztottSzint();
            int jelenlegiIndex = lbLogok.SelectedIndex;
            for (int i = jelenlegiIndex + 1; i < logok.Count; i++)
            {
                if (logok[i].Szint == keresettSzint)
                {
                    lbLogok.SelectedIndex = i;
                    lbLogok.ScrollIntoView(lbLogok.SelectedItem);
                    return;
                }
            }
            MessageBox.Show($"Nincs több '{keresettSzint}' szintű bejegyzés lefelé!", "Infó", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private string GetKivalasztottSzint()
        {
            ComboBoxItem kivalasztottElem = (ComboBoxItem)cbSzintek.SelectedItem;
            return kivalasztottElem.Content.ToString();
        }
    }
}