package eu.floringrigoriu.algos;

// https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3355/

// Is Subsequence
// Given a string s and a string t, check if s is subsequence of t.

// A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ace" is a subsequence of "abcde" while "aec" is not).

// Follow up:
// If there are lots of incoming S, say S1, S2, ... , Sk where k >= 1B, and you want to check one by one to see if T has its subsequence. In this scenario, how would you change your code?

// Credits:
// Special thanks to @pbrother for adding this problem and creating all test cases.

 

// Example 1:

// Input: s = "abc", t = "ahbgdc"
// Output: true
// Example 2:

// Input: s = "axc", t = "ahbgdc"
// Output: false
 

// Constraints:

// 0 <= s.length <= 100
// 0 <= t.length <= 10^4
// Both strings consists only of lowercase characters.

public class p9 {
    public class Solution {
        public boolean IsSubsequence(String s, String t) {
            int i_s =0;
            if(s.length() == 0) {return true;}

            for(char c: t.toCharArray()) {
                if (c == s.charAt(i_s)) {
                    i_s++;
                }
                if(i_s == s.length()) {return true;}
            }
            
            return false;
        }
    }
}