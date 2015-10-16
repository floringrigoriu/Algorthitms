import static org.junit.Assert.*;

import java.util.Arrays;
import java.util.Collection;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

@RunWith(Parameterized.class)
public class Solution_P206Test {

	private ListNode input;
	private ListNode expected;
	
	private static final Solution_P206 solution = new  Solution_P206();
	
	
	public Solution_P206Test(ListNode input, ListNode reverse) {
		expected = reverse;
		this.input = input;
	}
	
	@Parameterized.Parameters
	   public static Collection testInputs() {
		 ListNode head1 = new ListNode(2);
		 head1.Append(1);
		 ListNode head2 = new ListNode(1);
		 head2.Append(2);
	      return Arrays.asList(new Object[][] {
	         { new ListNode(1),new ListNode(1) },
	         { head1, head2 }
	         
	      });
	   }
	
	@Test
	public void testReverseList() {
		ListNode result = solution.reverseList(input);
		Solution_P83Test.VerifyList(this.expected, result);
	}

}
