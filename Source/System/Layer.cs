using G19.Source.Interface;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace G19.Source
{
    public abstract class Layer : Transformable, ILayer
    {
        public abstract Drawable Background { get; set; }
        public abstract Vector2f Size { get; set; }

        public bool IsRemoved { get; set; }

        public abstract void Update(Time time);
        public abstract Texture GetBackgroundTexture();

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            if (IsRemoved)
                return;

            states.Shader = GetInnerShader();

            if (Background != null)
                target.Draw(Background, states);
        }

        public virtual Shader GetInnerShader()
        {
            return null;
        }

        public virtual Shader GetExternalShader()
        {
            return null;
        }

        public virtual void SetExternalShaderParameters(int index)
        {
        }

        public virtual void SetExternalShaderGeneralParameters()
        {
        }

        public virtual void HideLayer(Time time)
        {
        }

        public virtual void ShowLayer(Time time)
        {
        }
    }
}