import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P242Test {

	@Test
	public void testIsAnagram() {
		//setup 
		Solution_P242 solution = new Solution_P242();
		String s = "ccac";
		String t = "acac";
		
		// trigger
		boolean result = solution.isAnagram(s, t);
		
		//validate
		assertFalse(result);
	}

}
