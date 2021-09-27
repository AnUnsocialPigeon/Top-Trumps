using System;
using System.Collections.Generic;
using System.Windows;
using Top_Trumps.Classes;
using Top_Trumps.Func;
using Top_Trumps.Functions;

namespace Top_Trumps.Windows {
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window {
        public List<CardQuantity> playerCards;
        public int money = 0;

        private List<CardQuantity> cards;
        private CardQuantity currentPlayerCard = new CardQuantity();
        private CardQuantity currentEnemyCard = new CardQuantity();

        private int currentCardIndex;
        private Random rnd = new Random();
        /// <summary>
        /// Constructor for the GameWindow
        /// </summary>
        /// <param name="c"></param>
        public GameWindow(List<CardQuantity> c) {
            // Check for null cards
            if (c.Count == 0) Close();
            
            playerCards = c;
            InitializeComponent();
            cards = CardFiles.LoadAllCards(GlobalVars.CardPath);


            // Sets the players first card
            currentCardIndex = rnd.Next(playerCards.Count);
            currentPlayerCard = playerCards[currentCardIndex];
            Dispatcher.Invoke(() => new DisplayCard().ChangeDisplayCard(PlayerCardGrid, PlayerDisplayCardIMG, PlayerDisplayCardInfo, currentPlayerCard));

            // Sets the enemy's first card
            currentEnemyCard = cards[rnd.Next(cards.Count)];
        }

        /// <summary>
        /// The code that is run when the player selects a card
        /// </summary>
        /// <param name="playerstat"></param>
        /// <param name="enemystat"></param>
        private void Move(int playerstat, int enemystat) {
            // Win?
            if (playerstat > enemystat) {
                money += 50;
                CurrencyBox.Text = "$: " + money + "\nResult:\nWin";
            }
            else {
                money -= 20;
                CurrencyBox.Text = "$: " + money + "\nResult:\nLoss";
            }

            // Lose the card
            playerCards[currentCardIndex].Quantity--;
            if (playerCards[currentCardIndex].Quantity <= 0) {
                playerCards.RemoveAt(currentCardIndex);
                
                // Run out of cards
                if (playerCards.Count == 0) Close();
            }
            

            // Card rotate
            currentCardIndex++;
            if (currentCardIndex >= playerCards.Count) currentCardIndex = 0;
            currentPlayerCard = cards[currentCardIndex];

            // Set player + enemy card again, + update quantity
            currentEnemyCard = cards[rnd.Next(cards.Count)];
            Dispatcher.Invoke(() => new DisplayCard().ChangeDisplayCard(PlayerCardGrid, PlayerDisplayCardIMG, PlayerDisplayCardInfo, currentPlayerCard));
            Dispatcher.Invoke(() => new DisplayCard().ChangeQuantityBox(QuantityBox, currentPlayerCard.Quantity));
        }


        /// <summary>
        /// All of the buttons for each stat to be used. 
        /// Each will call the Move() function with their respective stats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region DecisionButtons
        private void AttackBTN_Click(object sender, RoutedEventArgs e) {
            Move(currentPlayerCard.Attack, currentEnemyCard.Attack);
        }

        private void DefenceBTN_Click(object sender, RoutedEventArgs e) {
            Move(currentPlayerCard.Defence, currentEnemyCard.Defence);
        }

        private void SpAttackBTN_Click(object sender, RoutedEventArgs e) {
            Move(currentPlayerCard.SpAttack, currentEnemyCard.SpAttack);
        }

        private void SpDefenceBTN_Click(object sender, RoutedEventArgs e) {
            Move(currentPlayerCard.SpDefence, currentEnemyCard.SpDefence);
        }

        private void SpeedBTN_Click(object sender, RoutedEventArgs e) {
            Move(currentPlayerCard.Speed, currentEnemyCard.Speed);
        }
        #endregion

        /// <summary>
        /// The exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBTN_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
