using System.Collections.ObjectModel;
using System.IO;
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

namespace LolWPF_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Hos> hosok = new ObservableCollection<Hos>();
        public MainWindow()
        {
            StreamReader sr = new StreamReader("champions2017_V2.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                hosok.Add(new Hos(sr.ReadLine()));
            }
            sr.Close();
            InitializeComponent();
            dg.ItemsSource = hosok;
        }

        //A keresés gomb megnyomására jelenítse meg a beviteli mezőbe megadott nevű hőst.
        //Ha a mező csak egy szórészlet kerül, akkor az összes olyan hős jelenjen meg, akinek a neve tartalmazza az adott karaktersorozatot.
        //Üres mező esetén a teljes hőslista legyen látható.
        private void kereses(object sender, RoutedEventArgs e)
        {
            string keresett = keresesbox.Text;
            var szurtLista = hosok.Where(h => h.Name.Contains(keresett)).ToList();
            dg.ItemsSource = szurtLista;
            keresesbox.Clear();
        }

        /*A mentés gomb megnyomására mentse a kilistázott hős nevét és HP értékét a mintának megfelelően. 
        Az állomány neve legyen a keresendő név, ha üres a beviteli mező, akkor teljes.txt néven történjen a mentés. 
        Sikeres mentés esetén „Sikeres mentés” felirat jelenjen meg egy felugró üzenetben. 
        Ha az állomány mentése sikertelen, akkor a hibaüzenet (a hibához tartozó beépített üzenet/message) jelenjen meg egy felugró ablakban!
        */
        private void mentes(object sender, RoutedEventArgs e)
        {
            string keresett = keresesbox.Text;
            string fajlnev = string.IsNullOrWhiteSpace(keresett) ? "teljes.txt" : $"{keresett}.txt";
            try
            {
                var kilistazotthosok = dg.ItemsSource as IEnumerable<Hos>;
                if (kilistazotthosok != null)
                {
                    List<string> kiirandohosok = new List<string>();
                    foreach (var h in kilistazotthosok)
                    {
                        string formazottsor = $"Név: {h.Name},".PadRight(20) + $"Hp= {h.HP}";
                        kiirandohosok.Add(formazottsor);
                    }
                    System.IO.File.WriteAllLines(fajlnev, kiirandohosok);
                    MessageBox.Show($"Sikeresen mentve: {fajlnev}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a fájl mentésekor: {ex.Message}");
            }
        }
    }
}