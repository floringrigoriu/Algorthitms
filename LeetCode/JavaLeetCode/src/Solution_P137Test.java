import static org.junit.Assert.*;
import junit.framework.Assert;

import org.junit.Test;


public class Solution_P137Test {

	@Test
	public void testSingleNumber() {
		// setup
		int[] input = {3, 4, 5, 3, 5 ,3, 5};
		Solution_P137 solution = new Solution_P137();
		
		// trigger
		int result = solution.singleNumber(input);
		
		// validate
		assertEquals(4, result);
	}

}
