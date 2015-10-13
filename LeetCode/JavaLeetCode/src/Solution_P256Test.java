import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P256Test {

	@Test
	public void testAddDigits() {
		Solution_P256  solver = new Solution_P256();
		int [] testCases = {0 ,1 , 123 , 999, Integer.MAX_VALUE, Integer.MIN_VALUE,-7};
		for(int i:testCases) {
			assertEquals(String.format("test failure for %d", i), solver.addDigistsIter(i),solver.addDigits(i));
		}
	}

}
