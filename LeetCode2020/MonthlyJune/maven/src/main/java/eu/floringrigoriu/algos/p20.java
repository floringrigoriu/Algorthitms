package eu.floringrigoriu.algos;
// https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/541/week-3-june-15th-june-21st/3366/

import java.util.ArrayList;
import java.util.List;

/**
 * The set [1,2,3,...,n] contains a total of n! unique permutations.
 * 
 * By listing and labeling all of the permutations in order, we get the
 * following sequence for n = 3:
 * 
 * "123" "132" "213" "231" "312" "321" Given n and k, return the kth permutation
 * sequence.
 * 
 * Note:
 * 
 * Given n will be between 1 and 9 inclusive. Given k will be between 1 and n!
 * inclusive. Example 1:
 * 
 * Input: n = 3, k = 3 Output: "213"
 */
public class p20 {
    public String getPermutation(int n, int k) {
        k--;
         List<Integer> perm = new ArrayList<Integer>();
            int p = 1;
            for(int i=1; i<= n;i++) {
                perm.add(i);
                p*=i;
            }

            for(int i = n-1; i>=0;i--) 
            {
                //System.out.println(GetString(perm) + " - " + k + " - p: "+ p);
                
                p/= (i+1);
                int t = k / p;
                int temp = perm.get(t);
                for(int j = t; j<i;j++) {
                    perm.set(j, perm.get(j+1));
                }
                perm.set(i, temp);
                k%=p;
                
            }
            return GetString(perm);
            
    }
    
    private String GetString(List<Integer> perm) {
        StringBuilder sb = new StringBuilder();
            for(Integer i: perm)        {
                sb.insert(0,i.toString());
            }
            return sb.toString();
    }
}