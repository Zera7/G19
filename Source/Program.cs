using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace G19.Source
{
    class Program
    {
        public const int Width = 800;
        public const int Height = 600;



        static RenderWindow Window = new RenderWindow(new SFML.Window.VideoMode(Width, Height), "G19");
        static Font Font;

        static void Main(string[] args)
        {
            Window.Closed += Close;

            Initialize();
            Text text = new Text("Тест", Font);
            text.Origin = new SFML.System.Vector2f(text.GetLocalBounds().Width / 2, 0);

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear(Color.Black);

                Window.Draw(text);

                Window.Display();
            }
        }

        private static void Initialize()
        {
            
        }

        private static void Close(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
