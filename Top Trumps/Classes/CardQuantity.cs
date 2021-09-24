namespace Top_Trumps.Classes {
    public class CardQuantity : Card {
        /// <summary>
        /// The size of the overloads => useful for detecting which filetype we need to parse back from
        /// </summary>
        public int CardQuantityOverloadCount = 9;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CardQuantity() { }
        public CardQuantity(string csvData) {
            Name = csvData.Split(',')[0];
            ImgURL = csvData.Split(',')[1];
            Attack = int.Parse(csvData.Split(',')[2]);
            Defence = int.Parse(csvData.Split(',')[3]);
            SpAttack = int.Parse(csvData.Split(',')[4]);
            SpDefence = int.Parse(csvData.Split(',')[5]);
            Speed = int.Parse(csvData.Split(',')[6]);
            Shiny = (csvData.Split(',')[7] == "true");
            Quantity = (csvData.Split(',').Length > CardOverloadCount ? int.Parse(csvData.Split(',')[8]) : 1);
        }
        public CardQuantity(Card c, int quantity = 1) {
            Name = c.Name;
            ImgURL = c.ImgURL;
            Attack = c.Attack;
            Defence = c.Defence;
            SpAttack = c.SpAttack;
            SpDefence = c.SpDefence;
            Speed = c.Speed;
            Shiny = c.Shiny;
            Quantity = quantity;
        }

        public new string ParseToString => new Card(this).ParseToString + (Quantity == -1 ? "" : "," + Quantity.ToString());
        public int Quantity { get; set; }
    }
}
