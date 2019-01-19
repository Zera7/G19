﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace G19.Source
{
    class Program
    {
        public const int Width = 800;
        public const int Height = 600;


        public static RenderWindow Window;
        public static View View;

        static void Main(string[] args)
        {
            Content.Load();

            View = new View();

            Window = new RenderWindow(new VideoMode(Width, Height), "G19");
            Window.Closed += Close;
            Window.Resized += Resize;

            var game = new Game();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear(Color.Black);

                game.Draw();

                Window.Display();
            }
        }

        private static void Resize(object sender, SizeEventArgs e)
        {
            View.Size = new Vector2f(e.Width, e.Height);
        }

        private static void Close(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
