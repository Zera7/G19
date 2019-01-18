using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source
{
    public static class Content
    {
        public const string FontsPath = "Fonts/";

        public const string ImagesPath = "Images/";
        public const string BackgroundPath = "Background/";


        public static List<Texture> Textures;
        public static Font Font;

        public static void Load()
        {
            try
            {
                Font = new Font(FontsPath + "Oswald-Regular.ttf");
                Textures.Add(new Texture(ImagesPath + BackgroundPath + "snow.jpg"));
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
