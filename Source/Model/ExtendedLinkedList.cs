using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source
{
    public class ExtendedLinkedList<T> : LinkedList<T>
    {
        public int MaxRemovedElementsCount { get; set; } = 100;
        public int RemovedElementsCount { get; set; }
        public bool IsNeedToClearRemovedElements
        {
            get => RemovedElementsCount > MaxRemovedElementsCount;
        }
    }
}
