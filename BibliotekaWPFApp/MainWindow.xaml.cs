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
    /// klasa MainWindow ktora dziedziczy window
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// getter setter dla danych
        /// </summary>
        public BibliotekaDb db { get; set; }
        /// <summary>
        /// konstruktor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            db = new BibliotekaDb();

            Load();
        }
        /// <summary>
        /// funkcja ladujaca 
        /// </summary>
        public void Load()
        {
            booksGrid.ItemsSource = null;
            booksGrid.ItemsSource = db.Books.ToList();
            clientsGrid.ItemsSource = null;
            clientsGrid.ItemsSource = db.Clients.ToList();
            borrowsGrid.ItemsSource = null;
            borrowsGrid.ItemsSource = db.Borrows.ToList();
        }

        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBook ab = new AddBook(this);
            ab.Show();
            this.IsEnabled = false;
        }

        private void removeBookBtn_Click(object sender, RoutedEventArgs e)
        {
            if(booksGrid.SelectedItem != null && booksGrid.SelectedItem is Book)
            {
                Book book = booksGrid.SelectedItem as Book;
                db.Books.Remove(book);
                db.SaveChanges();
                Load();
            }
            else
            {
                MessageBox.Show("Wybierz pozycje do usunięcia!");
            }
        }

        private void addClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddClient ac = new AddClient(this);
            ac.Show();
            this.IsEnabled = false;
        }

        private void removeClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (clientsGrid.SelectedItem != null && clientsGrid.SelectedItem is Client)
            {
                Client client = clientsGrid.SelectedItem as Client;
                db.Clients.Remove(client);
                db.SaveChanges();
                Load();
            }
            else
            {
                MessageBox.Show("Wybierz pozycje do usunięcia!");
            }
        }

        private void borrowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (booksGrid.SelectedItem != null && booksGrid.SelectedItem is Book)
            {
                Book book = booksGrid.SelectedItem as Book;

                BorrowWindow bw = new BorrowWindow(book, this);
                bw.Show();
                this.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Wybierz pozycje do wypożyczenia!");
            }
        }

        private void returnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (borrowsGrid.SelectedItem != null && borrowsGrid.SelectedItem is Borrow)
            {
                Borrow borrow = borrowsGrid.SelectedItem as Borrow;
                borrow.Returned = true;
                borrow.ReturnDate = DateTime.Now;

                db.SaveChanges();

                Load();
            }
            else
            {
                MessageBox.Show("Wybierz pozycje do zwrotu!");
            }
        }
    }
}
