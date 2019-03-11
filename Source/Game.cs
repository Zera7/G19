using G19.Source.Event;
using G19.Source.Interface;
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

            SubLayers.Add(World);

            Program.View.Size = new Vector2f(Program.Width, Program.Height);
            Program.View.Center = new Vector2f(World.StartPosition.X, World.StartPosition.Y);

            Program.Cursor.State = CursorState.Aim;
        }

        public World World { get; set; }
        public List<ILayer> SubLayers { get; set; } = new List<ILayer>();

        public GameSFEventHandler EventHandler { get; set; }

        public void Draw()
        {
            Program.Window.Draw(World);
        }

        public void Update(Time time)
        {
            World.Update(time);
            Program.Cursor.Move();

            if (World.Player.IsMoving)
                Program.View.SetPositionWithConstraints(World.WorldSize, World.Player.Position);
        }
    }
}
