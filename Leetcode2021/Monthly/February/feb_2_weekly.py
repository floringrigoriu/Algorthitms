# // https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/585/week-2-february-8th-february-14th/3632/

# Number of Distinct Islands
# Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

# Count the number of distinct islands. An island is considered to be the same as another if and only if one island can be translated (and not rotated or reflected) to equal the other.

# Example 1:
# 11000
# 11000
# 00011
# 00011
# Given the above grid map, return 1.
# Example 2:
# 11011
# 10000
# 00001
# 11011
# Given the above grid map, return 3.

# Notice that:
# 11
# 1
# and
#  1
# 11
# are considered different island shapes, because we do not consider reflection / rotation.
# Note: The length of each dimension in the given grid does not exceed 50.

import queue

class Solution:
    def numDistinctIslands(self, grid: List[List[int]]) -> int:
        if not grid or not grid[0] :
            return 0
        islands = set()
        for i in range(len(grid)):
            for j in range(len(grid[0])):
                if grid[i][j] == 1 :
                    islands.add(self.exploreIsland(grid, i, j))
        #print( 'explored', grid)
        return len(islands)

    def exploreIsland(self, grid :List[List[int]] , i: int , j:int) -> int:
        result = 0
        q = queue.Queue()
        q.put((i,j))
        while not q.empty():
            c = q.get()
            
            if not (0<=c[0]<len(grid)) or not ( 0<= c[1]<len(grid[0])) or grid[c[0]][c[1]] == 2:
                result <<=1
                continue
            #print('point',c, grid[c[0]][c[1]] , result)
            result= result<<1
            result+= grid[c[0]][c[1]]
            if grid[c[0]][c[1]] :
                grid[c[0]][c[1]] = 2
                for delta in [[1,0],[0,1],[-1,0],[0,-1]]:
                    q.put((c[0]+delta[0],c[1]+delta[1]))
        #print(i,j, result)
        return result


s = Solution()
print(s.numDistinctIslands(
[[1,1,0,0,0],
 [1,1,0,0,0],
 [0,0,0,1,1],
 [0,0,0,1,1]]
))
print(s.numDistinctIslands(
[[1,1,0,1,1],
 [1,0,0,0,0],
 [0,0,0,0,1],
 [1,1,0,1,1]]
))