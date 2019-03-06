using G19.Source.Interface;
using G19.Source.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace G19.Source.Entity
{
    public class Player : Transformable, ISlavable, IAttackable, IMovable
    {
        public const int DirectionRadius = 7;
        public const int DirectionRemoteness = 70;

        public int SpeedPS { get; set; } = 120;
        public float Angle { get; set; }
        public int Team { get; set; } = 1;
        public IntPair Coordinates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float IntersectionRadius { get; set; } = 10;
        public bool IsMoving { get; set; }
        public Weapon[] Weapons { get; set; }
        public int RotateSpeedDS { get; set; } = 360;
        public bool[] Directions { get; set; } = new bool[4];
        public World World { get; }
        public int CurrentWeapon { get; set; }
        public bool IsAttacks { get; set; }


        public CircleShape PlayerSprite { get; set; }
        public CircleShape DirectionSprite { get; set; }

        public Player(World world, IntPair startPosition)
        {
            World = world;

            Weapons = new Weapon[2];
            Weapons[0] = new AssaultRifle(World);

            PlayerSprite = new CircleShape(IntersectionRadius, 3)
            {
                FillColor = Color.Green,
                Origin = new Vector2f(IntersectionRadius, IntersectionRadius),
                Position = new Vector2f(startPosition.X, startPosition.Y),
                Rotation = 90
            };

            DirectionSprite = new CircleShape(DirectionRadius, 3)
            {
                FillColor = new Color(0, 0, 0, 50),
                Origin = new Vector2f(DirectionRadius, DirectionRadius + DirectionRemoteness),
                Position = new Vector2f(startPosition.X, startPosition.Y),
                Rotation = 90
            };

            Position = new Vector2f(startPosition.X, startPosition.Y);
        }

        public void Attack()
        {
            Weapons[CurrentWeapon].Fire();
        }

        public void Control()
        {
            throw new NotImplementedException();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(PlayerSprite);
            target.Draw(DirectionSprite);
        }

        public void Intersect()
        {
            throw new NotImplementedException();
        }

        public void Update(Time time)
        {
            if (IsMoving)
                Move(time);
            if (IsAttacks)
                Attack();
        }

        public void Move(Time time)
        {
            UpdateAngle(time);
            DirectionSprite.Rotation = 90 - Angle;
            Position = new Vector2f(  
                    Program.View.Center.X + (float)Math.Cos(Angle * Math.PI / 180) * SpeedPS * time.AsSeconds(),
                    Program.View.Center.Y - (float)Math.Sin(Angle * Math.PI / 180) * SpeedPS * time.AsSeconds());

            PlayerSprite.Position = Position;
            DirectionSprite.Position = Position;
        }

        private void UpdateAngle(Time time)
        {
            var newTargetAngle = GetNewTargetAngle();
            var deltaAngle = Math.Abs(newTargetAngle - Angle);
            var rotateAngle = RotateSpeedDS * time.AsSeconds();

            if (rotateAngle >= deltaAngle)
                Angle = newTargetAngle;
            else if (newTargetAngle > Angle)
            {
                if (deltaAngle < 180)
                    Angle += rotateAngle;
                else
                    Angle -= rotateAngle;
            }
            else
            {
                if (deltaAngle < 180)
                    Angle -= rotateAngle;
                else
                    Angle += rotateAngle;
            }

            if (Angle < 0)
                Angle = 360 + Angle;
            else if (Angle > 360)
                Angle -= 360;
        }

        public float GetNewTargetAngle()
        {
            float newAngle = 0;
            for (int i = 0; i < Directions.Length; i++)
            {
                if (Directions[i])
                {
                    newAngle = 90 * i;
                    if (i + 1 < Directions.Length && Directions[i + 1])
                        newAngle += 45;
                    else if (i > 0 && Directions[0])
                        newAngle -= 45;
                    else if (i == 0 && Directions[Directions.Length - 1])
                        newAngle -= 45;
                    break;
                }
            }

            if (newAngle < 0)
                newAngle += 360;

            return newAngle;
        }
    }
}
