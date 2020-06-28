import java.util.*;
import java.util.stream.*;

// https://leetcode.com/contest/weekly-contest-193/problems/least-number-of-unique-integers-after-k-removals/
public class p2 {
    public class Counter<T> {
        public final Map<T, Integer> counts = new HashMap<>();
    
        public Integer increment(T t) {
            return counts.merge(t, 1, Integer::sum);
        }
    
        public int count(T t) {
            return counts.getOrDefault(t, 0);
        }
    }
    public int findLeastNumOfUniqueInts(int[] arr, int k) {
        
        if(k>=arr.length) {
            return 0;
        } else if (k==arr.length-1){
            return 1;
        }
        Counter<Integer> counter = new Counter<>();
        for (int i:arr) {
            counter.increment(i);
        }

        int total = counter.counts.size();
        // get groups by counts
        List<Map.Entry<Integer, Integer>> sortedByPrice = counter.counts.entrySet()
            .stream() 
            .sorted(Map.Entry.<Integer, Integer>comparingByValue())
            .collect(Collectors.toList());

        for (Map.Entry<Integer, Integer> ms : sortedByPrice) {
           // System.out.println(ms.getKey()+"->" + ms.getValue());
            if (k>= ms.getValue()) {
                k-= ms.getValue();
                total--;
                //System.out.println(ms.getKey()+"-" + ms.getValue());
            } else {
                break;
            }
        }
        return total;
    } 
}