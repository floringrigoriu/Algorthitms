import static org.hamcrest.CoreMatchers.equalTo;
import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P238Test {

	@Test
	public void testProductExceptSelf() {
		// setup
		Solution_P238 solution = new Solution_P238();
		int nums[] = new int[] {1,2,3,4};
		int expected[] = new int[] { 24,12,8,6};
		// trigger
		int[] result = solution.productExceptSelf(nums);
		//validate
		assertThat(result, is(equalTo(expected)));
	}

}
