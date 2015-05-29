using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    /// <summary>
    /// Implementation of a heap tree
    /// </summary>
    public class Heap<T,W>
        where W: IComparable
    {
        internal TreeNode<T> root;
        internal int count = 0;

        public Heap(Func<T, W> selector) 
        {
            this.HeapCriteriaSelector = selector;
        }

        public Func<T, W> HeapCriteriaSelector { get; private set; }

        public T GetMin()
        {
            if (!this.IsEmpty)
            {
                return root.Value;
            }
            else 
            {
                throw new InvalidOperationException("empty heap");
            }
        }

        public T RemoveMin()
        {
            T result = this.GetMin();

            if (this.count == 1)
            {
                this.root = null;
                count--;
            }
            else 
            {
                // find last node
                var current = this.root;
                var mask = GetMask();

                while (mask > 1)
                {
                    if ((mask & this.count) != 0)
                    {
                        current = current.Right;
                    }
                    else 
                    {
                        current = current.Left;
                    }
                    mask >>= 1;
                }
                if((this.count & 0x1 )==0x1)
                {
                    this.root.Value = current.Right.Value;
                    current.Right = null;
                }
                else
                {
                    this.root.Value = current.Left.Value;
                    current.Left = null;
                }
                count--;

                // re-heapify
                var currentNode = root;
                while (currentNode.Left != null)
                {
                    W currentValue = this.HeapCriteriaSelector(current.Value);
                    W leftValue =  this.HeapCriteriaSelector(current.Left.Value);
                    W rightValue = default(W);
                    if(current.Right!=null)
                    {
                        rightValue = this.HeapCriteriaSelector(current.Left.Value);
                    }
                    if (currentValue.CompareTo(leftValue) > 0 && (current.Right == null || currentValue.CompareTo(rightValue) > 0))
                    {
                        // done heapify;
                        break;
                    }
                    else if (rightValue == null || leftValue.CompareTo(rightValue) >0)
                    {
                        var temp = currentNode.Left.Value;
                        currentNode.Left.Value = currentNode.Value;
                        currentNode.Value = temp;

                        currentNode = currentNode.Left;
                    }
                    else 
                    {
                        var temp = currentNode.Right.Value;
                        currentNode.Right.Value = currentNode.Value;
                        currentNode.Value = temp;

                        currentNode = currentNode.Right;
                    }
                }

            }
            return result;
        }

        private int GetMask()
        {
            var mask = 0x1;
            while (count > mask << 1)
            {
                mask <<= 1;
            }

            // remove one extra 0 which is un-necessary
            mask >>= 1;

            return mask;
        }

        public void Add(T newElement)
        {
            if (null == this.root)
            {
                this.root = new TreeNode<T>() { Value = newElement };
            }
            else
            {
                Add(this.root, newElement, GetMask());
            }
            count++;
        }

        private void Add(TreeNode<T> root,T newElement, int mask)
        {
            TreeNode<T> child = null;
            if (root.Left == null)
            {
                root.Left = new TreeNode<T>() { Value = newElement };
                child = root.Left;
            }
            else if (root.Right == null)
            {
                root.Right = new TreeNode<T>() { Value = newElement };
                child = root.Right;
            }
            else 
            {
                child = ((this.count & mask) != 0x0) ? root.Right : root.Left;
                Add(child, newElement, mask >> 1);
            }

            if (this.HeapCriteriaSelector(child.Value).CompareTo(this.HeapCriteriaSelector(root.Value)) > 0)
            {
                var temp = child.Value;
                child.Value = root.Value;
                root.Value = temp;
            }
        }

        public bool IsEmpty 
        {
            get 
            {
                return root == null;
            }
        }
    }
}
