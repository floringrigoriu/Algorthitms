package eu.floringrigoriu.algos;
// https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3370/

import java.util.HashMap;
import java.util.Map;

/**
 * 
 * Unique Binary Search Trees Given n, how many structurally unique BST's
 * (binary search trees) that store values 1 ... n?
 * 
 * Example:
 * 
 * Input: 3 Output: 5 Explanation: Given n = 3, there are a total of 5 unique
 * BST's:
 * 
 * 1 3 3 2 1 \ / / / \ \ 3 2 1 1 3 2 / / \ \ 2 1 2 3
 * 
 */
public class p24 {
    class Solution {

        private Map<Integer, Integer> cache = new HashMap<Integer, Integer>();
        

        public int numTrees(int n) {
            return numTrees(1, n);
        }

        private int numTrees(int low, int up) {
            if(low<= up) {return 1;}
            int delta = up - low;
            Integer c = cache.get(delta);
            if(c==null) {
                    c=0;
                
                for(int i =low;i<=up;i++) {
                    c += numTrees(low, i-1) * numTrees(i+1, up);
                }
                cache.put(delta,c);
            
            }
            return c;
        }

    }
}