using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source
{
    public class World : Transformable, Drawable
    {
        public IntPair WorldSize = new IntPair(1920, 1080);
        public IntPair StartPosition;

        public Sprite Background;
        
        public Player Player { get; set; }

        public bool[] Directions = new bool[4];     // Направо > вверх > налево > вниз

        public World(string backgroundName)
        {
            StartPosition = new IntPair(WorldSize.X / 2, WorldSize.Y / 2);

            Background = new Sprite(Content.Backgrounds[backgroundName], new IntRect(0, 0, WorldSize.X, WorldSize.Y));

            Player = new Player();
        }

        public void Update(Time time)
        {
            if (Player.IsMoving)
            {
                var newTargetAngle = GetNewTargetAngle();
                var deltaAngle = Math.Abs(newTargetAngle - Player.Angle) - 180;

                if (newTargetAngle > Player.Angle)
                {
                    if (deltaAngle < 0)
                        Player.Angle += Player.RotateSpeedDS * time.AsSeconds();
                    else
                        Player.Angle -= Player.RotateSpeedDS * time.AsSeconds();
                }
                else
                {
                    if (deltaAngle < 0)
                        Player.Angle -= Player.RotateSpeedDS * time.AsSeconds();
                    else
                        Player.Angle += Player.RotateSpeedDS * time.AsSeconds();
                }

                if (Player.Angle < 0)
                    Player.Angle = 360 + Player.Angle;
                else if (Player.Angle > 360)
                    Player.Angle -= 360;
            }
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

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Background);
        }
    }
}
