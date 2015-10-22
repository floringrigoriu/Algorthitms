import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;

import java.util.Arrays;
import java.util.Collection;
import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

@RunWith(Parameterized.class)
public class Solution_P89Test {
	
	private int n;
	private List<Integer> expected;

	private static Solution_P89 s = new Solution_P89();
	
	public Solution_P89Test(int n, List<Integer> solution) {
		this.expected=solution;
		this.n = n;
	}
	
	@Parameterized.Parameters
	   public static Collection testInputs() {
		 return Arrays.asList(new Object[][] {
	         { 1, Arrays.asList( 0 ,1) },
	         { 2, Arrays.asList( 0 ,1 , 3, 2) },
	         { 3, Arrays.asList( 0 ,1 , 3, 2 , 6 ,7 , 5 ,4) },
	      });
		}
	
	
	@Test
	public void testGrayCode() {
		assertThat(this.expected, is(s.grayCode(this.n)));
	}

}
