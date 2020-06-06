package eu.floringrigoriu.algos;

public class p1 {

    class Solution {
        public TreeNode invertTree(TreeNode root) {
            if(root == null) {return null;}
            TreeNode left = root.left;
            root.left = invertTree(root.right);
            root.right = invertTree(left);
            return root;
        }
    }
}