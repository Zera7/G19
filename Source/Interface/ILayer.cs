using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface ILayer: Drawable
    {
        List<ILayer> Layers { get; set; }

        void Update(Time time);
        void ShowLayer();
        void HideLayer();
    }
}
