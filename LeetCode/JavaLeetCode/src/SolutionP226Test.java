import static org.junit.Assert.*;

import org.junit.Test;


public class SolutionP226Test {

	@Test
	public void test() {
		// arrange
		Solution_P226 solution = new Solution_P226();
		TreeNode input = new TreeNode(1);
		input.left = new TreeNode(2);
		input.right = new TreeNode(3);
		input.right.left = new TreeNode(4);
		
		// act 
		TreeNode inverted = solution.invertTree(input);
		
		// assess
		TreeNode expected = new TreeNode(1);
		expected.left = new TreeNode(3);
		expected.right = new TreeNode(2);
		expected.left.right = new TreeNode(4);
		
		TreeTestUtility.treeAreEqual(inverted, expected);
	}
	
	

}
