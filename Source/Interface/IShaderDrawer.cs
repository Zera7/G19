using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface IShaderDrawable
    {
        Shader InnerShader { get; set; }
        Shader ExternalShader { get; set; }

        void DrawSubShaders(RenderTarget target, ref RenderStates states);
    }
}
