//A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
//
//The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
//
//How many possible unique paths are there?
		
public class Solution_P62 {
	 public int uniquePaths(int m, int n) {
		 // actually the result is Combination of m+n -2 taken by n -1
		 int result = 1;
		 int current = m+ n -2 ;
		 if (n > m) {
		     int aux = m ;
		     m = n;
		     n = aux;
		 }
		 for ( int index = 1 ; index < n ;index ++ ) {
			 result *= current ;
			 result /= index;
			 current --;
		 }
		 return result;
	 }
}
