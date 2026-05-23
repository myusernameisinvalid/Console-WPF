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
using System.Collections.ObjectModel;
using System.Windows.Interop;

namespace IskolaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Tanulo> tanulok = new ObservableCollection<Tanulo>();
        public MainWindow()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("nevek.txt");
            while(!sr.EndOfStream)
            {
                tanulok.Add(new Tanulo(sr.ReadLine()));
            }
            sr.Close();
            dg.ItemsSource = tanulok;
        }

        /*Oldja meg, hogy a kijelölt tanuló a „Törlés” parancsgomb lenyomása után törlésre kerüljön a
        listából! Ha a listában nincs kijelölt tanuló, akkor törléskor a „Nem jelölt ki tanulót!” szöveg
        jelenjen meg egy felugró ablakban!
        */
        private void torles(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                tanulok.Remove((Tanulo)dg.SelectedItem);
            }
            else
            {
                MessageBox.Show("Nem jelölt ki tanulót!");
            }
        }

        /*Ha az „Állomány mentése” parancsgombra kattintunk, akkor történjen meg a listából a tanulók
        mentése a nevekNEW.txt állományba, melynek szerkezete a forrásállomány szerinti
        legyen! Ha a mentés sikeres volt, akkor a „Sikeres mentés!” felirat jelenjen meg egy felugró
        ablakban! Ha az állomány mentése sikertelen, akkor a hibaüzenet (a hibához tartozó beépített
        üzenet/message) jelenjen meg egy felugró ablakban! 
        */
        private void mentes(object sender, RoutedEventArgs e)
        {
            try
            {
                string mentesiSzoveg = "";
                StreamWriter sw = new StreamWriter("nevekNEW.txt");
                foreach (var item in tanulok)
                {
                    mentesiSzoveg = item.KezdesEve.ToString() + ";" + item.Osztaly + ";" + item.Nev;
                    sw.WriteLine(mentesiSzoveg);
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