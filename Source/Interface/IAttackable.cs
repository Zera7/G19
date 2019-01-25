using G19.Source.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface IAttackable : IGameObject
    {
        Weapon[] Weapons { get; set; }
        int CurrentWeapon { get; set; }
        bool IsAttacks { get; set; }

        void Attack();
    }
}