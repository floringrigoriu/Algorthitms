package eu.floringrigoriu.algos;

/**
 * 
 * Write a function to delete a node (except the tail) in a singly linked list,
 * given only access to that node. Given linked list -- head = [4,5,1,9], which
 * looks like following:
 */

public class p2 {
    class Solution {
        public void deleteNode(ListNode node) {
            if(node == null || node.next == null){
                throw new RuntimeException("invalid input");
            }
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}