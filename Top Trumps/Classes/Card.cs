namespace Top_Trumps.Classes {
    /// <summary>
    /// Class to hold all the data about any given cards.
    /// </summary>
    public class Card {
        public int CardOverloadCount => 8;

        /// <summary>
        /// Default Contstructor for the Card Class
        /// </summary>
        public Card() { }
        public Card(string csvData) {
            Name = csvData.Split(',')[0];
            ImgURL = csvData.Split(',')[1];
            Attack = int.Parse(csvData.Split(',')[2]);
            Defence = int.Parse(csvData.Split(',')[3]);
            SpAttack = int.Parse(csvData.Split(',')[4]);
            SpDefence = int.Parse(csvData.Split(',')[5]);
            Speed = int.Parse(csvData.Split(',')[6]);
            Shiny = (csvData.Split(',')[7] == "true");
        }
        public Card(string name, string imgURL, int atck, int def, int spAtck, int spDef, int spd, bool shiny) {
            Name = name;
            ImgURL = imgURL;
            Attack = atck;
            Defence = def;
            SpAttack = spAtck;
            SpDefence = spDef;
            Speed = spd;
            Shiny = shiny;
        }
        public Card(CardQuantity c) {
            Name = c.Name;
            ImgURL = c.ImgURL;
            Attack = c.Attack;
            Defence = c.Defence;
            SpAttack = c.SpAttack;
            SpDefence = c.SpDefence;
            Speed = c.Speed;
            Shiny = c.Shiny;
        }


        // Variable Instantiation for the Card Class.
        public string Name { get; set; }
        public string ImgURL { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int SpAttack { get; set; }
        public int SpDefence { get; set; }
        public int Speed { get; set; }
        public bool Shiny { get; set; }

        /// <summary>
        /// Parses the Card type to a string
        /// </summary>
        public string ParseToString => Name + "," + ImgURL.ToString() + 
            "," + Attack.ToString() + "," + Defence.ToString() + "," +
            SpAttack.ToString() + "," + SpDefence.ToString() + "," +
            Speed.ToString() + "," + (Shiny ? "true" : "false");
    }
}
