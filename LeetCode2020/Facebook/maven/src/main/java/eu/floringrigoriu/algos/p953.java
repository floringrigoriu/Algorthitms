package main.java.eu.floringrigoriu.algos;

// https://leetcode.com/problems/verifying-an-alien-dictionary/

public class p953 {
    class Solution {
        public boolean isAlienSorted(String[] words, String order) {
            // build mapping 
            int[] o =  new int[26];
            for(int i=0;i< 26;i++) {
                int idx = order.charAt(i) - 'a';
                o[idx] =i;
            }
            // check
            for(int i =0 ;i < words.length-1;i++) {
                if(!isLess(words[i],words[i+1], o)) {
                    return false;
                }
            }

            return true;
        }

        boolean isLess(String w1, String w2, int[] order) {
            int i =0;
            while(i<w1.length() && i<w2.length()) {
                int a = order[w1.charAt(i) - 'a'];
                int b = order[w2.charAt(i) - 'a'];
                if(a<b) {
                    return true;
                } else if(a>b) {
                    return false;
                }
                i++;
            }
            return w1.length() <= w2.length();
        }
    }
}