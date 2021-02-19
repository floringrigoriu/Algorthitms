# https://leetcode.com/explore/featured/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3628/

# Longest Harmonious Subsequence
# We define a harmonious array as an array where the difference between its maximum value and its minimum value is exactly 1.

# Given an integer array nums, return the length of its longest harmonious subsequence among all its possible subsequences.

# A subsequence of array is a sequence that can be derived from the array by deleting some or no elements without changing the order of the remaining elements.

 

# Example 1:

# Input: nums = [1,3,2,2,5,2,3,7]
# Output: 5
# Explanation: The longest harmonious subsequence is [3,2,2,2,3].
# Example 2:

# Input: nums = [1,2,3,4]
# Output: 2
# Example 3:

# Input: nums = [1,1,1,1]
# Output: 0
 

# Constraints:

# 1 <= nums.length <= 2 * 104
# -109 <= nums[i] <= 109

from collections import Counter 

class Solution:
    def findLHS(self, nums: List[int]) -> int:
        cnt = Counter(nums)
        result = 0
        for v in cnt:
            if cnt[v+1]:
                result =max(result, cnt[v] + cnt[v+1])
        return result
        # if not nums :
        #     return 0
        # result = 0
        # current = 0
        # low =nums[0]
        # hi = nums[0]
        # for n in nums:
        #     low = min(low,n)
        #     hi = max(hi,n)
        #     if hi-low > 1 :
        #         low = hi = n
        #         current =1
        #     else:
        #         current+=1
        #         if hi-low==1:
        #             result = max(result, current)
        # return result

s = Solution()
print(s.findLHS([1,3,2,2,5,2,3,7]))
print(s.findLHS([1,2,3,4]))
print(s.findLHS([1,1,1,1]))