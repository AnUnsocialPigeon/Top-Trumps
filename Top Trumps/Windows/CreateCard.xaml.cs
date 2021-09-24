using System.Windows;
using Top_Trumps.Classes;

namespace Top_Trumps.Windows {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddCardsWindow : Window {
        // Variables to be referenced by MainWindow
        public Card CardAdded { get; set; }
        public bool Added = false;

        /// <summary>
        /// Initialisaion Function
        /// </summary>
        public AddCardsWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// When the button is clicked, this is called. Will attempt to submit the given card as an actual card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_BTN_Click(object sender, RoutedEventArgs e) {
            if (Name.Text != "" && int.TryParse(Attack.Text, out int attack) && int.TryParse(Defence.Text, out int defence) &&
                int.TryParse(SpAttack.Text, out int spAttack) && int.TryParse(SpDefence.Text, out int spDefence) &&
                int.TryParse(Speed.Text, out int speed)) {
                // Having any new lines will mess up the file system.
                CardAdded = new Card(Name.Text.Replace('\n', ' '), ImgURL.Text.Replace('\n', ' '), 
                    attack, defence, spAttack, spDefence, speed, (bool)ShinyBox.IsChecked);
                Added = true;
                Close();
            }
            else MessageBox.Show("Please fill out all boxes", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
