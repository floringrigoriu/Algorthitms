import static org.hamcrest.CoreMatchers.equalTo;
import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.*;

import org.junit.Test;


public class SolutionP260Test {

	@Test
	public void testSingleNumber() {
		// setup
		SolutionP260 solution = new SolutionP260();
		int nums[] = new int[] {1, 2, 1, 3, 2, 5};
		int expected[] = new int[] {3, 5};
		// trigger
		int[] result = solution.singleNumber(nums);
		//validate
		assertThat(result, is(equalTo(expected)));
	}

}
