package main.java.eu.floringrigoriu.algos.weeklyJune13rd;

// https://leetcode.com/contest/weekly-contest-193/problems/kth-ancestor-of-a-tree-node/

public class p4 {
    class TreeAncestor {

        private int[] parents ;
        public TreeAncestor(int n, int[] parent) {
            this.parents = parent;
        }
        
        public int getKthAncestor(int node, int k) {
            while (k>0 && node != 0) {
                node = this.parents[node];
                k--;    
            }
            
            if (k> 0) {
                return  -1;
            } else {
                return node;
            }
        }
    }
}