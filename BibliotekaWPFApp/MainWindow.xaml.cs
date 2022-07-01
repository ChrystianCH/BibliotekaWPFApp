using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BibliotekaWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BibliotekaDb db { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            db = new BibliotekaDb();

        }

        public void Load()
        {
            booksGrid.ItemsSource = null;
            booksGrid.ItemsSource = db.Books.ToList();
        }

        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void removeBookBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
