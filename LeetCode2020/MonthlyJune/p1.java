public class p1{

    class Solution {
        public TreeNode invertTree(TreeNode root) {
            if(root == null) {return null;}
            var left = root.left;
            root.left = invertTree(root.right);
            root.right = invertTree(left);
            return root;
        }
    }
}