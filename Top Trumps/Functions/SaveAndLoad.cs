using System.Collections.Generic;
using System.IO;
using Top_Trumps.Classes;
using static Top_Trumps.GlobalVars;

namespace Top_Trumps.Func {
    /// <summary>
    /// Class for all Card File handling
    /// </summary>
    public static class CardFiles {
        /// <summary>
        /// Loads all cards into the given List of Cards. 
        /// </summary>
        /// <param name="allCards"></param>
        public static List<CardQuantity> LoadAllCards(string path, bool randCard = false) {
            FileExistCheck(path);
            List<CardQuantity> allCards = new List<CardQuantity>();
            // To be cleaned up later => boolean'd possible?
            // Trusting in file format
            // Add checks later.
            foreach (string c in File.ReadAllLines(path)) {
                allCards.Add(new CardQuantity(c));
            }
            return allCards;
        }

        /// <summary>
        /// Checks for existance of file, creates it if not
        /// </summary>
        /// <param name="path"></param>
        private static void FileExistCheck(string path) {
            if (!File.Exists(path)) File.WriteAllText(path, "");
        }

        /// <summary>
        /// Saves all given cards to path dictated by GlobalVars.Collection
        /// </summary>
        /// <param name="cards"></param>
        public static void SaveCards(List<CardQuantity> cards, string path) {
            // This can be boolean'd :(
            List<string> saves = new List<string>();
            foreach (CardQuantity c in cards) saves.Add(c.ParseToString);
            File.WriteAllLines(path, saves.ToArray());
        }
        /// <summary>
        /// Saves just 1 card to the list
        /// </summary>
        /// <param name="cards"></param>
        public static void AppendCards(CardQuantity cards, string path) {
            FileExistCheck(path);
            File.AppendAllText(path, cards.ParseToString + "\n");
        }
    }
}