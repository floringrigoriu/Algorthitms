package main.java.eu.floringrigoriu.algos.biweeklyJune27;
// https://leetcode.com/contest/biweekly-contest-29/problems/longest-subarray-of-1s-after-deleting-one-element/

/**
 * 
 * 5434. Longest Subarray of 1's After Deleting One Element
User Accepted:2662
User Tried:2972
Total Accepted:2712
Total Submissions:4503
Difficulty:Medium
Given a binary array nums, you should delete one element from it.

Return the size of the longest non-empty subarray containing only 1's in the resulting array.

Return 0 if there is no such subarray.

 

Example 1:

Input: nums = [1,1,0,1]
Output: 3
Explanation: After deleting the number in position 2, [1,1,1] contains 3 numbers with value of 1's.
Example 2:

Input: nums = [0,1,1,1,0,1,1,0,1]
Output: 5
Explanation: After deleting the number in position 4, [0,1,1,1,1,1,0,1] longest subarray with value of 1's is [1,1,1,1,1].
Example 3:

Input: nums = [1,1,1]
Output: 2
Explanation: You must delete one element.
Example 4:

Input: nums = [1,1,0,0,1,1,1,0,1]
Output: 4
Example 5:

Input: nums = [0,0,0]
Output: 0
 

Constraints:

1 <= nums.length <= 10^5
nums[i] is either 0 or 1.
 * 
 */

public class p3 {
    class Solution {
        public int longestSubarray(int[] nums) {
            int [] trails = new int[nums.length];
            int p = 0;
            for (int i =nums.length-1;i>=0;i--) {
                trails[i] = p;
                if(nums[i] == 0)  {
                    p =0;
                } else {
                    p++;
                }
            }
            
            // compute result
            p = 0;
            int result = 0;
            for(int i =0;i<nums.length;i++){
                result = Math.max(result, p + trails[i]);
                if(nums[i] == 0)  {
                    p =0;
                } else {
                    p++;
                }
            }
            return result;
        }
    }
}