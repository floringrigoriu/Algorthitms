
# https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/583/week-5-january-29th-january-31st/3620/

# Number Of Corner Rectangles
# Given a grid where each entry is only 0 or 1, find the number of corner rectangles.

# A corner rectangle is 4 distinct 1s on the grid that form an axis-aligned rectangle. 
# Note that only the corners need to have the value 1. Also, all four 1s used must be distinct.

 

# Example 1:

# Input: grid = 
# [[1, 0, 0, 1, 0],
#  [0, 0, 1, 0, 1],
#  [0, 0, 0, 1, 0],
#  [1, 0, 1, 0, 1]]
# Output: 1
# Explanation: There is only one corner rectangle, with corners grid[1][2], grid[1][4], grid[3][2], grid[3][4].
 

# Example 2:

# Input: grid = 
# [[1, 1, 1],
#  [1, 1, 1],
#  [1, 1, 1]]
# Output: 9
# Explanation: There are four 2x2 rectangles, four 2x3 and 3x2 rectangles, and one 3x3 rectangle.
 

# Example 3:

# Input: grid = 
# [[1, 1, 1, 1]]
# Output: 0
# Explanation: Rectangles must have four distinct corners.

class Solution:
    def countCornerRectangles(self, grid: List[List[int]]) -> int:
        if not grid or not grid[0]:
            return 0
        cache = [[0 for i in range (len(grid[0]))] for j in range(len(grid[0]))]
        # print(cache)
        result = 0
        for r in grid:
            ones = [i for i in range(len(r)) if r[i]]
            # print(r, ones, cache, result)
            for i in range(len(ones)-1):
                for j in range(i+1,len(ones)):
                    # if cache[ones[i]][ones[j]]:
                        # print('add:',ones[i],ones[j], cache[ones[i]][ones[j]])
                    result +=cache[ones[i]][ones[j]]
            for i in range(len(ones)-1):
                for j in range(i+1,len(ones)):
                    cache[ones[i]][ones[j]]=cache[ones[i]][ones[j]]+1
                    # print('set' ,i ,j ,ones[i],ones[j], cache, cache[ones[i]][ones[j]])
        return result

s = Solution()
print(s.countCornerRectangles([[1, 0, 0, 1, 0],
    [0, 0, 1, 0, 1],
    [0, 0, 0, 1, 0],
    [1, 0, 1, 0, 1]]))
print(s.countCornerRectangles([[1, 1, 1],
  [1, 1, 1],
  [1, 1, 1]]))
print(s.countCornerRectangles([[1, 1, 1, 1]]))


