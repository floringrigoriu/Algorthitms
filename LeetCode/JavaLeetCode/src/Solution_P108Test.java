import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P108Test {

	@Test
	public void test() {
		// setup 
		int[] input = {0 , 1 , 2, 3, 4,5};
		Solution_P108 s = new Solution_P108();
		
		// trigger
		TreeNode result = s.sortedArrayToBST(input);
		
		// validate
		TreeNode expected = new TreeNode(3);
		expected.left = new TreeNode(1);
		expected.left.left = new TreeNode(0);
		expected.left.right = new TreeNode(2);
		expected.right = new TreeNode(5);
		expected.right.left = new TreeNode(4);
		TreeTestUtility.treeAreEqual(expected, result);
		
	}

}
