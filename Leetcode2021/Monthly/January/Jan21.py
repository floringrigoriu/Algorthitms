# // https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3611/

# Given an integer array nums and a positive integer k, return the most competitive subsequence of nums of size k.

# An array's subsequence is a resulting sequence obtained by erasing some (possibly zero) elements from the array.

# We define that a subsequence a is more competitive than a subsequence b (of the same length) if in the first position where a and b differ, subsequence a has a number less than the corresponding number in b. For example, [1,3,4] is more competitive than [1,3,5] because the first position they differ is at the final number, and 4 is less than 5.

 

# Example 1:

# Input: nums = [3,5,2,6], k = 2
# Output: [2,6]
# Explanation: Among the set of every possible subsequence: {[3,5], [3,2], [3,6], [5,2], [5,6], [2,6]}, [2,6] is the most competitive.
# Example 2:

# Input: nums = [2,4,3,3,5,4,9,6], k = 4
# Output: [2,3,3,4]
 

# Constraints:

# 1 <= nums.length <= 105
# 0 <= nums[i] <= 109
# 1 <= k <= nums.length


class Solution:
    def mostCompetitive(self, nums: List[int], k: int) -> List[int]:
        mins = list()
        mins.append(nums[0])
        for i in range(1,k):
            mins.append(nums[:i+1])

        print(mins)
        for i in range(k, len(nums)):
            for l in range(k-1,0,-1):
                print('b  ', mins[l-1], mins[l], nums[i])
                
                if l == 1 :
                    other = [mins[l-1], nums[i]]
                else:
                    other = mins[l-1] + nums[i] 
                print(mins[l-1], mins[l], nums[i], other)
                if self.smaller(mins[l], other) >0:
                    mins[l] = other
            mins[0] = min(mins[0],nums[i])
        return mins[k-1]

    def smaller(self , a: List[int], b: List[int]) -> int:
        for i in range(len(a)):
            if a[i]!=b[i]:
                return 1 if a[i]<b[i] else -1
        return 0
        
s = Solution()

print (s.mostCompetitive([3,5,2,6], 2))
print (s.mostCompetitive([2,4,3,3,5,4,9,6], 4))