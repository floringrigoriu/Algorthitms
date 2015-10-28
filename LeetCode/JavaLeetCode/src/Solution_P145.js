/**
 * 
 * 
 * Given a binary tree, return the postorder traversal of its nodes' values.

For example:
Given binary tree {1,#,2,3},
   1
    \
     2
    /
   3
return [3,2,1].

Note: Recursive solution is trivial, could you do it iteratively?



 * 
 * 
 * Definition for a binary tree node.
 * function TreeNode(val) {
 *     this.val = val;
 *     this.left = this.right = null;
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number[]}
 */
var postorderTraversal = function(root) {
    var to_visit = [];
    var visited = [];
    if (root !== null){
        to_visit.push(root);
        while(to_visit.length > 0) {
            var current = to_visit.pop();
            if(current !==null) {
                visited.push(current.val);
                to_visit.push(current.left);
                to_visit.push(current.right);
               
            }
        }
    }
    visited.reverse();
    return visited;
};