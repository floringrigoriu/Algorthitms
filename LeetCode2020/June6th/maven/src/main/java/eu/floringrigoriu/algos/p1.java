package eu.floringrigoriu.algos;

public class p1 {

    class Solution {
        public int[] shuffle(int[] nums, int n) {
            int[] r = new int[nums.length];
            for(int i=0;i<n;i++) {
                r[i*2]= nums[i];
                r[i*2+1]= nums[i+n];
            }
            return r;
        }
    }
}