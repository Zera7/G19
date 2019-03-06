using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Weapons
{
    public class AssaultRifle: Weapon
    {
        public AssaultRifle(World world) : base(world, 5, 0f, 2f, 70)
        {
        }
    }
}
