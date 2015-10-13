import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P70Test {

	@Test
	public void testClimbStairs() {
		// arrange
		int n = 4;
		Solution_P70 s = new Solution_P70();
		
		// act
		int result = s.climbStairs(n);
		
		// assert
		assertEquals(5, result);
	}

}
