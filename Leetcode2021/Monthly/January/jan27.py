# https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3618/

#  Concatenation of Consecutive Binary Numbers
# Given an integer n, return the decimal value of the binary string formed by concatenating the binary representations of 1 to n in order, modulo 109 + 7.

 

# Example 1:

# Input: n = 1
# Output: 1
# Explanation: "1" in binary corresponds to the decimal value 1. 
# Example 2:

# Input: n = 3
# Output: 27
# Explanation: In binary, 1, 2, and 3 corresponds to "1", "10", and "11".
# After concatenating them, we have "11011", which corresponds to the decimal value 27.

class Solution:
    def concatenatedBinary(self, n: int) -> int:
        modulo = 1000000007
        result = 0
        offset =0
        for i in range(1,n+1):
            while (1<< offset) <= i :
                offset+=1
            result = result<<offset
            result+= i
            result %= modulo
        return result

s = Solution()
for n in [1,3,12,32]:
    print(n, s.concatenatedBinary(n))