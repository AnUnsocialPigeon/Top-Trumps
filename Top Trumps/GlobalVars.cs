using System.IO;
using System.Windows.Media;

namespace Top_Trumps {
    class GlobalVars {
        public static string CardPath => Directory.GetCurrentDirectory() + "\\Cards.dat";
        public static string CollectionPath => Directory.GetCurrentDirectory() + "\\Collection.dat";
        public static Color DefaultColour => Color.FromArgb(255, 32, 32, 32);
        public static Color ShinyColour => Color.FromArgb(255, 64, 64, 32);
        public static string NoCardImgURI => "https://pbs.twimg.com/profile_images/1185583544929783809/28gV6-gu_400x400.jpg";

    }
}
