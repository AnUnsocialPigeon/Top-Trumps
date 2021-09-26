using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Top_Trumps.Classes;
using Top_Trumps.Func;
using Top_Trumps.Functions;

namespace Top_Trumps.Windows {
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window {
        public List<CardQuantity> playerCards;
        private List<CardQuantity> cards;
        private CardQuantity currentPlayerCards;
        private CardQuantity currentEnemyCards;

        private int currentCardIndex;
        private Random rnd = new Random();
        /// <summary>
        /// Constructor for the GameWindow
        /// </summary>
        /// <param name="c"></param>
        public GameWindow(List<CardQuantity> c) {
            playerCards = c;
            InitializeComponent();
            cards = CardFiles.LoadAllCards(GlobalVars.CardPath);


            // Sets the players first card
            currentCardIndex = rnd.Next(playerCards.Count);
            currentPlayerCards = playerCards[currentCardIndex];
            Dispatcher.Invoke(() => new DisplayCard().ChangeDisplayCard(PlayerCardGrid, PlayerDisplayCardIMG, PlayerDisplayCardInfo, currentPlayerCards));

            // Sets the enemy's first card
            currentEnemyCards = cards[rnd.Next(cards.Count)];
        }

        private void AddCardsBTN_Click(object sender, RoutedEventArgs e) {

        }
    }
}
