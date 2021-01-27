# https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3614/
# A matrix diagonal is a diagonal line of cells starting from some cell in either the topmost row or leftmost column and 
# going in the bottom-right direction until reaching the matrix's end.
#  For example, the matrix diagonal starting from mat[2][0], where mat is a 6 x 3 matrix, includes cells mat[2][0], mat[3][1], and mat[4][2].

# Given an m x n matrix mat of integers, sort each matrix diagonal in ascending order and return the resulting matrix.

class Solution:
    def diagonalSort(self, mat: List[List[int]]) -> List[List[int]]:
        if not mat or not mat[0]:
            return mat
        for d in range (1- len(mat), len(mat[0])):
            delta = (-1)* min(d,0)
            y= delta;
            x = d+delta
            diag =  []
            while y<len(mat) and x< len(mat[0]):
                diag.append(mat[y][x])
                y = y+1
                x = x+1
            diag.sort()
            y= delta
            x = d+delta
            while y<len(mat) and x< len(mat[0]):
                mat[y][x]=diag[y-delta]
                y = y+1
                x = x+1

        return mat


s = Solution()
print(s.diagonalSort([[3,3,1,1],[2,2,1,2],[1,1,1,2]]))


