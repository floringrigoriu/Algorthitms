package eu.floringrigoriu.algos;

import java.util.Arrays;

/**
 * https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3349/
 * 
 * There are 2N people a company is planning to interview. The cost of flying
 * the i-th person to city A is costs[i][0], and the cost of flying the i-th
 * person to city B is costs[i][1].
 * 
 * Return the minimum cost to fly every person to a city such that exactly N
 * people arrive in each city.
 */

 public class p3 {

    
    public static class Solution {
        public int twoCitySchedCost(final int[][] costs) {
            Arrays.sort(costs, (a,b) -> a[0]- b[0] -a[1] +b[1]);
            int result = 0;
            for(int i=0;i< (costs.length / 2); i++) {
                result+= costs[i][0];
            }
            for(int i= (costs.length / 2); i < costs.length; i++) {
                result+= costs[i][1];
            }
            return result;
        }
    }

    public static void main(final String[] args) {
        System.out.println("Hello World P3");
        final Solution s = new p3.Solution();
        final int a = s.twoCitySchedCost(new int[][] { { 10, 20 }, { 30, 200 }, { 400, 50 }, { 30, 20 } });
        System.out.println(a);
    }
 }