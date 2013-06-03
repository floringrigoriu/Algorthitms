using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatireInterviewuri2013
{
    public class Trees
    {
        public static TreeNode<T> NextNodeInorder<T>(TreeNode<T> root)
        {
            if (root == null)
            {
                return null;
            }
            var result = root.Right;
            if (result != null)
            {
                while (result.Left != null)
                { result = result.Left; }
            }
            else
            {
                result = root.Parent;
                var last = root;
                while (result != null && last == result.Right)
                {
                    last = result;
                    result = result.Parent;
                }
            }
            return result;
        }


        /// <summary>
        /// 1.Determine node  to remove
        /// 2. Find Replecement
        /// 3. Replace Values
        /// 4. Remove replacement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public static TreeNode<int>  BSTNodeReplace(TreeNode<int>  node , int value )
        {
            // 1.
            var result = node;
            Action<TreeNode<int>> setter = (n) => { result = n; };
            Func<TreeNode<int>> getter = () => result;
            var current = getter();

            while (null != current && current.Value != value)
            {
                if (current.Value > value)
                {
                    setter = (n) => { current.Left = n; };
                    getter = () => { return current.Left; };
                    current = current.Left;
                }
                else 
                {
                    setter = (n) => { current.Right = n; };
                    getter = () => { return current.Right; };
                    current = current.Right;

                }
                
            }
            if (null == current)
            {
                // value not found
                return null;
            }
            // 2.
            TreeNode<int> parent = current;
            Action<TreeNode<int>> setter2 = null;
            if (current.Left != null)
            {
                setter2 = (n) => {parent.Left = n;};
                current = current.Left;
                while (current.Right !=null)
                {
                    parent = current;
                    setter2 = (n) => { parent.Right = n; };
                    current = current.Right;

                }
            }
            else if (current.Right != null)
            {
                setter2 = (n) => { parent.Right = n; };
                current = current.Right;
                while (current.Left != null)
                {
                    parent = current;
                    setter2 = (n) => { parent.Left = n; };
                    current = current.Left;
                }
            }
            else 
            {
                // end node 
                setter(null);
                return node;
            }

            // 3 
            getter().Value = current.Value;
            // 4
            setter2(current.Left ?? current.Right);
            return node;
        }

        public class TreeNode<T> 
        {
            public TreeNode(T value, TreeNode<T> left = null, TreeNode<T> right = null)
            {
                this.Value = value;
                this.Left = left;
                if (null != this.Left)
                {
                    this.Left.Parent = this;
                }
                this.Right = right;
                if (this.Right != null)
                {
                    this.Right.Parent = this;
                }

            }
            
            public T Value { get; set; }
            public TreeNode<T> Parent { get; set; }
            public TreeNode<T> Left { get; set; }
            public TreeNode<T> Right { get; set; }
        }
    }
}
