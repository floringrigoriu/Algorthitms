# https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3613/
# Two strings are considered close if you can attain one from the other using the following operations:

# Operation 1: Swap any two existing characters.
# For example, abcde -> aecdb
# Operation 2: Transform every occurrence of one existing character into another existing character, and do the same with the other character.
# For example, aacabb -> bbcbaa (all a's turn into b's, and all b's turn into a's)
# You can use the operations on either string as many times as necessary.

# Given two strings, word1 and word2, return true if word1 and word2 are close, and false otherwise.

from collections import Counter 


class Solution:
    def closeStrings(self, word1: str, word2: str) -> bool:
        if len(word1)!=len(word2):
            return False
        hist1 = self.getHistHist(word1)  
        hist2 = self.getHistHist(word2)
        if Counter(word1).keys() != Counter(word2).keys() :
            return False
        return hist1==hist2

    def getHistHist(self , word:str) -> dict:
        vals = Counter(word)
        return Counter(vals.values())




s = Solution()
print(s.closeStrings("abc", "bca"))
print(s.closeStrings("a", "aa"))
print(s.closeStrings("cabbba", "abbccc"))
print(s.closeStrings("cabbba", "aabbss"))
print(s.closeStrings("uau", "ssx"))
