using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G19.Source.Entity;
using G19.Source.Entity.Bullets;

namespace G19.Source.Weapons
{
    class LavaGun: Weapon
    {
        public LavaGun(World world) : base(
            world: world,
            power: 53, 
            bulletSpeed: 200, 
            attackInterval: 0.1f, 
            reloadTime: 3f, 
            maxPatronCount: 7)
        {
        }

        public override Bullet GetBullet()
        {
            return new LavaBullet(
                team: World.Player.Team,
                position: World.Player.Position,
                angle: World.Player.Angle,
                speedPS: BulleetSpeed,
                power: Power,
                world: World);
        }
    }
}
