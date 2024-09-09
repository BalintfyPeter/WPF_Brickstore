using Microsoft.Win32;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;
using System.IO;

namespace Lego
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Elem> elemek = new ObservableCollection<Elem>();
        ObservableCollection<Elem> szurtElemek = new ObservableCollection<Elem>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BSX files (*.bsx)|*.bsx";

            if (ofd.ShowDialog() == true && System.IO.Path.GetExtension(ofd.FileName) == ".bsx")
            {
                XDocument xaml = XDocument.Load(ofd.FileName);
                elemek.Clear();
                foreach (var elem in xaml.Descendants("Item"))
                {
                    elemek.Add(new Elem(elem.Element("ItemID").Value, elem.Element("ItemName").Value, elem.Element("CategoryName").Value, elem.Element("ColorName").Value, Convert.ToInt32(elem.Element("Qty").Value)));
                }
                txtElemId.IsEnabled = true;
                txtElemNev.IsEnabled = true;
                txtElemNev.Clear();
                txtElemId.Clear();
                dgElemek.ItemsSource = elemek;
                lblElemekSzama.Content = elemek.Count;
            }
        }

        private void txtElemNev_TextChanged(object sender, TextChangedEventArgs e)
        {
            Kereses();
        }

        private void txtElemId_TextChanged(object sender, TextChangedEventArgs e)
        {
            Kereses();
        }

        private void Kereses()
        {
            szurtElemek = new ObservableCollection<Elem>(elemek.Where(item => item.ItemName.ToLower().StartsWith(txtElemNev.Text.ToLower()) && item.ItemID.ToLower().StartsWith(txtElemId.Text.ToLower())));
            dgElemek.ItemsSource = szurtElemek;
            lblElemekSzama.Content = szurtElemek.Count;
        }
    }
}