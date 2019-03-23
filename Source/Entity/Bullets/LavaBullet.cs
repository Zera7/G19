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
            ExternalShader = new Shader(null, Content.Shaders["LightingShader"]);
            ExternalShader.SetParameter("frag_LightColor", Color.Yellow);
            ExternalShader.SetParameter("frag_LightAttenuationRadius", 100);
            ExternalShader.SetParameter("frag_ScreenResolution", World.WorldSize.X, World.WorldSize.Y);

            // InnderShader
        }

        public LavaBullet(int team, Vector2f position, float angle, int speedPS, int power, World world) : base(
            team: team,
            position: position,
            angle: angle,
            world: world,
            speedPS: speedPS,
            power: power)
        {
        }

        static Shader ExternalShader { get; set; }
        static Shader InnerShader { get; set; }

        public override Shader GetExternalShader()
        {
            return ExternalShader;
        }

        public override void SetExternalShaderParameters(int index)
        {
            ExternalShader.SetParameter($"array[{index}]", Position);
        }
    }
}
