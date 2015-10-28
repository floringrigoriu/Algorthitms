/**
 * Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
 */

/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
var mergeTwoLists = function(l1, l2) {
    var result = null;
    if(l1 === null && l2 ===null) {
        return result;
    }
    if(l1 === null) {
         result = l2;
         return result;
    }
    if(l2===null) {
        result = l1;
        return result;
    }
    
    var current = null;
    if(l1.val < l2.val) {
        current = l1 ;
        l1 = l1.next;
    } else {
        current = l2;
        l2 = l2.next;
    }
    
    result = current;
    
    while(l1 !== null && l2!== null) {
        if(l1.val < l2.val) {
            current.next = l1 ;
            l1 = l1.next;
        } else {
            current.next = l2;
            l2 = l2.next;
        }
        current = current.next;
    }
    
    if(l1 !== null){
        current.next = l1 ;
    }
    
    if(l2!==null) {
            current.next = l2;
    }
    return result;
    
    
};