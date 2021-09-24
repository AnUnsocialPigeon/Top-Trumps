using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using Top_Trumps.Classes;
using Top_Trumps.Func;
using Top_Trumps.Functions;
using Top_Trumps.Windows;

namespace Top_Trumps {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // Vars n stuffs
        private readonly List<CardQuantity> cards = new List<CardQuantity>();
        private Card displayCard = new Card();
        private readonly Random rnd = new Random();

        private static Timer aTimer;

        /// <summary>
        /// Initialiser Function
        /// </summary>
        public MainWindow() {
            InitializeComponent();

            // Loading cards + displaying them
            cards = CardFiles.LoadAllCards(GlobalVars.CollectionPath);
            NewDisplayCard(new object(), new RoutedEventArgs());

            /// Every time you invoke a method that messes with GUI you have to invoke the dispatcher
            /// This makes it synchronous to the main thread and makes it not.. break?
            /// Cant have multiple threads accessing the same GUI element makes this very awkward
            /// Thank fk for stack overflow tho
            Dispatcher.Invoke(() => new DisplayCard().RotateDisplayCard(CurrentCardGrid, CurrentCardIMG, CurrentCardInfo, QuantityBox, cards));

            // setting up card display rotation timer
            aTimer = new Timer(4000);
            aTimer.Elapsed += new ElapsedEventHandler(CardRotationTimerHandler);
            aTimer.Enabled = true;
        }

        /// <summary>
        /// On Add Cards button click
        /// Will bring up other window. Prompt user to create a new card to add to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCardsBTN_Click(object sender, RoutedEventArgs e) {
            AddCardsWindow window = new AddCardsWindow();
            Hide();
            window.ShowDialog();
            Show();
            if (window.Added) CardFiles.AppendCards(new CardQuantity(window.CardAdded, -1), GlobalVars.CardPath);
        }

        /// <summary>
        /// Nothing here yet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelCardsBTN_Click(object sender, RoutedEventArgs e) {

        }

        /// <summary>
        /// Get a New Random Card from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewDisplayCard(object sender, RoutedEventArgs e) {
            // Loads database
            List<Card> c = new List<Card>(CardFiles.LoadAllCards(GlobalVars.CardPath));
            
            // Prevents errors from blank files
            if (c.Count == 0) return;
            
            // Change
            displayCard = c[rnd.Next(c.Count)];
            Dispatcher.Invoke(() => new DisplayCard().ChangeDisplayCard(CardGrid, DisplayCardIMG, DisplayCardInfo, displayCard));
            
        }

        /// <summary>
        /// To add the current display card to the collection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectCardBTN_Click(object sender, RoutedEventArgs e) {
            // New card?
            bool newCard = true;
            foreach (CardQuantity c in cards) {
                if (c.Name == displayCard.Name) {
                    c.Quantity++;
                    newCard = false;
                    break;
                }
            }
            // Add the stats to the file. Done backwards idk why tbh
            if (newCard) {
                CardFiles.AppendCards(new CardQuantity(displayCard), GlobalVars.CollectionPath);
                cards.Add(new CardQuantity(displayCard));
            }
            else { 
                CardFiles.SaveCards(cards, GlobalVars.CollectionPath); 
            }
            // New display card wanted
            NewDisplayCard(new object(), new RoutedEventArgs());
        }

        
        /// <summary>
        /// A function to be called on a timer from the aTimer object. 
        /// Will make the card shown in the collection view to the next card in the sequence
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void CardRotationTimerHandler(object source, ElapsedEventArgs e) {
            // EVERYTHING REQUIRES DISPATCHERS WHYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
            Dispatcher.Invoke(() => new DisplayCard().RotateDisplayCard(CurrentCardGrid, CurrentCardIMG, CurrentCardInfo, QuantityBox, cards));
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e) {
            GameWindow g = new GameWindow(cards);
            Hide();
            g.ShowDialog();
            Show();
        }
    }
}
