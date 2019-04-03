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
        public const string BackgroundsPath = "Background/";
        public const string ShadersPath = "Shaders/";

        public static Dictionary<string, Texture> Backgrounds;
        public static Dictionary<string, string> Shaders;
        public static Font Font;

        public static void Load()
        {
            Backgrounds = new Dictionary<string, Texture>();
            Shaders = new Dictionary<string, string>();

            try
            {
                Font = new Font(FontsPath + "Oswald-Regular.ttf");
                Backgrounds.Add("snow", new Texture(ImagesPath + BackgroundsPath + "snow.jpg"));
                Shaders.Add("LightingShader", ShadersPath + "LightingShader.frag");
                Shaders.Add("LavaSphereShader", ShadersPath + "LavaSphereShader.frag");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
