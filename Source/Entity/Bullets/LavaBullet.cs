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
            Shader = new Shader(null, Content.Shaders["LightingShader"]);
            Shader.SetParameter("frag_LightColor", Color.Yellow);
            Shader.SetParameter("frag_LightAttenuationRadius", 35);
            Shader.SetParameter("frag_ScreenResolution", Program.Window.Size.X, Program.Window.Size.Y);

            //ShaderSprite = new Sprite(World.ShaderTexture.Texture);
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

        static Shader Shader { get; set; }
        static Sprite ShaderSprite { get; set; }
        
        //public override void DrawShaders(RenderTarget target, ref RenderStates states)
        //{
        //    var coords = Sprite.Position - Program.View.GetCoordinates();

        //    Shader.SetParameter("frag_LightOrigin", coords.X, coords.Y);

        //    var newStates = new RenderStates(states);
        //    newStates.Shader = Shader;
        //    target.Draw(ShaderSprite, newStates);
        //}
    }
}
