using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace G19.Source.Entity.Bullets
{
    public class LavaBullet : Bullet
    {
        static LavaBullet()
        {
            // External Shader
            ExternalShader = new Shader(null, Content.Shaders["LightingShader"]);
            ExternalShader.SetParameter("frag_LightColor", Color.Red);
            ExternalShader.SetParameter("frag_ScreenResolution", World.WorldSize.X, World.WorldSize.Y);

            // Innder Shader
            InnerShader = new Shader(null, Content.Shaders["LavaSphereShader"]);
            InnerShader.SetParameter("frag_LightColor", Color.Black);
        }

        public LavaBullet(int team, Vector2f position, float angle, int speedPS, int power, World world) : base(
            team: team,
            position: position,
            angle: angle,
            world: world,
            speedPS: speedPS,
            power: power)
        {
            var rnd = new Random();
            randomTimeChange = (float)rnd.NextDouble() * -100;

            ExternalShader.SetParameter("frag_LightAttenuationRadius", IntersectionRadius + 5);
        }

        static Shader ExternalShader { get; set; }
        static Shader InnerShader { get; set; }

        readonly float randomTimeChange;

        public override void InitBackground()
        {
            Background = new CircleShape(IntersectionRadius, 18)
            {
                Position = this.Position,
                Origin = new Vector2f(IntersectionRadius, IntersectionRadius)
            };
        }

        public override Shader GetExternalShader()
        {
            return ExternalShader;
        }

        public override void SetExternalShaderParameters(int index)
        {
            ExternalShader.SetParameter($"array[{index}]", Position);
        }

        public override void SetInnerShaderGeneralParameters()
        {
            InnerShader.SetParameter("frag_Resolution", World.WorldSize.X, World.WorldSize.Y);
            InnerShader.SetParameter("frag_Center", Position.X, Position.Y);
            InnerShader.SetParameter("frag_Radius", IntersectionRadius);
            InnerShader.SetParameter("frag_Time", Program.TimeInSeconds + randomTimeChange);
        }

        public override Shader GetInnerShader()
        {
            return InnerShader;
        }
    }
}
