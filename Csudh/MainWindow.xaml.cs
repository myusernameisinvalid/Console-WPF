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

namespace IpcimWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Szerver> szerverek = new ObservableCollection<Szerver>();
        public MainWindow()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("csudh.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                szerverek.Add(new Szerver(sr.ReadLine()));
            }
            sr.Close();
            dg.ItemsSource = szerverek;

        }

        private void bevitel(object sender, RoutedEventArgs e)
        {
            string domaincim = domainbox.Text;
            string ip = ipbox.Text;
            szerverek.Add(new Szerver(domaincim + ";" + ip));
            domainbox.Clear();
            ipbox.Clear();
        }

        private void mentes(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("domainek.txt");
                sw.WriteLine("Domaincím;IP");
                foreach (var item in szerverek)
                {
                    sw.WriteLine(item.Domaincim + ";" + item.Ip);
                }
                sw.Close();
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}