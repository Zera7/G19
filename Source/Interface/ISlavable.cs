using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface ISlavable
    {
        bool[] Directions { get; set; }     // Направо > вверх > налево > вниз

        void Control();
    }
}
