using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source
{
    public class World
    {
        public IntPair WorldSize = new IntPair(1920, 1080);
        public IntPair StartPosition;

        public World()
        {
            StartPosition = new IntPair(WorldSize.X / 2, WorldSize.Y / 2);
        }
    }
}
