import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P169Test {

	@Test
	public void test() {
		Solution_169 s = new Solution_169();
		int[] nums = {1, 3, 2, 4 , 3, 3, 3};
		
		int result = s.majorityElement(nums);
		
		assertEquals(3, result);
		
	}
	
	@Test
	public void test_2() {
		Solution_169 s = new Solution_169();
		int[] nums = {6,6,6,7,7};
		
		int result = s.majorityElement(nums);
		
		assertEquals(6, result);
		
		
	}

}
