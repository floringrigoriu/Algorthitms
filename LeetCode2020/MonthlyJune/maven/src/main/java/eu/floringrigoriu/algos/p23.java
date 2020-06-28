package eu.floringrigoriu.algos;
// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3369/
/**
 * 
 * Given a complete binary tree, count the number of nodes.

Note:

Definition of a complete binary tree from Wikipedia:
In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.
 */

public class p23 {
    class Solution {
        public int countNodes(TreeNode root) {
            int level = getLevel(root);
            if(level < 2) {return level;}
            int row = 0;
            TreeNode left = root.left;
            TreeNode right = root.right;
            int h = 1;
            while (left != null && right != null){
                row*=2;
                if(getLevel(right) == level-h) {
                    left = right.left;
                    right = right.right;
                    row++;
                } else {
                    right = left.right;
                    left = left.left;
                }
                h++;
            }
            if(left!=null) {
                row*=2;
                row++;
            } else {
                row++;
            }
            return (1 << (level-1)) -1 + row;

        }


        private int getLevel(TreeNode root){
            int r =0;
            while(root!=null) {root=root.left; r++;}
            return r;
        }
    }
}