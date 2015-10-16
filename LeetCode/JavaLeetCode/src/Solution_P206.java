// Reverse a singly linked list.
public class Solution_P206 {
	// in place
    public ListNode reverseList(ListNode head) {
    	ListNode  last = null;
    	ListNode current = head;
    	while (current != null) {
    		ListNode next = current.next;
    		current.next = last;
    		last = current;
    		current = next;
    	}
        return last;
    }
}
