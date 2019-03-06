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
    public class Game: ILayer
    {
        public Game()
        {
            World = new World("snow");

            EventHandler = new GameSFEventHandler(Program.Window, World, Program.Cursor);
            EventHandler.Connect();

            Layers.Add(World);

            Program.View.Size = new Vector2f(Program.Width, Program.Height);
            Program.View.Center = new Vector2f(World.StartPosition.X, World.StartPosition.Y);

            Program.Cursor.State = CursorState.Aim;
        }

        public World World { get; set; }
        public List<ILayer> Layers { get; set; } = new List<ILayer>();

        public GameSFEventHandler EventHandler { get; set; }

        public void HideLayer()
        {
            throw new NotImplementedException();
        }

        public void ShowLayer()
        {
            throw new NotImplementedException();
        }

        //public void Draw()
        //{
        //    //Program.Window.Draw(World);
        //    //Program.Window.Draw(Program.Cursor);
        //}

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(World);
        }

        public void Update(Time time)
        {
            World.Update(time);

            if (World.Player.IsMoving)
                Program.View.Center = World.Player.Position;
        }
    }
}
