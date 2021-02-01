# https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3612/


# Given two strings s and t, return true if they are both one edit distance apart, otherwise return false.

# A string s is said to be one distance apart from a string t if you can:

# Insert exactly one character into s to get t.
# Delete exactly one character from s to get t.
# Replace exactly one character of s with a different character to get t.
 

# Example 1:

# Input: s = "ab", t = "acb"
# Output: true
# Explanation: We can insert 'c' into s to get t.
# Example 2:

# Input: s = "", t = ""
# Output: false
# Explanation: We cannot get t from s by only one step.
# Example 3:

# Input: s = "a", t = ""
# Output: true
# Example 4:

# Input: s = "", t = "A"
# Output: true

class Solution:
    def isOneEditDistance(self, s: str, t: str) -> bool:
        e_1 = len(s)-1
        e_2= len(t)-1
        if abs(e_1-e_2) >1:
            return False
        while e_1>=0 and e_2 >=0 and s[e_1]==t[e_2]:
            e_1-=1
            e_2-=1
        if e_1==-1 and e_2 ==-1:
            return False # the same
        s_1=0
        s_2=0
        while s_1<=e_1 and s_2 <=e_2 and s[s_1]==t[s_2]:
            s_1+=1
            s_2+=1
        return s_1 - e_1 >-1 and s_2 - e_2> -1

s = Solution()
print(s.isOneEditDistance("ab", "acb"))
print(s.isOneEditDistance("", ""))
print(s.isOneEditDistance("a",""))
print(s.isOneEditDistance("ab", "acb"))
