using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ClassWindow.xaml
    /// </summary>
    public partial class ClassWindow : Window
    {
        private List<Class> people;
        private List<Class> filteredPeople;

        public ClassWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string filePath = @"C:\Users\99891\OneDrive\Ishchi stol\G7.examples\Management\LibraryManagment\LibraryWindows\ClassBooks.txt"; // Ensure this path is correct

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                // Assign values to the class-level 'people' field, not a local variable
                people = lines.Select(line => line.Split(','))
                              .Select(parts =>
                              {
                                  int column1 = 0;
                                  int column4 = 0;

                                  int.TryParse(parts.Length > 0 ? parts[0] : "0", out column1);
                                  int.TryParse(parts.Length > 3 ? parts[3] : "0", out column4);

                                  return new Class
                                  {
                                      Column1 = column1,
                                      Column2 = parts.Length > 1 ? parts[1] : string.Empty,
                                      Column3 = parts.Length > 2 ? parts[2] : string.Empty,
                                      Column4 = column4
                                  };
                              }).ToList();

                dataGrid.ItemsSource = people; // Bind 'people' to the DataGrid
            }
            else
            {
                MessageBox.Show("The file does not exist.");
            }
        }
        private void rent_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Class selectedPerson)
            {
                if (selectedPerson.Column4 > 0)
                {
                    selectedPerson.Column4--;
                    dataGrid.Items.Refresh(); // Refresh the DataGrid to show updated values

                    UpdateTextFile(); // Update the text file with the new data
                }
                else
                {
                    MessageBox.Show("Cannot decrement further.");
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void searcher_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = search.Text.ToLower();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredPeople = people.Where(person =>
                    person.Column2.ToLower().Contains(searchTerm) ||
                    person.Column3.ToLower().Contains(searchTerm)).ToList();
            }
            else
            {
                filteredPeople = new List<Class>(people);
            }

            dataGrid.ItemsSource = filteredPeople;
            dataGrid.Items.Refresh();
        }

        private void UpdateTextFile()
        {
            string filePath = @"C:\Users\99891\OneDrive\Ishchi stol\G7.examples\Management\LibraryManagment\LibraryWindows\ClassBooks.txt"; // Ensure this path is correct

            if (people != null && people.Any())
            {
                // Create a list of strings to represent updated data
                var updatedLines = people.Select(person => $"{person.Column1},{person.Column2},{person.Column3},{person.Column4}").ToList();

                // Write the updated data back to the file
                File.WriteAllLines(filePath, updatedLines);
            }
            else
            {
                MessageBox.Show("No data to write to the file.");
            }
        }
    }
    public class Class
    {
        public int Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public int Column4 { get; set; }
    }
}
