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

namespace haromszogekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Haromszog> haromszogek = new ObservableCollection<Haromszog>();
        public MainWindow()
        {
            StreamReader sr = new StreamReader("haromszogek2.csv");
            while (!sr.EndOfStream)
            {
                haromszogek.Add(new Haromszog(sr.ReadLine()));
            }
            sr.Close();
            InitializeComponent();
            dg.ItemsSource = haromszogek;
        }

        private void hozzaadas(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(abox.Text);
            int b = int.Parse(bbox.Text);
            int c = int.Parse(cbox.Text);
            if (a<b && b<c) { 
                Haromszog uj = new Haromszog($"{a} {b} {c}");
                haromszogek.Add(uj);
                dg.Items.Refresh();
                abox.Clear();
                bbox.Clear();
                cbox.Clear();
            }
            else
            {
                MessageBox.Show("Nem megfelelő értékek");
            }
        }

        private void mentes(object sender, RoutedEventArgs e)
        {
            List<string> mentendosorok = new List<string>();
            foreach (var item in haromszogek)
            {
                mentendosorok.Add($"{item.a} {item.b} {item.c}");
            }
            File.WriteAllLines("haromszogek2.csv", mentendosorok);
            MessageBox.Show("Sikeres mentés");
        }
    }
}