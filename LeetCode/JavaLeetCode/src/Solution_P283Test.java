import static org.junit.Assert.*;
import static org.junit.matchers.JUnitMatchers.*;
import static org.hamcrest.CoreMatchers.*;

import org.junit.Test;


public class Solution_P283Test {

	Solution_P283 tester = new Solution_P283();
	
	@Test
	public void testMoveZeroes1() {
		int[] input =  {0, 1, 0, 3, 12};
		tester.moveZeroes(input);
		int[] expected = {1,3,12, 0, 0};
		assertThat(input, is(equalTo(expected)));
	}
	
	
	@Test
	public void testMoveZeroes2() {
		int[] input =  {4,3,2,1, 0, 1, 0, 3, 12};
		tester.moveZeroes(input);
		int[] expected = {4,3,2,1,1,3,12, 0, 0};
		assertThat(input, is(equalTo(expected)));
	}

}
