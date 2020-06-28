import java.util.Map;

import java.util.*;

public class p3 {
    class Solution {
        public int minSumOfLengths(int[] arr, int target) {
            Map<Integer, Integer> incretalSum = new HashMap<Integer, Integer>();
            incretalSum.put(0,-1);
            int sum =0;
            List<Integer[]> solutions = new ArrayList<Integer[]>();
            for(int i=0;i<arr.length;i++) {
                sum += arr[i];
                incretalSum.put(sum,i);
                if (arr[i] == target) {
                    solutions.add(new Integer[] {1,i});
                } else if (incretalSum.get(sum -target)!= null) {
                    solutions.add(new Integer[] {i-incretalSum.get(sum -target),i});
                }
            }
            if (solutions.size() <2) {return -1;}
            Stack<Integer[]> mins = new Stack<Integer[]>();
            TreeMap<Integer, Integer[]> others = new TreeMap<Integer,Integer[]>();
            mins.push(solutions.get(0));
            others.put(solutions.get(0)[0], solutions.get(0));
            for(int i=1;i< solutions.size();i++) {
                Integer[] s = solutions.get(i);
                if (s[0]== mins.peek()[0]) {
                    mins.push(s);
                }else if(s[0]< mins.peek()[0]){
                    mins.push(s);
                    others.put(s[1],s);
                } 
            }
            for(Map.Entry<Integer,Integer[]> me: others.entrySet()) {
                System.out.println(me.getKey().toString()+ "->" +Arrays.toString(me.getValue()));
            }
            int result = -1;
            for(int i = solutions.size() -1;i >0 && !mins.isEmpty(); i--) { 
               Integer[] c = solutions.get(i);
               if (mins.peek() == c) {
                   mins.pop();
               }
               if(others.get(c[1]) != null) {
                   others.remove(c[1]);
                }
                Map.Entry<Integer,Integer[]> o_m = others.floorEntry(c[1] - c[0]);
                if (o_m != null) {
                    if ( result == -1 || o_m.getValue()[0] + c[0] < result) {
                        result =o_m.getValue()[0] + c[0] ;
                    }
                }
            }
            return result;
        }
    }
}

// https://leetcode.com/contest/biweekly-contest-28/problems/find-two-non-overlapping-sub-arrays-each-with-target-sum/

// 5423. Find Two Non-overlapping Sub-arrays Each With Target Sum
// User Accepted:717
// User Tried:2389
// Total Accepted:725
// Total Submissions:5551
// Difficulty:Medium
// Given an array of integers arr and an integer target.

// You have to find two non-overlapping sub-arrays of arr each with sum equal target. There can be multiple answers so you have to find an answer where the sum of the lengths of the two sub-arrays is minimum.

// Return the minimum sum of the lengths of the two required sub-arrays, or return -1 if you cannot find such two sub-arrays.

 

// Example 1:

// Input: arr = [3,2,2,4,3], target = 3
// Output: 2
// Explanation: Only two sub-arrays have sum = 3 ([3] and [3]). The sum of their lengths is 2.
// Example 2:

// Input: arr = [7,3,4,7], target = 7
// Output: 2
// Explanation: Although we have three non-overlapping sub-arrays of sum = 7 ([7], [3,4] and [7]), but we will choose the first and third sub-arrays as the sum of their lengths is 2.
// Example 3:

// Input: arr = [4,3,2,6,2,3,4], target = 6
// Output: -1
// Explanation: We have only one sub-array of sum = 6.
// Example 4:

// Input: arr = [5,5,4,4,5], target = 3
// Output: -1
// Explanation: We cannot find a sub-array of sum = 3.
// Example 5:

// Input: arr = [3,1,1,1,5,1,2,1], target = 3
// Output: 3
// Explanation: Note that sub-arrays [1,2] and [2,1] cannot be an answer because they overlap.
 

// Constraints:

// 1 <= arr.length <= 10^5
// 1 <= arr[i] <= 1000
// 1 <= target <= 10^8
