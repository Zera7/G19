using G19.Source.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace G19.Source
{
    public class Player : ISlavable, IAttackable, IMovable
    {
        public int Speed { get; set; }
        public float Angle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Team { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IntPair Coordinates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float IntersectionRadius { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AttackDistance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int[] AttackPower { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void Control()
        {
            throw new NotImplementedException();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new NotImplementedException();
        }

        public void Intersect()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
