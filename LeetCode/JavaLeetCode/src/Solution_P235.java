//Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST.
//
//According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two
// nodes v and w as the lowest node in T that has both v and w as descendants 
// (where we allow a node to be a descendant of itself).”
//
//        _______6______
//       /              \
//    ___2__          ___8__
//   /      \        /      \
//   0      _4       7       9
//         /  \
//         3   5
//For example, the lowest common ancestor (LCA) of nodes 2 and 8 is 6. 
// Another example is LCA of nodes 2 and 4 is 2, since a node can be a descendant 
// of itself according to the LCA definition.

public class Solution_P235 {
	public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null || p == null || q== null) {return null;}
        TreeNode result = root;
        if (p.val > q.val) {
        	TreeNode aux = p;
        	p = q;
        	q = aux;
        }
        
        while ((result.val < p.val || result.val > q.val ) && result != null) {
        	if (result.val < p.val) {
        		result = result.right;
        	}
        	
        	if(result.val > q.val) {
        		result = result.left;
        	}
        	
        }
        
        if(result == null ) {
        	return result ;
        } 
        
        if(!isInTree(result,p.val)) {
        	return null;
        }
        
        if(!isInTree(result,q.val)) {
        	return null;
        }
        
        return result;
    }
	
	boolean isInTree(TreeNode root, int val) {
		while(root != null) {
			if(root.val > val) {
				root = root.left;
			} else if( root.val < val) {
				root = root.right;
			} else {
				return true;
			}
		}
		return false; // no node
	}
}
