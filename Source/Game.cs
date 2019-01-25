using G19.Source.Event;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source
{
    public class Game
    {
        public Game()
        {
            World = new World("snow");

            EventHandler = new GameSFEventHandler(Program.Window, World, Program.Cursor);
            EventHandler.Connect();

            Program.View.Size = new Vector2f(Program.Width, Program.Height);
            Program.View.Center = new Vector2f(World.StartPosition.X, World.StartPosition.Y);

            Program.Cursor.State = CursorState.Aim;
        }

        public World World { get; set; }

        public GameSFEventHandler EventHandler { get; set; }

        public Clock Clock = new Clock();

        public void Draw()
        {
            var a = Clock.Restart();
            World.Update(a);

            if (World.Player.IsMoving)
                Program.View.Center = World.Player.Position;

            Program.Window.Draw(World);
            Program.Window.Draw(Program.Cursor);
        }
    }
}
