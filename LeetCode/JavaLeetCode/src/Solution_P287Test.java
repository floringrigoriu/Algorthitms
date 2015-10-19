import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P287Test {

	@Test
	public void testFindDuplicate() {
		// setup
		Solution_P287 solution = new Solution_P287();
		int[] input = new int[] {1 , 3, 4, 5, 9, 5, 8, 7 };
		
		// trigger 
		int duplicate = solution.findDuplicate(input);
		
		// validate
		assertEquals(5, duplicate);
	}

}
