import static org.junit.Assert.*;
import junit.framework.Assert;

import org.junit.Test;


public class Solution_P53test {

	@Test
	public void testMaxSubArray() {
		// setup
		int[] input = {-2,1,-3,4,-1,2,1,-5,4};
		Solution_P53 s = new Solution_P53();
		// trigger
		int result = s.maxSubArray(input);
		// validate 
		assertEquals(6, result);
		
	}
	
	@Test
	public void testMaxSubArrayNegative() {
		// setup
		int[] input = {-1};
		Solution_P53 s = new Solution_P53();
		// trigger
		int result = s.maxSubArray(input);
		// validate 
		assertEquals(-1, result);
		
	}
	
	@Test
	public void testMaxSubArrayNegative2() {
		// setup
		int[] input = {-1, -2};
		Solution_P53 s = new Solution_P53();
		// trigger
		int result = s.maxSubArray(input);
		// validate 
		assertEquals(-1, result);
		
	}

}
