using G19.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface IAttackable : IGameObject
    {
        AttackCharacteristics[] Attacks { get; set; }

        void Attack();
    }
}