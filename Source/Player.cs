using G19.Source.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using G19.Source.Model;

namespace G19.Source
{
    public class Player : ISlavable, IAttackable, IMovable
    {
        public int SpeedPS { get; set; } = 120;
        public float Angle { get; set; }
        public int Team { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IntPair Coordinates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float IntersectionRadius { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsMoving { get; set; }
        public AttackCharacteristics[] Attacks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RotateSpeedDS { get; set; } = 360;

        public Player()
        {

        }

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
