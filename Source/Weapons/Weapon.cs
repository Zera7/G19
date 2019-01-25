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

        public abstract void Fire();
    }
}
