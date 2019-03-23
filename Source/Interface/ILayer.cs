using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface ILayer: Drawable, IShaderDrawable
    {
        Drawable Background { get; set; }
        Vector2f Size { get; set; }
        bool IsRemoved { get; set; }

        Texture GetBackgroundTexture();
        void SetExternalShaderParameters(int index);
        void Update(Time time);
        void ShowLayer(Time time);
        void HideLayer(Time time);
    }
}
