# You are a hiker preparing for an upcoming hike. You are given heights, a 2D array of 
# size rows x columns, where heights[row][col] represents the height of cell (row, col). 
# You are situated in the top-left cell, (0, 0), and you hope to travel to the bottom-right cell,
#  (rows-1, columns-1) (i.e., 0-indexed). 
#  You can move up, down, left, or right, and you wish to find a route that requires the minimum effort.

# A route's effort is the maximum absolute difference in heights between two consecutive cells of the route.

# Return the minimum effort required to travel from the top-left cell to the bottom-right cell.
import queue

class Solution:
    def minimumEffortPath(self, heights: List[List[int]]) -> int:
        target = (len(heights)-1, len(heights[0])-1)
        index =0
        pq = queue.PriorityQueue()
        pq.put((0, index, (0,0)))
        visited = set()
        print (target, len(heights), len(heights[0]))

        while not pq.empty():
            c = pq.get()
            if c[2] in visited:
                continue
            print (">" , c)
            if c[2] == target: 
                return c[0]
            visited.add(c[2])
            for n in self.connected(heights,c[2]):
                if n not in visited:
                    index+=1
                    pq.put((max(c[0],abs(heights[c[2][0]][c[2][1]] - heights[n[0]][n[1]])), index, n))


        return -1
    
    def connected(self, heights: List[List[int]], p : tuple[int,int]) -> List[int] :
        result = []
        for delta in [[-1,0],[1,0],[0,-1],[0,1]]:
            new_y = delta[0]+p[0]
            new_x = delta[1]+p[1]
            if new_y>= 0 and new_x >= 0 and new_y < len(heights) and new_x<len(heights[0]):
                result.append((new_y, new_x))
        print("r :", result)
        return result


s = Solution()
#print(s.minimumEffortPath([[1,2,2],[3,8,2],[5,3,5]]))
print(s.minimumEffortPath([[1,10,6,7,9,10,4,9]]))