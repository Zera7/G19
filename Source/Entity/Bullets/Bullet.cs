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
    public abstract class Bullet : Layer, IMovable
    {
        public Bullet(int team, Vector2f position, float angle, World world, int speedPS, int power, int radius = 8)
        {
            this.Team = team;
            this.Position = position;
            this.MoveAngle = angle;
            this.World = world;
            this.IntersectionRadius = radius;
            this.SpeedPS = speedPS;

            Background = new CircleShape(IntersectionRadius, 3)
            {
                FillColor = Color.Red,
                Rotation = 90 - MoveAngle,
                Position = this.Position,
                Origin = new Vector2f(IntersectionRadius, IntersectionRadius)
            };
        }

        // Layer Implementation
        public override Drawable Background { get; set; }
        public override Vector2f Size { get; set; }

        // IMovable Interface
        public bool IsMoving { get; set; } = true;
        public int SpeedPS { get; set; }
        public int RotateSpeedDS { get; set; }
        public float MoveAngle { get; set; }

        // IGameObject Interface
        public int Team { get; set; }
        public IntPair Coordinates { get; set; }
        public float IntersectionRadius { get; set; }
        public World World { get; }

        public int Power { get; set; }
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

        public override void Update(Time time)
        {
            Move(time);
            Intersect();

            if (!IsInsideMap)
                IsRemoved = true;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            //DrawShaders(target, ref states);
            target.Draw(Background, states);
        }

        public virtual void Move(Time time)
        {
            Position = new Vector2f(
                Position.X + (float)Math.Cos(MoveAngle * Math.PI / 180) * SpeedPS * time.AsSeconds(),
                Position.Y - (float)Math.Sin(MoveAngle * Math.PI / 180) * SpeedPS * time.AsSeconds());

            ((CircleShape)Background).Position = Position;
        }

        public virtual void Intersect()
        {
        }

        public override Texture GetBackgroundTexture()
        {
            throw new NotImplementedException();
        }
    }
}