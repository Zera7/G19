using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19
{
    public static class ViewExtensions
    {
        public static Vector2f GetCoordinates(this View view)
        {
            return new Vector2f(
                view.Center.X - view.Size.X / 2,
                view.Center.Y - view.Size.Y / 2);
        }

        public static float GetLeft(this View view)
        {
            return view.Center.X - view.Size.X / 2;
        }

        public static float GetTop(this View view)
        {
            return view.Center.Y - view.Size.Y / 2;
        }
    }
}
