import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P83Test {

	@Test
	public void test() {
		ListNode head = new ListNode(1);
		head.Append(1).Append(2).Append(3).Append(3);
		Solution_P83 sol = new Solution_P83();
		
		// act
		ListNode result = sol.deleteDuplicates(head);
		
		//assess
		ListNode expected = new ListNode(1);
		expected.Append(2).Append(3);
		VerifyList(expected, result);
		
	}
	
	public static void VerifyList(ListNode l1, ListNode l2) {
		while (l1 != null && l2 != null) {
			assertEquals(l1.val , l2.val);
			l1 = l1.next;
			l2 = l2.next;
		}
		assertTrue(l1 == null && l2 == null);
	}

}
