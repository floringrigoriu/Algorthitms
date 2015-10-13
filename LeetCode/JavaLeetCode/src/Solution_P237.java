/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) { val = x; }
 * }
 */
public class Solution_P237 {
    public void deleteNode(ListNode node) {
    	// assuming node.next != null
        node.val = node.next.val;
        node.next = node.next.next;
    }
}