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
        public View View { get; set; }

        public Clock Clock = new Clock();

        public Text TestText = new Text("dfghj", Content.Font);

        public Game()
        {
            World = new World("snow");
            View = new View(
                new Vector2f(World.StartPosition.X, World.StartPosition.Y),
                new Vector2f(Program.Width, Program.Height));

            TestText.Color = Color.Red;
            TestText.Position = new Vector2f(50, 50);
        }

        public void Draw()
        {
            var a = Clock.Restart();
            World.Update(a);

            if (World.Player.IsMoving)
                View.Center = new Vector2f(
                    View.Center.X + (float)Math.Cos(World.Player.Angle * Math.PI / 180) * World.Player.SpeedPS * a.AsSeconds(), 
                    View.Center.Y - (float)Math.Sin(World.Player.Angle * Math.PI / 180) * World.Player.SpeedPS * a.AsSeconds());

            Program.Window.Draw(World);

            Program.Window.SetView(View);

            //TestText.DisplayedString = World.Player.Angle.ToString();
            //Program.Window.Draw(TestText);
        }

        public void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Right:
                    World.Directions[0] = true;
                    World.Player.IsMoving = true;
                    break;
                case Keyboard.Key.Up:
                    World.Directions[1] = true;
                    World.Player.IsMoving = true;
                    break;
                case Keyboard.Key.Left:
                    World.Directions[2] = true;
                    World.Player.IsMoving = true;
                    break;
                
                case Keyboard.Key.Down:
                    World.Directions[3] = true;
                    World.Player.IsMoving = true;
                    break;
            }
        }

        public void HandleKeyReleased(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Right:
                    World.Directions[0] = false;
                    break;
                case Keyboard.Key.Up:
                    World.Directions[1] = false;
                    break;
                case Keyboard.Key.Left:
                    World.Directions[2] = false;
                    break;
                case Keyboard.Key.Down:
                    World.Directions[3] = false;
                    break;
            }

            for (int i = 0; i < World.Directions.Length; i++)
                if (World.Directions[i])
                    return;
            World.Player.IsMoving = false;
        }
    }
}
