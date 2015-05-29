using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingImplementations
{
    /// <summary>
    /// Implementation of a heap tree
    /// </summary>
    public class Heap<T,W>
        where W: IComparable
    {

        public Heap(Func<T, W> selector) 
        {
            this.HeapCriteriaSelector = selector;
        }

        public Func<T, W> HeapCriteriaSelector { get; private set; }

        public T GetMin()
        { 
        }

        public T RemoveMin()
        { 
        }

        public void Add(T newElement)
        { 
        }

        public bool IsEmpty 
        {
        }
    }
}
