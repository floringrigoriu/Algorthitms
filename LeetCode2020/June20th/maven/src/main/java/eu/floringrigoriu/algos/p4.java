package eu.floringrigoriu.algos;
import java.util.*;

/*
https://leetcode.com/contest/weekly-contest-194/problems/find-critical-and-pseudo-critical-edges-in-minimum-spanning-tree/

5443. Find Critical and Pseudo-Critical Edges in Minimum Spanning Tree
User Accepted:54
User Tried:114
Total Accepted:54
Total Submissions:199
Difficulty:Hard
Given a weighted undirected connected graph with n vertices numbered from 0 to n-1, and an array edges where edges[i] = [fromi, toi, weighti] represents a bidirectional and weighted edge between nodes fromi and toi. A minimum spanning tree (MST) is a subset of the edges of the graph that connects all vertices without cycles and with the minimum possible total edge weight.

Find all the critical and pseudo-critical edges in the minimum spanning tree (MST) of the given graph. An MST edge whose deletion from the graph would cause the MST weight to increase is called a critical edge. A pseudo-critical edge, on the other hand, is that which can appear in some MSTs but not all.

Note that you can return the indices of the edges in any order.
 
*/

public class p4 {
    public List<List<Integer>> findCriticalAndPseudoCriticalEdges(int n, int[][] edges) {
            
        Map<Integer, List<Integer>> graph = getGraph(n, edges);
        int mstVal = getMSTCost(n, edges, graph, n);
        List<Integer> crit = new ArrayList<Integer>();
        List<Integer> pseudo = new ArrayList<Integer>();
        for(int i= 0;i < edges.length; i++) {
            if(getMSTCost(n, edges, graph, i) > mstVal) {
                crit.add(i);
            } else {
                pseudo.add(i);
            }
        }
        return  List.of(crit, pseudo);
   }

   private Map<Integer, List<Integer>> getGraph(int n, int[][] edges) {
       Map<Integer, List<Integer>> graph  = new HashMap<Integer, List<Integer>>();
       for(int i =0; i< n ;i++) {
           graph.put(
               i, 
               new ArrayList<Integer>()
               );
       }
       for(int i=0;i< edges.length;i++) {
           int[] e = edges[i];
           graph.get(e[0]).add(i);
           graph.get(e[1]).add(i);
       }
       return graph;
   }

   private int getMSTCost(int n, int[][] edges, Map<Integer, List<Integer>> graph, int skip) 
   {
       int cost =0;
       Set<Integer> visited = new HashSet<Integer>();
       visited.add(0);
       Queue<int[]> pq = new PriorityQueue<int[]>((a,b) -> a[2]-b[2]);
       for(int e : graph.get(0)) {
           if(e!= skip) {
               pq.add(edges[e]);
           }
       }

       while(!pq.isEmpty() && visited.size()<n) {
           int[] next = pq.poll();
           if (visited.contains(next[0]) && visited.contains(next[1])) {
               continue;
           }
           int other = next[0];
           if(visited.contains(other)) {
               other = next[1];
           }
           cost+= next[2];
           visited.add(other);
           
           for(int id : graph.get(other)) {
               int[] e = edges[id];
               if(id!= skip && (!visited.contains(e[0]) || !visited.contains(e[1]))) {
                   pq.add(e);
               }
           }
       }
       return visited.size()<n ? Integer.MAX_VALUE : cost;
   }
}