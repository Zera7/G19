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
        void SetExternalShaderGeneralParameters();
        Shader GetInnerShader();
        Shader GetExternalShader();
    }
}
