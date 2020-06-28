package eu.floringrigoriu.algos;

import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

/**
 * 
 * https://leetcode.com/problems/count-number-of-teams/
 * 
 */
public class p1395 {
    class Solution {
        public int numTeams(int[] rating) {
            int result =  numTeamsInt(rating);
            reverse(rating);

            return result+numTeamsInt(rating);
        }

        private int numTeamsInt(int[]  rating) 
        {
            int squad_size = 3;
            Map<Integer,Integer>[] storage = new Map[squad_size];
            for (int i =0; i < squad_size; i++) {storage[i] = new HashMap<Integer,Integer>();}
            for (int s=0;s < rating.length +1 - squad_size;s++) {
                if( storage[0].get(rating[s]) != null) {
                    storage[0].put(rating[s],1);
                } else {
                    storage[0].put(rating[s],storage[0].get(rating[s]) +1);
                }
                for (int i =1 ; i < squad_size; i++) {
                    int current = 0;
                    for(Map.Entry<Integer,Integer> me : storage[i-1].entrySet()) {
                        if(me.getKey() < rating[s+i]) {
                            current+= me.getValue();
                        }
                    }
                    if(current>0) {
                        if( storage[i].get(rating[s+i]) != null) {
                            storage[i].put(rating[s+i],current);
                        } else {
                            storage[i].put(rating[s+i],storage[0].get(rating[s+i]) +current);
                        }
                    } 
                    
                }
            }
            int result = 0;
            for(int  i : storage[squad_size-1].values()) {
                result += i;
            }
            return result;
        }

        private void reverse(int[] a) {
            int l = 0; 
            int u = a.length-1;
            while(l<u) {
                int t = a[l];
                a[l] = a[u];
                a[u] = t;
                l++;
                u--;
            }
        }
    }
}