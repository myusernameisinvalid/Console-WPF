using System.Collections.ObjectModel;
using System.Diagnostics;
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
using trapezCLI;

namespace TrapézWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        ObservableCollection<Trapéz> trapézok = new ObservableCollection<Trapéz>();
        public MainWindow()
        {
            StreamReader sr = new StreamReader("trapezok.csv");
            while (!sr.EndOfStream)
            {
                trapézok.Add(new Trapéz(sr.ReadLine()));
            }
            sr.Close();
            InitializeComponent();
            dg.ItemsSource = trapézok;
        }
        

        private void hozzaad(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = int.Parse(boxa.Text);
                int b = int.Parse(boxb.Text);
                int c = int.Parse(boxc.Text);
                int d = int.Parse(boxd.Text);
                int m = int.Parse(boxmagassag.Text);

                if (a <= 0 || b <= 0 || c <= 0 || d <= 0 || m <= 0)
                {
                    MessageBox.Show("Minden adatnak pozitív számnak kell lennie!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Trapéz uj = new Trapéz($"{a} {b} {c} {d} {m}");
                trapézok.Add(uj);

                boxa.Clear(); boxb.Clear(); boxc.Clear(); boxd.Clear(); boxmagassag.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Kérlek, csak számokat adj meg!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Készítsen egy szűrőmezőt, amely lehetővé teszi a derékszögű trapézok szűrését!
        private void derekszoguek(object sender, RoutedEventArgs e)
        {
            var szurtLista = trapézok.Where(t => t.derekszogu()).ToList();
            dg.ItemsSource = szurtLista;
        }

        //Készítsen egy statisztikai részt, amely megmutatja az összes trapéz számát és a derékszögű trapézok arányát!
        private void statisztika(object sender, RoutedEventArgs e)
        {
            int osszes = trapézok.Count;
            if (osszes == 0) { MessageBox.Show("Nincs adat!"); return; }

            int derekszoguCount = trapézok.Count(t => t.derekszogu());
            double arany = (double)derekszoguCount / osszes * 100;

            MessageBox.Show($"Összes trapéz száma: {osszes}\n" +
                            $"Derékszögű trapézok aránya: {arany:F1}%");
        }

        private void Mentes()
        {
            List<string> sorok = new List<string>();
            foreach (var t in trapézok)
            {
                sorok.Add($"{t.A} {t.B} {t.C} {t.D} {t.M}");
            }
            File.WriteAllLines("trapezok.csv", sorok);
        }
    }
}