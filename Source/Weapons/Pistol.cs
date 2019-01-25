using G19.Source.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Weapons
{
    public class Pistol : Weapon
    {
        public Pistol(World world) : base(world, 5, 0.6f, 1.5f, 7)
        {
        }

        public override void Fire()
        {
            if (DateTime.Now - LastShotTime > new TimeSpan(0, 0, 0, 0, (int)(AttackIntervalInSeconds * 1000)))
            {
                var bullet = new DefaultBullet(World.Player.Team, World.Player.Position, World.Player.Angle, World);
                World.Bullets.AddLast(bullet);
                LastShotTime = DateTime.Now;
            }
        }
    }
}
