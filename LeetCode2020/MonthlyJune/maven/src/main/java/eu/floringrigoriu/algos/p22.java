
// https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3368/

public class p22 {

    
    class Solution {
        public int SingleNumber(int[] nums) {
            int[] bits = new int[32];
            for(int i: nums) {
                for(int m = 0;m<32;m++) {
                    if((i& (1<<m)) != 0) {
                        bits[m]++;
                        bits[m]%=3;
                    }
                }
            }
            int result = 0;
            for(int m = 0;m<32;m++) {
                if(bits[m]== 1) {
                    result |= (1<<m);
                }
            }
            return result;
        }
    }
}