import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.*;

import java.util.Arrays;
import java.util.Collection;
import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

@RunWith(Parameterized.class)
public class Solution_P121Test {
	
		private int expected;
		private int[] input;

		private static Solution_P121 s = new Solution_P121();
		
		public Solution_P121Test(int expected, int[] input) {
			this.input= input;
			this.expected= expected;
		}
		
		@Parameterized.Parameters
		   public static Collection testInputs() {
			 return Arrays.asList(new Object[][] {
		         { 0, new int[]{} },
		         { 0, new int[]{2, 1} },
		         { 1, new int[]{1, 2, 1}},
		         { 10, new int[]{11, 20, 7, 17}},
		         
		      });
			}
		
		
		@Test
		public void testBestTimeToBuy() {
			assertThat(this.expected, is(s.maxProfit(this.input)));
		}

	}