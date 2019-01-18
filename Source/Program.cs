using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace G19.Source
{
    class Program
    {
        public const int Width = 800;
        public const int Height = 600;


        public static RenderWindow Window;

        static void Main(string[] args)
        {
            Content.Load();

            Window = new RenderWindow(new VideoMode(Width, Height), "G19");
            Window.Closed += Close;

            var game = new Game();
            Window.KeyPressed += game.HandleKeyPressed;
            Window.KeyReleased += game.HandleKeyReleased;

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear(Color.Black);

                game.Draw();

                Window.Display();
            }
        }

        private static void Close(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
