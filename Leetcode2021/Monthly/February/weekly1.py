# https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3624/
# There's a tree, a squirrel, and several nuts. Positions are represented by the cells in a 2D grid. Your goal is to find the minimal distance for the squirrel to collect all the nuts and put them under the tree one by one. The squirrel can only take at most one nut at one time and can move in four directions - up, down, left and right, to the adjacent cell. The distance is represented by the number of moves.
# Example 1:

# Input: 
# Height : 5
# Width : 7
# Tree position : [2,2]
# Squirrel : [4,4]
# Nuts : [[3,0], [2,5]]
# Output: 12

class Solution:
    def minDistance(self, height: int, width: int, tree: List[int], squirrel: List[int], nuts: List[List[int]]) -> int:
        result = 0
        if not nuts:
            return result
        saves = (-1)*(height+width)
        for n in nuts:
            s = self.manhatanDistance(n,squirrel)
            t = self.manhatanDistance(tree,n)
            result+=2*t
            saves = max(saves, t-s)
        return result -saves

    def manhatanDistance(self ,source: List[int], dest :  List[int]) -> int:
        return sum([abs(source[i]-dest[i]) for i in range(len(source))])


s = Solution()
print(s.minDistance(5,7,[2,2],[4,4],[[3,0], [2,5]]))