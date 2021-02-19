# https://leetcode.com/explore/featured/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3630/

# Binary Tree Right Side View
# Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.

# Example:

# Input: [1,2,3,null,5,null,4]
# Output: [1, 3, 4]
# Explanation:

#    1            <---
#  /   \
# 2     3         <---
#  \     \
#   5     4       <---

# Definition for a binary tree node.
import queue

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def rightSideView(self, root: TreeNode) -> List[int]:
        result = []
        current = queue.Queue()
        if root :
            current.put(root)
        while not current.empty():
            level = current.qsize()
            for i in range(level):
                item = current.get()
                if i == level-1:
                    result.append(item.val)
                for c in [item.left, item.right]:
                    if c:
                        current.put(c)
        return result

s = Solution()
inpt = TreeNode(1, TreeNode(-1), TreeNode(3, TreeNode(2)))
print(s.rightSideView(inpt))