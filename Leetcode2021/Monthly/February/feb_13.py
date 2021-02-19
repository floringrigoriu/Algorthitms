# https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/585/week-2-february-8th-february-14th/3638/

# Shortest Path in Binary Matrix
# In an N by N square grid, each cell is either empty (0) or blocked (1).

# A clear path from top-left to bottom-right has length k if and only if it is composed of cells C_1, C_2, ..., C_k such that:

# Adjacent cells C_i and C_{i+1} are connected 8-directionally (ie., they are different and share an edge or corner)
# C_1 is at location (0, 0) (ie. has value grid[0][0])
# C_k is at location (N-1, N-1) (ie. has value grid[N-1][N-1])
# If C_i is located at (r, c), then grid[r][c] is empty (ie. grid[r][c] == 0).
# Return the length of the shortest such clear path from top-left to bottom-right.  If such a path does not exist, return -1.

 

# Example 1:

# Input: [[0,1],[1,0]]


# Output: 2

# Example 2:

# Input: [[0,0,0],[1,1,0],[1,1,0]]


# Output: 4

 

# Note:

# 1 <= grid.length == grid[0].length <= 100
# grid[r][c] is 0 or 1

import queue

class Solution:
    def shortestPathBinaryMatrix(self, grid: List[List[int]]) -> int:
        visited = set()
        target = len(grid)-1
        path_size = 0
        level_size = 0
        q = queue.Queue()
        if not grid[0][0]:
            q.put((0,0))
        while not q.empty() and (target,target) not in visited:
            if not level_size:
                level_size = q.qsize()
                path_size+=1
            current = q.get()
            level_size-=1
            if current in visited :
                continue
            visited.add(current)
            for (dx,dy) in [(-1,-1),(-1,0),(-1,1),(0,1),(1,1),(1,0),(1,-1),(0,-1)]:
                x= dx+current[0]
                y = dy+current[1]
               # print(">>", current, (x,y),(dx,dy),grid, q)

                if 0<= x <= target and  0<=y<=target and (not grid[x][y]) and ((x,y) not in visited):
                    #print(">", current, (x,y),(dx,dy),grid, q)
                    q.put((x,y))
        #print(visited)
        return -1 if (target,target) not in visited else path_size


s = Solution()
print(s.shortestPathBinaryMatrix([[0,0,0],[1,1,0],[1,1,0]]))
print(s.shortestPathBinaryMatrix([[1,0,0],[1,1,0],[1,1,0]]))
print(s.shortestPathBinaryMatrix([[0,0,0],[1,1,0],[1,1,1]]))
print(s.shortestPathBinaryMatrix([[0,1],[1,0]]))