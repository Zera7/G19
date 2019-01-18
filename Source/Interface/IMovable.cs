using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface IMovable : IGameObject
    {
        int Speed { get; set; }
        float Angle { get; set; }

        void Move();
        void Intersect();
    }
}
