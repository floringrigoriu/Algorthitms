
namespace Trees
{
    public interface ITraversal<T>
    {
        void Traverse(TreeNode<T> element, IVisitor<T> visitor);
    }
}
