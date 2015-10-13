//Remove Duplicates from Sorted List
//
//Given a sorted linked list, delete all duplicates such that each element appear only once.
//
//For example,
//Given 1->1->2, return 1->2.
//Given 1->1->2->3->3, return 1->2->3.
		
public class Solution_P83 {

	public ListNode deleteDuplicates(ListNode head) {
        ListNode cursor  = head;
        
        while(cursor != null) {
        	// remove duplicates
        	while(cursor.next != null && cursor.val == cursor.next.val)
        	{
        		cursor.next = cursor.next.next;
        	}
        	
        	// end of list or end of duplicates
        	cursor  = cursor.next;
        }
        return head;
    }
}
