package eu.floringrigoriu.algos;
// https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3371/
/**
 * 
 * Find the Duplicate Number
Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.

Example 1:

Input: [1,3,4,2,2]
Output: 2
Example 2:

Input: [3,1,3,4,2]
Output: 3
Note:

You must not modify the array (assume the array is read only).
You must use only constant, O(1) extra space.
Your runtime complexity should be less than O(n2).
There is only one duplicate number in the array, but it could be repeated more than once.

 */
public class p25 {
    class Solution {
        public int findDuplicate(int[] nums) {
            int low = 1;
            int hi = nums.length - 1;
            while (low < hi) {
                int mid = (low + hi) /2;
                int c = 0;
                for (int n : nums) {
                    if(n>= low && n <= mid) {c++;}
                }
                if (c == mid - low +1) {
                    low = mid +1;
                } else {
                    hi = mid;
                }
            }
            return low;
        }
    }
}