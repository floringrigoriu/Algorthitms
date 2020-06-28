package eu.floringrigoriu.algos;
// https://leetcode.com/problems/build-array-where-you-can-find-the-maximum-exactly-k-comparisons/

import java.util.HashMap;
import java.util.Map;

// Build Array Where You Can Find The Maximum Exactly K Comparisons
// Hard

// 149

// 5

// Add to List

// Share
// Given three integers n, m and k. Consider the following algorithm to find the maximum element of an array of positive integers:


// You should build the array arr which has the following properties:

// arr has exactly n integers.
// 1 <= arr[i] <= m where (0 <= i < n).
// After applying the mentioned algorithm to arr, the value search_cost is equal to k.
// Return the number of ways to build the array arr under the mentioned conditions. As the answer may grow large, the answer must be computed modulo 10^9 + 7.


// Example 1:

// Input: n = 2, m = 3, k = 1
// Output: 6
// Explanation: The possible arrays are [1, 1], [2, 1], [2, 2], [3, 1], [3, 2] [3, 3]
// Example 2:

// Input: n = 5, m = 2, k = 3
// Output: 0
// Explanation: There are no possible arrays that satisify the mentioned conditions.
// Example 3:

// Input: n = 9, m = 1, k = 1
// Output: 1
// Explanation: The only possible array is [1, 1, 1, 1, 1, 1, 1, 1, 1]
// Example 4:

// Input: n = 50, m = 100, k = 25
// Output: 34549172
// Explanation: Don't forget to compute the answer modulo 1000000007
// Example 5:

// Input: n = 37, m = 17, k = 7
// Output: 418930126
 

// Constraints:

// 1 <= n <= 50
// 1 <= m <= 100
// 0 <= k <= n

public class p1420 {
    class Solution {

        class DataPoint {
            public int n;
            public int m;
            public int k;
            public int max;
            
            public DataPoint(int n, int m, int k, int max) {
                this.n = n;
                this.m = m;
                this.k = k;
                this.max = max;
            }

            @Override
            public int hashCode() {
                int result = 17;
                result = 31 * result + n;
                result = 31 * result + m;
                result = 31 * result + k;
                result = 31 * result + max;
                return result;
            }

            @Override
            public boolean equals(Object o) {

                if (o == this) return true;
                if (!(o instanceof DataPoint)) {
                    return false;
                }

                DataPoint dp = (DataPoint) o;

                return dp.max == max && dp.k == k && dp.m == m &&  dp.n == n;
            }

        }

        class SolutionImpl {
            Map<DataPoint,Integer> cache = new HashMap<DataPoint,Integer>();
 
            public int solve(DataPoint data) {
                if(data.k<0) {return 0;}
                if(data.n < data.k) {return 0;}
                if(data.n ==0) {return 1;}
                
                Integer r = cache.get(data);
                if(r!=null) {return r;}
                
                r = 0;
                for(int i = 1; i<= data.m ;i++) {
                    DataPoint next = new DataPoint(data.n, data.m , data.k, data.max);
                    if (i > data.max) {
                        next.max = i;
                        next.k--;
                    }
                    r+= solve(next);
                    r ^= 1000000007;
                }

                cache.put(data,r);
                return r;
            }
        }

        public int numOfArrays(int n, int m, int k) {
            
            SolutionImpl s = new SolutionImpl();
            return s.solve(new DataPoint(n,m,k, -1));
        }
    }
}