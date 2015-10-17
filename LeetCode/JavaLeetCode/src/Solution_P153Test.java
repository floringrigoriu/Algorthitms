import static org.junit.Assert.*;

import java.util.Arrays;
import java.util.Collection;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

@RunWith(Parameterized.class)
public class Solution_P153Test {

	private int[] input;
	private int expected;
	
	private static final Solution_P153 solution = new  Solution_P153();
	
	
	public Solution_P153Test(int[] input, int min) {
		expected = min;
		this.input = input;
	}
	
	@Parameterized.Parameters
	   public static Collection testInputs() {
		  return Arrays.asList(new Object[][] {
	         { new int[]{}, Integer.MAX_VALUE },
	         { new int[]{1}, 1 },
	         { new int[]{1 ,2}, 1 },
	         { new int[]{1 , 2 , 3}, 1 },
	         { new int[]{4, 5 ,6 ,7, 1, 2}, 1 },
	         
	      });
	   }
	
	@Test
	public void testReverseList() {
		int result = solution.findMin(input);
		assertEquals(this.expected, result);
	}

}
