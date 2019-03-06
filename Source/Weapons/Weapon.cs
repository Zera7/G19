using G19.Source.Entity;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Weapons
{
    public abstract class Weapon
    {
        public Weapon(World world, int power, float attackInterval, float reloadTime, int maxPatronCount)
        {
            this.Power = power;
            this.AttackIntervalInSeconds = attackInterval;
            this.ReloadTimeInSeconds = reloadTime;
            this.MaxPatronCount = maxPatronCount;
            this.PatronCount = maxPatronCount;
            this.World = world;
        }

        public int Power { get; set; }
        public int Distance { get; set; }  // Радиус атаки, 0 - неограничен
        public int PatronCount { get; set; }
        public int MaxPatronCount { get; set; }
        public float ReloadTimeInSeconds { get; set; }
        public float AttackIntervalInSeconds { get; set; }
        public World World { get; }
        public DateTime LastShotTime { get; set; }
        public DateTime LastReloadTime { get; set; }

        public virtual void Fire()
        {
            if (DateTime.Now - LastShotTime > new TimeSpan(0, 0, 0, 0, (int)(AttackIntervalInSeconds * 1000)) &&
                DateTime.Now - LastReloadTime > new TimeSpan(0, 0, 0, 0, (int)(ReloadTimeInSeconds * 1000)))
            {
                var bullet = new DefaultBullet(World.Player.Team, World.Player.Position, World.Player.Angle, World);
                World.Bullets.AddLast(bullet);
                LastShotTime = DateTime.Now;

                PatronCount -= 1;

                if (PatronCount <= 0)
                    Reload();
            }
        }

        public void Reload()
        {
            LastReloadTime = DateTime.Now;
            PatronCount = MaxPatronCount;
        }
    }
}
