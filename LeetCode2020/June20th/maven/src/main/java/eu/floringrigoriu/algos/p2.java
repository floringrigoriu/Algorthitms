package eu.floringrigoriu.algos;


import java.util.*;
// https://leetcode.com/contest/weekly-contest-194/problems/making-file-names-unique/


public class p2 {
    class Solution {
        public String[] getFolderNames(String[] names) {
            String[] result = new String[names.length];
            Set<String> uniqueNames = new HashSet<String>();
            Map<String,Integer> collisions = new HashMap<String,Integer>();
            for(int i= 0 ; i< names.length ;i++) {
                if(!uniqueNames.contains(names[i])) {
                    result[i] = names[i];
                    uniqueNames.add(names[i]);
                } else {
                    Integer idx = collisions.get(names[i]);
                    if (idx == null) {idx = 1;}
                    String newName;
                    do {
                        newName = names[i] + "("+ idx.toString()+")";
                        idx++;
                    }
                    while (uniqueNames.contains(newName));
                    result[i] = newName;
                    collisions.put(names[i], idx);
                    uniqueNames.add(newName);
                }
            }
            return result;
        }
    }
}