using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface IGameObject : Drawable
    {
        int Team { get; set; }
        IntPair Coordinates { get; set; }
        float IntersectionRadius { get; set; }
        World World { get; }

        void Update(Time time);
    }
}
