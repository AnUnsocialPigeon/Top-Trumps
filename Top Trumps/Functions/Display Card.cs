using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Top_Trumps.Classes;

namespace Top_Trumps.Functions {
    public class DisplayCard {

        /// <summary>
        /// Chances a card in a display card grid
        /// </summary>
        /// <param name="grid">The grid obj</param>
        /// <param name="image">The image in the grid</param>
        /// <param name="textBlock">The textBlock in the grid</param>
        /// <param name="card">The card to change it to</param>
        public void ChangeDisplayCard(Grid grid, Image image, TextBlock textBlock, Card card) {
            // Display the stuff
            try { image.Source = new BitmapImage(new Uri(card.ImgURL)); }
            catch { image.Source = new BitmapImage(); }
            textBlock.Text =
                "Name: " + card.Name.Substring(0, (card.Name.Length > 12 ? 12 : card.Name.Length)) + "\n" +
                "Attack: " + card.Attack.ToString() + "\n" +
                "Defence: " + card.Defence.ToString() + "\n" +
                "SpAttack: " + card.SpAttack.ToString() + "\n" +
                "SpDefence: " + card.SpDefence.ToString() + "\n" +
                "Speed: " + card.Speed.ToString() + "\n" +
                "Shiny: " + (card.Shiny ? "true" : "false");
            grid.Background = new SolidColorBrush(card.Shiny ? GlobalVars.ShinyColour : GlobalVars.DefaultColour);
            GC.Collect();
        }

        // The current card that is on rotation from the collection
        private static int currentCardRotate = 0;

        /// <summary>
        /// Will rotate to the next card 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="image"></param>
        /// <param name="textBlock"></param>
        /// <param name="collection"></param>
        public void RotateDisplayCard(Grid grid, Image image, TextBlock textBlock, TextBlock quantityText, List<CardQuantity> collection) {
            // Validity Checks
            if (collection.Count == 0) return;
            if (currentCardRotate >= collection.Count) currentCardRotate = 0;

            // Change
            ChangeDisplayCard(grid, image, textBlock, collection[currentCardRotate]);
            quantityText.Text = "Quantity: " + collection[currentCardRotate].Quantity.ToString();
            currentCardRotate++;
        }
    }
}
