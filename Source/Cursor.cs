using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source
{
    public enum CursorState
    {
        Arrow,
        Aim
    }

    public class Cursor : Drawable
    {
        public Cursor(int startX, int startY, View view)
        {
            this.View = view;
            Sprites = new Dictionary<CursorState, Sprite>();

            WPosition = new Vector2f(startX, startY);

            var spriteRadius = 10;
            Sprite = new CircleShape(spriteRadius, 16)
            {
                FillColor = new Color(160, 160, 0, 200),
                Position = TransformToGlobal(WPosition),
                Origin = new Vector2f(spriteRadius, spriteRadius)
            };
        }

        CursorState state = CursorState.Arrow;
        public CursorState State
        {
            get
            {
                return state;
            }
            set
            {
                var coords = Sprite.Position;
                switch (value)
                {
                    case CursorState.Arrow:
                        break;
                    case CursorState.Aim:
                        break;
                }
                Sprite.Position = coords;
            }
        }

        public View View { get; }
        public Vector2f WPosition { get; set; }

        Dictionary<CursorState, Sprite> Sprites { get; set; }
        CircleShape Sprite { get; set; }

        public void Move(int windowX, int windowY)
        {
            WPosition = new Vector2f(windowX, windowY);
            Sprite.Position = TransformToGlobal(WPosition);
        }

        public void Move()
        {
            Sprite.Position = TransformToGlobal(WPosition);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Sprite);
        }

        Vector2f TransformToGlobal(Vector2f coords)
        {
            return new Vector2f(
                (int)(View.Center.X - View.Size.X / 2) + coords.X,
                (int)(View.Center.Y - View.Size.Y / 2) + coords.Y);
        }
    }
}
