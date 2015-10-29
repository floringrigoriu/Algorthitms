/**
 * Given a linked list, swap every two adjacent nodes and return its head.

For example,
Given 1->2->3->4, you should return the list as 2->1->4->3.

Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.
 */

/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var swapPairs = function(head) {
    if(head === null || head.next ===null) {
        return head;
    }
    // first pair
    var result = head.next ;
    var current = head;
    current.next = result.next;
    result.next  = head;
    
    while(current.next !== null && current.next.next !== null) {
        var next = current.next.next;
        var repl = current.next;
        current.next = next;
        repl.next = next.next;
        next.next = repl;
        current = repl;
    }
    return result;
    
};