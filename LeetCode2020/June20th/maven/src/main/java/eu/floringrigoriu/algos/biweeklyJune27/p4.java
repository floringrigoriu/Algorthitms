package main.java.eu.floringrigoriu.algos.biweeklyJune27;

// https://leetcode.com/contest/biweekly-contest-29/problems/parallel-courses-ii/

/**
 * 5435. Parallel Courses II
User Accepted:302
User Tried:1040
Total Accepted:322
Total Submissions:1822
Difficulty:Hard
Given the integer n representing the number of courses at some university labeled from 1 to n, and the array dependencies where dependencies[i] = [xi, yi]  represents a prerequisite relationship, that is, the course xi must be taken before the course yi.  Also, you are given the integer k.

In one semester you can take at most k courses as long as you have taken all the prerequisites for the courses you are taking.

Return the minimum number of semesters to take all courses. It is guaranteed that you can take all courses in some way.

 

Example 1:



Input: n = 4, dependencies = [[2,1],[3,1],[1,4]], k = 2
Output: 3 
Explanation: The figure above represents the given graph. In this case we can take courses 2 and 3 in the first semester, then take course 1 in the second semester and finally take course 4 in the third semester.
Example 2:



Input: n = 5, dependencies = [[2,1],[3,1],[4,1],[1,5]], k = 2
Output: 4 
Explanation: The figure above represents the given graph. In this case one optimal way to take all courses is: take courses 2 and 3 in the first semester and take course 4 in the second semester, then take course 1 in the third semester and finally take course 5 in the fourth semester.
Example 3:

Input: n = 11, dependencies = [], k = 2
Output: 6
 

Constraints:

1 <= n <= 15
1 <= k <= n
0 <= dependencies.length <= n * (n-1) / 2
dependencies[i].length == 2
1 <= xi, yi <= n
xi != yi
All prerequisite relationships are distinct, that is, dependencies[i] != dependencies[j].
The given graph is a directed acyclic graph.
 * 
 */

 import java.util.*;

public class p4 {
    class Solution {
        public int minNumberOfSemesters(int n, int[][] dependencies, int k) {
            Map<Integer, List<Integer>> dep = getDeps(n, dependencies);
            Map<Integer,Integer> time = new HashMap<Integer, Integer>();
            for(int i = 1; i <= n; i++) {
                buildDepth(i, time, dep);
            }
            int max = 1;
            for(Integer m : time.values()) {
                max = Math.max(max,m);
            }

            if (max*k > n) {
                return max;
            } else {
                return n /k + (n%k >0 ? 1: 0);
            }

        }

        public Map<Integer, List<Integer>> getDeps(int n, int[][]dependencies) {

            Map<Integer, List<Integer>> r = new HashMap<Integer, List<Integer>>();
            for(int i = 1; i <= n; i++) {
                r.put(i, new ArrayList<Integer>());
            }
            for(int[] d : dependencies) {
                r.get(d[1]).add(d[0]);
            }
            return r;
        }

        int buildDepth(int i, Map<Integer,Integer> time, Map<Integer, List<Integer>> dep)
        {
            if(time.get(i)!=null) {
                return time.get(i);
            };
            if(dep.get(i).size()==0) {
                time.put(i,1);
                return time.get(i);
            }
            else {
                int maxDep = 0;
                for(int d : dep.get(i)) {
                    maxDep = Math.max(maxDep,buildDepth(d,time, dep));
                }
                time.put(i,maxDep +1);
                return time.get(i);
            }
        }
    }
}