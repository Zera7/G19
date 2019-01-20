using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source
{
    public class World : Transformable, Drawable
    {
        public IntPair WorldSize = new IntPair(1920, 1080);
        public IntPair StartPosition;

        public Sprite Background;
        
        public Player Player { get; set; }


        public World(string backgroundName)
        {
            StartPosition = new IntPair(WorldSize.X / 2, WorldSize.Y / 2);

            Background = new Sprite(Content.Backgrounds[backgroundName], new IntRect(0, 0, WorldSize.X, WorldSize.Y));

            Player = new Player(StartPosition);
        }

        public void Update(Time time)
        {
            if (Player.IsMoving)
            {
                Player.Move(time);
                Program.Cursor.Move();
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(Background);
            target.Draw(Player);
        }
    }
}
