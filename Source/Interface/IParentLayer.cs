using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface IParentLayer
    {
        Dictionary<string, ExtendedLinkedList<Layer>> SubLayers { get; set; }
    }
}
