using LibraryManagment.LibraryWindows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryManagment.Registration
{
    /// <summary>
    /// Interaction logic for Sign_Up.xaml
    /// </summary>
    public partial class Sign_Up : Window
    {
        public Sign_Up()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            password.Visibility = Visibility.Collapsed;
            textBox.Text = password.Password;
            textBox.Visibility = Visibility.Visible;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox.Visibility = Visibility.Hidden;
            password.Visibility = Visibility.Visible;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (textBox.Visibility == Visibility.Visible)
            {
                textBox.Text = password.Password;
            }
        }

        private void done_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\99891\OneDrive\Ishchi stol\G7.examples\Management\LibraryManagment\Registration\Accounts.json";
            Accounts account = new Accounts
            {
                Username = User.Text,
                BirtPlace = place.Text,
                BirthDay = BirthDay.SelectedDate ?? DateTime.Today,
                Password = password.Password
            };
            List<Accounts> accounts;

            if (File.Exists(path))
            {
                string jsonFromFile = File.ReadAllText(path);
                accounts = JsonSerializer.Deserialize<List<Accounts>>(jsonFromFile) ?? new List<Accounts>();
            }
            else
            {
                accounts = new List<Accounts>();
            }

            accounts.Add(account);

            string jsonString = JsonSerializer.Serialize(accounts);
            File.WriteAllText(path, jsonString);

            LibrarySectionWindow section = new LibrarySectionWindow();
            section.Show();


        }
    }
}
