using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source
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

        public static void SetPositionWithConstraints(this View view, IntPair rect, Vector2f pos)
        {
            view.Center = new Vector2f(
                GetPositionCalculatedWithConstraint(view.Size.X / 2, pos.X, rect.X),
                GetPositionCalculatedWithConstraint(view.Size.Y / 2, pos.Y, rect.Y));
        }

        static float GetPositionCalculatedWithConstraint(float halfSize, float pos, int constraint)
        {
            var a = pos;
            if (pos - halfSize < 0)
                a = halfSize;
            if (pos + halfSize > constraint)
                a = constraint - halfSize;
            if (constraint < 2 * halfSize)
                a = constraint / 2;
            return a;
        }
    }
}