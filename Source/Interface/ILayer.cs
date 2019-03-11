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
        Dictionary<string, ExtendedLinkedList<ILayer>> SubLayers { get; set; }
        Drawable Background { get; set; }
        bool IsRemoved { get; set; }

        void Update(Time time);
        void ShowLayer(Time time);
        void HideLayer(Time time);
    }
}
