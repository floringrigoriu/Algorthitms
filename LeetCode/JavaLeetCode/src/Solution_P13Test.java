import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P13Test {

	Solution_P13 s = new Solution_P13();
	
	@Test
	public void test_1() throws Exception {
		assertEquals(1, s.RomanToInteger("I"));
	}
	
	@Test
	public void test_1945() throws Exception {
		assertEquals(1945, s.RomanToInteger("MCMVL"));
	}
	
	@Test
	public void test_3988() throws Exception {
		assertEquals(3888, s.RomanToInteger("MMMDCCCLXXXVIII"));
	}

}
