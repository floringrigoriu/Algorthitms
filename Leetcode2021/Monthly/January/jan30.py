#  https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/583/week-5-january-29th-january-31st/3622/
#  Minimize Deviation in Array
# You are given an array nums of n positive integers.

# You can perform two types of operations on any element of the array any number of times:

# If the element is even, divide it by 2.
# For example, if the array is [1,2,3,4], then you can do this operation on the last element, and the array will be [1,2,3,2].
# If the element is odd, multiply it by 2.
# For example, if the array is [1,2,3,4], then you can do this operation on the first element, and the array will be [2,2,3,4].
# The deviation of the array is the maximum difference between any two elements in the array.

# Return the minimum deviation the array can have after performing some number of operations.

 

# Example 1:

# Input: nums = [1,2,3,4]
# Output: 1
# Explanation: You can transform the array to [1,2,3,2], then to [2,2,3,2], then the deviation will be 3 - 2 = 1.
# Example 2:

# Input: nums = [4,1,5,20,3]
# Output: 3
# Explanation: You can transform the array after two operations to [4,2,5,5,3], then the deviation will be 5 - 2 = 3.
# Example 3:

# Input: nums = [2,10,8]
# Output: 3

class Solution:
    def minimumDeviation(self, nums: List[int]) -> int:
        min_odd = 0
        max_even = 0
        for n in nums :
            if n%2 == 0:
                max_even = max(max_even, n)
            else:
                if min_odd =0:
                    min_odd =n
                else:
                    min_odd =min(min_odd, n)

        if max_even == 0:
            max_even = max(nums) # no even  
        
        


S = Solution()
print(s.minimumDeviation([1,2,3,4]))
print(s.minimumDeviation([4,1,5,20,3]))
print(s.minimumDeviation([2,10,8]))