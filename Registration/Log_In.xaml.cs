//using LibraryManagment.MainWindow;
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
    /// Interaction logic for Log_In.xaml
    /// </summary>
    public partial class Log_In : Window
    {
        public Log_In()
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


        private void done_Clicked(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\99891\OneDrive\Ishchi stol\G7.examples\Management\LibraryManagment\Registration\Accounts.json";
            if (File.Exists(path))
            {
                string jsonFromFile = File.ReadAllText(path);
                List<Accounts> accounts = JsonSerializer.Deserialize<List<Accounts>>(jsonFromFile);

                string username = User.Text;
                string Password = password.Password;

                var account = accounts.FirstOrDefault(a => a.Username == username && a.Password == Password);

                if (account != null)
                {
                    LibrarySectionWindow section = new LibrarySectionWindow();
                    section.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }

            else
            {
                MessageBox.Show("No accounts.json file found");
            }

        }
    }
}
