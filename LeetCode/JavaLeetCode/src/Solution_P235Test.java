import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P235Test {

	TreeNode input;
	
	public Solution_P235Test() {
		input = new TreeNode(6);
		input.left = new TreeNode(2);
		input.right = new TreeNode(8);
		input.left.left = new TreeNode(0);
		input.left.right = new TreeNode(4);
		input.left.right.left = new TreeNode(3);
		input.left.right.right = new TreeNode(5);
		input.right.left = new TreeNode(7);
		input.right.right = new TreeNode(9);
	}
	
	
	@Test
	public void testLowestCommonAncestor1() {
		// arrange
		Solution_P235 solution = new Solution_P235();
		TreeNode p = new TreeNode(2);
		TreeNode q = new TreeNode(8);
		
		
		// act 
		TreeNode lca = solution.lowestCommonAncestor(input, p, q);
		
		// assess
		assertEquals(lca.val ,6);
	}
	
	@Test
	public void testLowestCommonAncestor2() {
		// arrange
		Solution_P235 solution = new Solution_P235();
		TreeNode p = new TreeNode(4);
		TreeNode q = new TreeNode(2);
		
		
		// act 
		TreeNode lca = solution.lowestCommonAncestor(input, p, q);
		
		// assess
		assertEquals(lca.val ,2);
	}


}
