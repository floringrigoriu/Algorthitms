package eu.floringrigoriu.algos;
import java.util.*;

/*
https://leetcode.com/contest/weekly-contest-192/problems/paint-house-iii/

5431. Paint House III
User Accepted:0
User Tried:2
Total Accepted:0
Total Submissions:2
Difficulty:Hard
There is a row of m houses in a small city, each house must be painted with one of the n colors (labeled from 1 to n), some houses that has been painted last summer should not be painted again.

A neighborhood is a maximal group of continuous houses that are painted with the same color. (For example: houses = [1,2,2,3,3,2,1,1] contains 5 neighborhoods  [{1}, {2,2}, {3,3}, {2}, {1,1}]).

Given an array houses, an m * n matrix cost and an integer target where:

houses[i]: is the color of the house i, 0 if the house is not painted yet.
cost[i][j]: is the cost of paint the house i with the color j+1.
Return the minimum cost of painting all the remaining houses in such a way that there are exactly target neighborhoods, if not possible return -1.

 

Example 1:

Input: houses = [0,0,0,0,0], cost = [[1,10],[10,1],[10,1],[1,10],[5,1]], m = 5, n = 2, target = 3
Output: 9
Explanation: Paint houses of this way [1,2,2,1,1]
This array contains target = 3 neighborhoods, [{1}, {2,2}, {1,1}].
Cost of paint all houses (1 + 1 + 1 + 1 + 5) = 9.
Example 2:

Input: houses = [0,2,1,2,0], cost = [[1,10],[10,1],[10,1],[1,10],[5,1]], m = 5, n = 2, target = 3
Output: 11
Explanation: Some houses are already painted, Paint the houses of this way [2,2,1,2,2]
This array contains target = 3 neighborhoods, [{2,2}, {1}, {2,2}]. 
Cost of paint the first and last house (10 + 1) = 11.
Example 3:

Input: houses = [0,0,0,0,0], cost = [[1,10],[10,1],[1,10],[10,1],[1,10]], m = 5, n = 2, target = 5
Output: 5
Example 4:

Input: houses = [3,1,2,3], cost = [[1,1,1],[1,1,1],[1,1,1],[1,1,1]], m = 4, n = 3, target = 3
Output: -1
Explanation: Houses are already painted with a total of 4 neighborhoods [{3},{1},{2},{3}] different of target = 3.
 
*/

public class p4 {
    class Solution {
        public int minCost(int[] houses, int[][] cost, int m, int n, int target) {
            Map<Integer,Map<Integer,Integer>> prev = new HashMap<Integer, Map<Integer,Integer>>();
            if(houses[0]==0) {
                for(int i =0 ;i <cost[0].length;i++) {
                    addMax(prev,i+1,1,cost[0][i]);
                }
            }else {
                addMax(prev,houses[0],1,0);
            }

            for(int r =1; r< houses.length;r++) {
                Map<Integer,Map<Integer,Integer>> next = new HashMap<Integer, Map<Integer,Integer>>();
                if(houses[r]==0) {
                    for(int i =0 ;i <cost[r].length;i++) {
                        int color = i+1;
                        for(Map.Entry<Integer,Map<Integer,Integer>> count_to_last : prev.entrySet()) {
                            for(Map.Entry<Integer,Integer> last_to_cost : count_to_last.getValue().entrySet()) {
                                int newCount = (last_to_cost.getKey() == color) ? count_to_last.getKey(): count_to_last.getKey() +1;
                                if(newCount <= target) {
                                    addMax(next, color,newCount, last_to_cost.getValue() + cost[r][i]);
                                }
                            }
                        }
                    }
                } else {

                    for(Map.Entry<Integer,Map<Integer,Integer>> count_to_last : prev.entrySet()) {
                        for(Map.Entry<Integer,Integer> last_to_cost : count_to_last.getValue().entrySet()) {
                            int newCount = (last_to_cost.getKey() == houses[r]) ? count_to_last.getKey(): count_to_last.getKey() +1;
                            if(newCount <= target) {
                                addMax(next, houses[r],newCount, last_to_cost.getValue());
                            }
                        }
                    }

                }
                prev = next;
            }
            if(prev.get(target) == null) {
                return -1;
            }else {
                int result = Integer.MAX_VALUE;
                for(int i :prev.get(target).values()) {
                    result = Math.min(result, i);
                }
                return result;
            }
        }

        private void addMax(Map<Integer,Map<Integer,Integer>> m ,int last, int count , int cost) {
            Map<Integer,Integer>  r = m.get(count);
            if(r == null) {
                r = new HashMap<Integer,Integer>(); 
                r.put(last,cost);
                m.put(count,r);
                return;
            }
            if(r.get(last)== null) {
                r.put(last,cost);
            }else {
                r.put(last,Math.min(last, r.get(last)));
            }
        }
    }
}