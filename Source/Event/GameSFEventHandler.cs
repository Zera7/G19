using G19.Source.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace G19.Source.Event
{
    public class GameSFEventHandler : SFEventHandler
    {
        public World World { get; }

        public GameSFEventHandler(RenderWindow window, World world, Cursor cursor) : base(window, cursor)
        {
            this.World = world;
        }

        public override void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Right:
                    World.Player.Directions[0] = true;
                    World.Player.IsMoving = true;
                    break;
                case Keyboard.Key.Up:
                    World.Player.Directions[1] = true;
                    World.Player.IsMoving = true;
                    break;
                case Keyboard.Key.Left:
                    World.Player.Directions[2] = true;
                    World.Player.IsMoving = true;
                    break;

                case Keyboard.Key.Down:
                    World.Player.Directions[3] = true;
                    World.Player.IsMoving = true;
                    break;
            }
        }

        public override void HandleKeyReleased(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Right:
                    World.Player.Directions[0] = false;
                    break;
                case Keyboard.Key.Up:
                    World.Player.Directions[1] = false;
                    break;
                case Keyboard.Key.Left:
                    World.Player.Directions[2] = false;
                    break;
                case Keyboard.Key.Down:
                    World.Player.Directions[3] = false;
                    break;
            }

            for (int i = 0; i < World.Player.Directions.Length; i++)
                if (World.Player.Directions[i])
                    return;
            World.Player.IsMoving = false;
        }

        public override void HandleMouseMoved(object sender, MouseMoveEventArgs e)
        {
            base.HandleMouseMoved(sender, e);

            float angle = (float)(Math.Atan2(
                Program.View.Center.Y - World.Player.Position.Y - e.Y + Program.View.Size.Y / 2, 
                Program.View.Center.X - World.Player.Position.X - e.X + Program.View.Size.X / 2)
                / Math.PI * 180) - 90;
            World.Player.PlayerSprite.Rotation = angle < 0 ? angle + 360 : angle;

            Cursor.Move(e.X, e.Y);
        }
    }
}
