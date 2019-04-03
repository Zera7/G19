using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface IMovable : IGameObject
    {
        bool IsMoving { get; set; }
        float SpeedPS { get; set; }
        float RotateSpeedDS { get; set; }
        float MoveAngle { get; set; }

        void Move(Time time);
        void Intersect();
    }
}
