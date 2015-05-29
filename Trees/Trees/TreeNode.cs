
namespace Trees
{
    /// <summary>
    /// Generic tree class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T>
    {
        /// <summary>
        /// Empty contructor
        /// </summary>
        public TreeNode()
        {
        }

        /// <summary>
        /// initialization contrusctor
        /// </summary>
        public TreeNode(T value , TreeNode<T> left, TreeNode<T> right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
}
