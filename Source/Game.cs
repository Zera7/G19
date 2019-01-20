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
        public World World { get; set; }

        public GameSFEventHandler EventHandler { get; set; }

        public Clock Clock = new Clock();

        public Text TestText = new Text("dfghj", Content.Font);


        public Game()
        {
            World = new World("snow");

            EventHandler = new GameSFEventHandler(Program.Window, World, Program.Cursor);
            EventHandler.Connect();

            Program.View = new View(
                new Vector2f(World.StartPosition.X, World.StartPosition.Y),
                new Vector2f(Program.Width, Program.Height));

            Program.Cursor.State = CursorState.Aim;

            TestText.Color = Color.Red;
            TestText.Position = new Vector2f(50, 50);
        }

        public void Draw()
        {
            var a = Clock.Restart();
            World.Update(a);

            if (World.Player.IsMoving)
                Program.View.Center = World.Player.Position;

            Program.Window.Draw(World);
            Program.Window.Draw(Program.Cursor);

            Program.Window.SetView(Program.View);
        }
    }
}
