using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface ISubShadersDrawable
    {
        RenderTexture FrontShaderTexture { get; set; }
        RenderTexture BackShaderTexture { get; set; }

        void AddShaderToRenderTexture(RenderStates states);
        void DrawSubShaders(RenderStates states);
    }
}
