package eu.floringrigoriu.algos;

import java.util.Arrays;

public class p7 {
    public static class Solution {
        public int change(int amount, int[] coins) {
            int[] sw = new int[amount+1];
            sw[0] = 1; // 0 coins is unique way;
           for(int c :coins) {
                for(int i=c ;i <= amount ;i ++) {
                    sw[i]+= sw[(i -c)];
                }
            }
            
            return sw[amount];
        }
    }
}