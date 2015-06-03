/*

Given a linked list, determine if it has a cycle in it.

Follow up:
Can you solve it without using extra space?

*/

// start P 2:10 PM
#include "stdafx.h"
#include "list.h"

class CLASS_DECLSPEC Solution_P141 {
public:
	bool hasCycle(ListNode *head) {
		// use only 2 pointers, no extra mem
		ListNode* fast = head;
		ListNode* slow = head;

		bool result = false;
		while (fast != NULL) {
			fast = fast->next;
			if (fast == NULL){
				break;
			}
			fast = fast->next;
			slow = slow->next;
			if (fast == slow) {
				// no need to check identity  after the first advance of fast node : that would have e caught 
				// @ previous iteration when fast == slow
				result = true;
				break;
			}
		}
		return result;
	}
};

// end : 2:23 PM