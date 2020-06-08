package eu.floringrigoriu.algos;

import java.util.Arrays;

/*
https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3352/

Suppose you have a random list of people standing in a queue. Each person is described by a pair of integers (h, k), where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h. Write an algorithm to reconstruct the queue.

Note:
The number of people is less than 1,100.

 
Example

Input:
[[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]

Output:
[[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]

*/
public class p6 {
    class Solution {
        public int[][] reconstructQueue(int[][] people) {
            Arrays.sort(people, (a,b) -> a[0]==b[0]? a[1]-b[1] : a[0]-b[0]);
            int[][] result = new int[people.length][];
            for(int[] p : people) {
                int left = p[1];
                for(int i=0;i<people.length;i++) {
                    if(left==0 && result[i]==null){
                        result[i] = p;
                        break;
                    }
                    if(result[i]==null){
                        left--;
                    }
                }
            }
            return result;
        }
    }
}