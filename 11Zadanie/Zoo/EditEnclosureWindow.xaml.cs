using System.Windows;
using ZooApp;

namespace Zoo
{
    public partial class EditEnclosureWindow : Window
    {
        public Enclosure Enclosure { get; private set; }

        public EditEnclosureWindow(Enclosure enclosure)
        {
            InitializeComponent();

            Enclosure = enclosure;

            NumberTextBox.Text = Enclosure.Number.ToString();
            SizeTextBox.Text = Enclosure.Size.ToString();
            MaxAnimalsTextBox.Text = Enclosure.MaxAnimals.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberTextBox.Text, out int number) &&
                double.TryParse(SizeTextBox.Text, out double size) &&
                int.TryParse(MaxAnimalsTextBox.Text, out int maxAnimals))
            {
                Enclosure.Number = number;
                Enclosure.Size = size;
                Enclosure.MaxAnimals = maxAnimals;

                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter valid values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
