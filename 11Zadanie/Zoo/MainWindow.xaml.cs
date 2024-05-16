using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Models;
using ZooApp;

namespace Zoo
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Enclosure> Enclosures { get; set; }
        private Zoo.Models.Zoo zoo;

        public MainWindow()
        {
            InitializeComponent();

            zoo = new Zoo.Models.Zoo();
            Enclosures = new ObservableCollection<Enclosure>(zoo.Enclosures);

            EnclosuresList.ItemsSource = Enclosures;
        }

        private void AddEnclosure_Click(object sender, RoutedEventArgs e)
        {
            var enclosure = new Enclosure { Number = Enclosures.Count + 1, Size = 100, MaxAnimals = 10 };
            zoo.AddEnclosure(enclosure);
            Enclosures.Add(enclosure);
        }

        private void RemoveEnclosure_Click(object sender, RoutedEventArgs e)
        {
            if (EnclosuresList.SelectedItem is Enclosure selectedEnclosure)
            {
                zoo.RemoveEnclosure(selectedEnclosure.Number);
                Enclosures.Remove(selectedEnclosure);
            }
        }

        private void EditEnclosure_Click(object sender, RoutedEventArgs e)
        {
            if (EnclosuresList.SelectedItem is Enclosure selectedEnclosure)
            {
                var editWindow = new EditEnclosureWindow(selectedEnclosure);
                if (editWindow.ShowDialog() == true)
                {
                    var editedEnclosure = editWindow.Enclosure;
                    zoo.UpdateEnclosure(editedEnclosure);
                    var index = Enclosures.IndexOf(selectedEnclosure);
                    Enclosures[index] = editedEnclosure;
                    EnclosuresList.Items.Refresh();
                }
            }
        }

        private void SortEnclosuresAscending_Click(object sender, RoutedEventArgs e)
        {
            zoo.SortEnclosuresByNumber(true);
            Enclosures = new ObservableCollection<Enclosure>(zoo.Enclosures);
            EnclosuresList.ItemsSource = Enclosures;
        }

        private void SortEnclosuresDescending_Click(object sender, RoutedEventArgs e)
        {
            zoo.SortEnclosuresByNumber(false);
            Enclosures = new ObservableCollection<Enclosure>(zoo.Enclosures);
            EnclosuresList.ItemsSource = Enclosures;
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (EnclosuresList.SelectedItem is Enclosure selectedEnclosure)
            {
                string selectedAnimalType = ((ComboBoxItem)AnimalTypeComboBox.SelectedItem).Content.ToString();
                Animal animal = null;

                switch (selectedAnimalType)
                {
                    case "Fish":
                        animal = new Fish { Name = "New Fish", IsPredator = false, IsDeepWater = true };
                        break;
                    case "Bird":
                        animal = new Bird { Name = "New Bird", IsPredator = false, FlightSpeed = 10 };
                        break;
                    case "Mammal":
                        animal = new Mammal { Name = "New Mammal", IsPredator = false, Habitat = "Forest" };
                        break;
                }

                if (animal != null)
                {
                    selectedEnclosure.Animals.Add(animal);
                    zoo.UpdateEnclosure(selectedEnclosure);
                    EnclosuresList.Items.Refresh();
                }
            }
        }

        private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (EnclosuresList.SelectedItem is Enclosure selectedEnclosure)
            {
                if (selectedEnclosure.Animals.Count > 0)
                {
                    selectedEnclosure.Animals.RemoveAt(selectedEnclosure.Animals.Count - 1);
                    zoo.UpdateEnclosure(selectedEnclosure);
                    EnclosuresList.Items.Refresh();
                }
            }
        }
    }
}
