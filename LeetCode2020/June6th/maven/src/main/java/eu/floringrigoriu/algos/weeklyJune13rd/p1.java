
//https://leetcode.com/contest/weekly-contest-193/problems/running-sum-of-1d-array/
public class p1 {
    class Solution {
        public int[] runningSum(int[] nums) {
            for(int i=1;i<nums.length;i++){
                nums[i]+=(nums[i-1]);
            }
            return nums;
        }
    }
}