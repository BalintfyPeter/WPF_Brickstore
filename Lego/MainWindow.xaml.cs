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

namespace Lego
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Elem> elemek = new ObservableCollection<Elem>();

        public MainWindow()
        {
            InitializeComponent();
            dgElemek.ItemsSource = elemek;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                XDocument xaml = XDocument.Load(ofd.FileName);
                elemek.Clear();
                foreach (var elem in xaml.Descendants("Item"))
                {
                    elemek.Add(new Elem(elem.Element("ItemID").Value, elem.Element("ItemName").Value, elem.Element("CategoryName").Value, elem.Element("ColorName").Value, Convert.ToInt32(elem.Element("Qty").Value)));
                }
                txtElemId.IsEnabled = true;
                txtElemNev.IsEnabled = true;
            }
            lblElemekSzama.Content = elemek.Count;
        }

        private void txtElemNev_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtElemNev.Text;
            List<Elem> filteredItems = elemek.Where(item => item.ItemName.StartsWith(searchText)).ToList();
            dgElemek.ItemsSource = filteredItems;
            lblElemekSzama.Content = filteredItems.Count;
        }

        private void txtElemId_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtElemId.Text;
            List<Elem> filteredItems = elemek.Where(item => item.ItemID.StartsWith(searchText)).ToList();
            dgElemek.ItemsSource = filteredItems;
            lblElemekSzama.Content = filteredItems.Count;
        }
    }
}