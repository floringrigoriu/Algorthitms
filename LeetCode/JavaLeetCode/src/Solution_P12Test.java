import static org.junit.Assert.*;

import java.util.Arrays;
import java.util.Collection;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

@RunWith(Parameterized.class)
public class Solution_P12Test {

	private int input;
	private String expected;
	
	private static final Solution_P12 solution = new  Solution_P12();
	
	
	public Solution_P12Test(String roman, int val) {
		expected = roman;
		input = val;
	}
	
	@Parameterized.Parameters
	   public static Collection testInputs() {
	      return Arrays.asList(new Object[][] {
	         { "MCMXC", 1990 },
	         { "I", 1 },
	         { "III", 3 },
	         { "IV", 4 },
	         { "IX", 9 },
	         { "MMMCMXLVII", 3947 },
	      });
	   }
	
	
	@Test
	public void test() {
		assertEquals(this.expected,solution.intToRoman(input));
	}

}
