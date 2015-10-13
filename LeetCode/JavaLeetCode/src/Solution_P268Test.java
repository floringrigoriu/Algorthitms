import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P268Test {
	Solution_P268 solution = new Solution_P268();
	
	
	@Test
	public void testMissingNumberSmall() {
		
		// setup
		int[] nums = {0,1,3};
		
		// test
		int result = solution.missingNumber(nums);
		
		// validate
		assertEquals(2, result);
	}

	@Test
	public void testMissingNumberLarge() {
		// setup
		int test_size = 1<<16;
		int[] nums = new int[test_size];
		for(int i = 0; i< test_size ; i++) {nums[i] = i;}
		
		// test
		int result = solution.missingNumber(nums);

		// validate
		assertEquals(test_size, result);
		
	}
}
