package eu.floringrigoriu.algos;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.PriorityQueue;
import java.util.Queue;
import java.util.Set;

// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3360/
public class p14 {
    class Solution {

        public class Leg {
            public int dest;
            public int cost;
            public int hops;

        }
        public int findCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
            Map<Integer, List<Leg>> paths = new HashMap<>();
            for (int[] p : flights) {
                List<Leg> l = paths.get(p[0]);
                if(l==null){
                    l = new ArrayList<Leg>();
                    paths.put(p[0],l);
                }
                Leg t = new Leg();
                t.dest = p[1];
                t.cost = p[2];
                l.add(t);
            }
            
            if(paths.containsKey(src)) {
                return -1;
            }

            Queue<Leg> q = new PriorityQueue<Leg>((a,b)-> a.cost - b.cost);
            Set<Integer> v = new HashSet<Integer>();
            
            for(Leg l : paths.get(src)) {
                q.add(l);
            }

            while(!q.isEmpty())
            {
                Leg l = q.poll();
                if(v.contains(l.dest)) {
                    continue;
                }

                if (l.dest == dst) {
                    return l.cost;
                }
                if(l.hops <K && paths.get(l.dest) != null) {
                    for(Leg next : paths.get(l.dest)) {
                        Leg nextLeg = new Leg();
                        nextLeg.dest = next.dest;
                        nextLeg.hops = l.hops+1;
                        nextLeg.cost = l.cost + next.cost;
                        q.add(nextLeg);
                    }
                }
                v.add(l.dest);
            }
            return -1;

        }
    }
}