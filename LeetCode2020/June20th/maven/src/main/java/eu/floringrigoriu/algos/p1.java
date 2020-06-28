package eu.floringrigoriu.algos;

// https://leetcode.com/contest/weekly-contest-194/problems/xor-operation-in-an-array/
/**
 * 
 * 5440. XOR Operation in an Array
User Accepted:4963
User Tried:5035
Total Accepted:5004
Total Submissions:5295
Difficulty:Easy
Given an integer n and an integer start.

Define an array nums where nums[i] = start + 2*i (0-indexed) and n == nums.length.

Return the bitwise XOR of all elements of nums.

 */
public class p1 {

    class Solution {
        public int xorOperation(int n, int start) {
            int r =0;
            for(int i=1;i<n;i++)
            {
                r = r ^ i;
            }
            r= r<<1;
            if(n%2 == 1) {
                r^=start;
            }
            return r;
        }
    }
}