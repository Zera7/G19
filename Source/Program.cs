﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using G19.Source.Interface;

namespace G19.Source
{
    static class Program
    {
        public const int Width = 800;
        public const int Height = 600;

        public const bool FpsOn = true;

        public static RenderWindow Window;
        public static View View;
        public static Cursor Cursor;
        public static Clock Clock = new Clock();
        public static float TimeInSeconds {
            get
            {
                return timeInSeconds;
            }
            set
            {
                if (value > float.MaxValue - 1000)
                    timeInSeconds = 0;
                else
                    timeInSeconds = value;
            }
        }
        private static float timeInSeconds;

        static void Main(string[] args)
        {
            Content.Load();
            View = new View();
            Cursor = new Cursor(Width / 2, Height / 2, View);

            // fps
            Text fps = new Text("", Content.Font)
            {
                Color = Color.Green,
                CharacterSize = 24
            };
            int fc = 0;
            // ---

            Window = new RenderWindow(new VideoMode(Width, Height), "G19");
            Window.SetMouseCursorVisible(false);
            Window.Closed += Close;
            Window.Resized += Resize;

            var game = new Game();

            while (Window.IsOpen)
            {
                Window.SetView(View);

                var time = Clock.Restart();
                TimeInSeconds += time.AsSeconds();
                Window.DispatchEvents();

                Window.Clear();
                game.Update(time);

                game.Draw();

                Window.Draw(Cursor);

                if (FpsOn)
                {
                    fc += 1;
                    if (fc > 40)
                    {
                        fps.DisplayedString = (1 / time.AsSeconds()).ToString();
                        fc = 0;
                    }
                    fps.Position = View.GetCoordinates();
                    Window.Draw(fps);
                }

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
