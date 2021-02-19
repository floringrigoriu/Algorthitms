# https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3631/
# Shortest Distance to a Character
# Given a string s and a character c that occurs in s, return an array of integers answer where answer.length == s.length and answer[i] is the shortest distance from s[i] to the character c in s.

 

# Example 1:

# Input: s = "loveleetcode", c = "e"
# Output: [3,2,1,0,1,0,0,1,2,2,1,0]
# Example 2:

# Input: s = "aaab", c = "b"
# Output: [3,2,1,0]
 

# Constraints:

# 1 <= s.length <= 104
# s[i] and c are lowercase English letters.
# c occurs at least once in s.

class Solution:
    def shortestToChar(self, s: str, c: str) -> List[int]:
        result = []
        if not s :
            return result
        (idx, last) = (0,(-1)*len(s))
        while idx < len(s):
            (next, next_pos) = self.getNext(s,c,idx)
            for i in range(idx,next):
                result.append(min(i-last,next_pos -i ))
            idx = next
            last  = next_pos
        return result

    def getNext(self, s: str, c: str, start : int ) -> [int,int]:
        while start < len(s) :
            if s[start] == c:
                return (start+1,start)
            start+=1
        return (start, 2*len(s))
            
        

s= Solution()
print(s.shortestToChar('loveleetcode','e'))
print(s.shortestToChar('aaab','b'))
print(s.shortestToChar('loveleetcodetry','e'))