using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G19.Source.Entity;

namespace G19.Source.Weapons
{
    public class AssaultRifle: Weapon
    {
        public AssaultRifle(World world) : base(
            world: world,
            power: 5, 
            bulletSpeed: 1500, 
            attackInterval: 0.1f, 
            reloadTime: 2f, 
            maxPatronCount: 30)
        {
        }

        public override Bullet GetBullet()
        {
            return new DefaultBullet(
                team: World.Player.Team,
                position: World.Player.Position,
                angle: World.Player.Angle,
                speedPS: BulleetSpeed,
                power: Power,
                world: World);
        }
    }
}
