﻿using G19.Source.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Weapons
{
    public class Pistol : Weapon
    {
        public Pistol(World world) : base(world, 5, 0.5f, 1.5f, 7)
        {
        }
        
    }
}
