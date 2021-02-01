# https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/583/week-5-january-29th-january-31st/3623/
# Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

# If such an arrangement is not possible, it must rearrange it as the lowest possible order (i.e., sorted in ascending order).

# The replacement must be in place and use only constant extra memory.

 

# Example 1:

# Input: nums = [1,2,3]
# Output: [1,3,2]
# Example 2:

# Input: nums = [3,2,1]
# Output: [1,2,3]
# Example 3:

# Input: nums = [1,1,5]
# Output: [1,5,1]
# Example 4:

# Input: nums = [1]
# Output: [1]


class Solution:
    def nextPermutation(self, nums: List[int]) -> None:
        """
        Do not return anything, modify nums in-place instead.
        """
        last = len(nums)-2
        while last>=0 and nums[last]>= nums[last+1]:
            
            last-=1
        if last == -1 :
            # no next permutation
            nums.sort()
        else:
            # print('last',last)
            next_val = last+1
            for i in range(last+2, len(nums)):
                if nums[i]> nums[last] and nums[next_val] > nums[i]:
                    next_val = i
            t = nums[next_val]
            nums[next_val] = nums[last]
            nums[last] = t
            other = nums[last+1:]  
            other.sort()
            for i in range(last+1, len(nums)):
                nums[i] = other[i-last-1]
            



s = Solution()
for i in [[3,2,1,0],[3,2,1],[1,2,3], [1], [1,1,5]]:
    s.nextPermutation(i)
    print(i)