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
        public CursorState State { get; set; } = CursorState.Arrow;
        public View View { get; }

        public Vector2f WPosition;

        Dictionary<CursorState, Texture> Textures { get; set; }
        CircleShape Sprite { get; set; }

        public Cursor(int startX, int startY, View view)
        {
            this.View = view;
            Textures = new Dictionary<CursorState, Texture>();

            WPosition = new Vector2f(startX, startY);

            Sprite = new CircleShape(10, 16)
            {
                FillColor = new Color(100, 100, 0, 200),
                Position = TransformToGlobal(WPosition)
            };
        }

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
