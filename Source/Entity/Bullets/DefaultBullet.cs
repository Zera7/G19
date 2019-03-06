using G19.Source.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace G19.Source.Entity
{
    public class DefaultBullet : Bullet
    {
        public DefaultBullet(int team, Vector2f position, float angle, int speedPS, int power, World world) : base(
            team: team,
            position: position,
            angle: angle,
            world: world,
            speedPS: speedPS,
            power: power)
        {
        }
    }
}