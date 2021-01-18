# https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3608/
# You are given an integer array nums and an integer k.

# In one operation, you can pick two numbers from the array whose sum equals k and remove them from the array.

# Return the maximum number of operations you can perform on the array.

 

# Example 1:

# Input: nums = [1,2,3,4], k = 5
# Output: 2
# Explanation: Starting with nums = [1,2,3,4]:
# - Remove numbers 1 and 4, then nums = [2,3]
# - Remove numbers 2 and 3, then nums = []
# There are no more pairs that sum up to 5, hence a total of 2 operations.
from collections import Counter 




class Solution:
    def maxOperations(self, nums: List[int], k: int) -> int:
        c = Counter(nums)
        result = sum( min( c[item] , c[k-item]) for item in c )
        return result>>1  
s = Solution()

print (s.maxOperations([1,2,3,4], 5))
print (s.maxOperations([1,2,3,4], 4))
print (s.maxOperations([1,2,3,4,2,0], 4))