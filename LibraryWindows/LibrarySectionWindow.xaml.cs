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
using System.Windows.Shapes;

namespace LibraryManagment.LibraryWindows
{
    /// <summary>
    /// Interaction logic for LibrarySectionWindow.xaml
    /// </summary>
    public partial class LibrarySectionWindow : Window
    {
        public LibrarySectionWindow()
        {
            InitializeComponent();
        }

        private void account_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Religious_Button_Clicked(object sender, RoutedEventArgs e)
        {
            ReligiousWindow window = new ReligiousWindow();
            window.Show();
        }

        private void Historical_Button_Clicked(object sender, RoutedEventArgs e)
        {
            HistoricalWindow window = new HistoricalWindow();
            window.Show();
        }

        private void Detective_Button_Clicked(object sender, RoutedEventArgs e)
        {
            DetectiveWindow window = new DetectiveWindow();
            window.Show();
        }

        private void Fantasy_Button_Clicked(object sender, RoutedEventArgs e)
        {
            FantasyWindow window = new FantasyWindow();
            window.Show();
        }

        private void Literary_Button_Clicked(object sender, RoutedEventArgs e)
        {
            LiteraryWindow window = new LiteraryWindow();
            window.Show();
        }

        private void Class_Button_Clicked(object sender, RoutedEventArgs e)
        {
            ClassWindow window = new ClassWindow();
            window.Show();
        }
    }
}
