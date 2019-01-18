using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface IAttackable : IGameObject
    {
        int AttackDistance { get; set; }
        int[] AttackPower { get; set; }

        void Attack();
    }
}
