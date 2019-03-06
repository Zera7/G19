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
        public Pistol(World world) : base(
            world: world,
            power: 5, 
            bulletSpeed: 1300, 
            attackInterval: 0.5f, 
            reloadTime: 1.5f, 
            maxPatronCount: 7)
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
