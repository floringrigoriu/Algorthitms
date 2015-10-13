
  public class ListNode {
      int val;
      ListNode next;
      ListNode(int x) { val = x; }
      ListNode Append(int x) {this.next = new ListNode(x); return this.next;}
 }
