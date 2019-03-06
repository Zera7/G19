using G19.Source.Interface;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace G19.Source.Entity
{
    public abstract class Bullet : Transformable, IMovable
    {
        public Bullet(int team, Vector2f position, float angle, World world, int speedPS, int power, int radius = 8)
        {
            this.Team = team;
            this.Position = position;
            this.Angle = angle;
            this.World = world;
            this.IntersectionRadius = radius;
            this.SpeedPS = speedPS;

            Sprite = new CircleShape(IntersectionRadius, 3)
            {
                FillColor = Color.Red,
                Rotation = 90 - Angle,
                Position = this.Position,
                Origin = new Vector2f(IntersectionRadius, IntersectionRadius)
            };
        }

        public bool IsMoving { get; set; } = true;
        public int SpeedPS { get; set; }
        public int Power { get; set; }
        public int RotateSpeedDS { get; set; }
        public float Angle { get; set; }
        public int Team { get; set; }
        public IntPair Coordinates { get; set; }
        public float IntersectionRadius { get; set; }
        public bool IsRemoved { get; set; }

        public CircleShape Sprite { get; set; }

        public World World { get; }


        public bool IsInsideMap
        {
            get
            {
                return 0 - IntersectionRadius < Position.X &&
                    0 - IntersectionRadius < Position.Y && 
                    Position.X < World.WorldSize.X + IntersectionRadius &&
                    Position.Y < World.WorldSize.Y + IntersectionRadius;
            }
        }
    
        public void Draw(RenderTarget target, RenderStates states)
        {
            //states.Transform *= Transform;

            target.Draw(Sprite, states);
        }

        public virtual void Intersect()
        {
        }

        public void Update(Time time)
        {
            Move(time);
            Intersect();
        }

        public virtual void Move(Time time)
        {
            Position = new Vector2f(
                Position.X + (float)Math.Cos(Angle * Math.PI / 180) * SpeedPS * time.AsSeconds(),
                Position.Y - (float)Math.Sin(Angle * Math.PI / 180) * SpeedPS * time.AsSeconds());

            Sprite.Position = Position;
        }
    }
}