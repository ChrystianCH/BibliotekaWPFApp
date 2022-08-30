using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BibliotekaWPFApp
{
    /// <summary>
    /// Logika interakcji dla klasy RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public MainWindow mw;

        public RegistrationWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private bool EmailIsValid(string emailaddress)
        {
            return MailAddress.TryCreate(emailaddress, out _);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(loginTxt.Text) || loginTxt.Text.Length < 5
                || string.IsNullOrEmpty(passwordTxt.Text) || passwordTxt.Text.Length < 5)
            {
                MessageBox.Show("Login i hasło muszą mieć minimum 5 znaków.");
            }
            else if (!EmailIsValid(emailTxt.Text))
            {
                MessageBox.Show("Adres email jest niepoprawny.");
            }
            if (mw.db.Users.Any(a => a.Login == loginTxt.Text))
            {
                MessageBox.Show("Podany login jest już zajęty.");
            }
            else
            {
                User user = new User(loginTxt.Text, passwordTxt.Text, emailTxt.Text);

                mw.db.Users.Add(user);
                mw.db.SaveChanges();
                this.Close();
            }
        }
    }
}
