package eu.floringrigoriu.algos;
/**
 * 
 * https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3351/
 * 
 * Given an array w of positive integers, where w[i] describes the weight of index i, write a function pickIndex which randomly picks an index in proportion to its weight.

Note:

1 <= w.length <= 10000
1 <= w[i] <= 10^5
pickIndex will be called at most 10000 times.
Example 1:

Input: 
["Solution","pickIndex"]
[[[1]],[]]
Output: [null,0]
Example 2:

Input: 
["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
[[[1,3]],[],[],[],[],[]]
Output: [null,0,1,1,1,0]
 */

import java.util.Random; 

public class p5 {
    
    class Solution {

        int[] sums;

        public Solution(int[] w) {
            sums = new int[w.length];
            sums[0] = w[0];
            for(int i = 1; i < w.length;i++) {
                sums[i] = sums[i-1] + w[i];
            }
        }
        
        public int pickIndex() {
            int r = (new Random()).nextInt(sums[sums.length-1])+1;
            int l =0;
            int h = sums.length-1;
            while(l<h-1){
                int m = (l+h)/2;
                if(sums[m] > r) {
                    h = m;
                } else {
                    l = m;    
                }
            }
            return (sums[l] >r) ? l : l+1;
        }

       
    }
}