import static org.junit.Assert.*;

import java.util.Arrays;
import java.util.List;

import org.junit.Test;


public class Solution_P22Test {

	@Test
	public void testGenerateParenthesis() {
		Solution_P22 solution = new Solution_P22();
		
		List<String> result = solution.generateParenthesis(3);
		
		List<String> expected = Arrays.asList("((()))", "(()())", "(())()", "()(())", "()()()");
		assertTrue(expected.equals(result));
		
	}

}
