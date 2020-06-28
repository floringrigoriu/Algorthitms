package eu.floringrigoriu.algos;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Random;

// https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3358/

// Design a data structure that supports all following operations in average O(1) time.

// insert(val): Inserts an item val to the set if not already present.
// remove(val): Removes an item val from the set if present.
// getRandom: Returns a random element from current set of elements. Each element must have the same probability of being returned.

public class p12 {
    class RandomizedSet {
        
        Map<Integer,Integer> set;
        List<Integer> random_storage;
        Random rnd;

        /** Initialize your data structure here. */
        public RandomizedSet() {
            set = new HashMap<Integer,Integer>();
            random_storage = new ArrayList<Integer>();
            rnd = new Random();
        }
        
        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public boolean insert(int val) {
            if (!set.containsKey(val)) {
                set.put(val,set.size());
                if(set.size()>random_storage.size()) {
                    random_storage.add(val);
                } else {
                    random_storage.set(set.size()-1,val);
                }
                return true;
             } else {
                 return false;
             }
        }
        
        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public boolean remove(int val) {
            if (set.containsKey(val)) {
                int idx = set.get(val);
                random_storage.set(idx, random_storage.get(random_storage.size()-1));
                set.put(random_storage.get(idx),idx);
                set.remove(val);
                return true;
             } else {
                 return false;
             }
        }
        
        /** Get a random element from the set. */
        public int getRandom() {
            return random_storage.get(rnd.nextInt(set.size())); 
        }
    }
}