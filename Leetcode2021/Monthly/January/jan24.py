# https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3615/

#  Merge k Sorted Lists

# You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

# Merge all the linked-lists into one sorted linked-list and return it.

 # Definition for singly-linked list.
import queue

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution:
    def mergeKLists(self, lists: List[ListNode]) -> ListNode:
        result = ListNode()
        pq = queue.PriorityQueue()
        current = result
        index =0
        for l in lists:
            if l:
                pq.put((l.val ,index, l))
                index +=1

        while not pq.empty():
            l = pq.get()
            # print('value:' ,l)
            if l[2].next :
                pq.put((l[2].next.val, index , l[2].next))
                index+=1
            # print('value 2:' ,l)
            current.next = ListNode()
            # print('value 3' ,l)
            current = current.next
            # print('value 4:' ,l)
            current.val = l[0]
        return result.next


print("hello")
s = Solution()
print(s.mergeKLists([ListNode()]))