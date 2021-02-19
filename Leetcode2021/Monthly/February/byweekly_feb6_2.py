# https://leetcode.com/contest/biweekly-contest-45/problems/maximum-absolute-sum-of-any-subarray/


class Solution:
    def maxAbsoluteSum(self, nums: List[int]) -> int:
        if not nums:
            return 0
        if len(nums) ==1:
            return abs(nums[0])
        mid = len(nums)>>1
        result =0
        sum =0
        max_s =0
        min_s =0
        for i in range(mid-1,-1,-1):
            sum+=nums[i]
            max_s = max(max_s, sum)
            min_s = min(min_s, sum)
        result+=max_s
        
        sum =0
        for i in range(mid,len(nums)):
            sum+=nums[i]
            result = max(result, max(sum+max_s, abs(sum+min_s)))
        result = max(result, max (self.maxAbsoluteSum(nums[0:mid]), self.maxAbsoluteSum(nums[mid:])))
        #print('r', result, nums)
        return result

s = Solution()
print(s.maxAbsoluteSum([1,-3,2,3,-4]))
print(s.maxAbsoluteSum([2,-5,1,-4,3,-2]))
