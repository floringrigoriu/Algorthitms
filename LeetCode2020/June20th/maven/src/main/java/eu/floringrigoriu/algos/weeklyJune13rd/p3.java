package main.java.eu.floringrigoriu.algos.weeklyJune13rd;

import java.util.*;

// https://leetcode.com/contest/weekly-contest-193/problems/minimum-number-of-days-to-make-m-bouquets/
public class p3 {

    class Solution {
    
        public class DayRecord{
            public int start;
            public int bloom;
            public int length =1;
        }
        public int minDays(int[] bloomDay, int m, int k) {
            if(k==0) {
                return 0;
            }
            if (m*k > bloomDay.length) {
                return -1;
            } 
            if (m*k == bloomDay.length) {
                return Arrays.stream(bloomDay).max().getAsInt();
            }
            List<DayRecord> rec = new ArrayList<DayRecord>();
            for(int i = 0; i < bloomDay.length;i++) {
                DayRecord dr = new DayRecord();
                dr.start = i;
                dr.bloom = bloomDay[i];
                rec.add(dr);
            }
            
            Collections.sort(rec, (a,b)-> a.bloom - b.bloom);
            // simulate
            int current = 0;
            TreeMap<Integer, DayRecord> tr = new TreeMap<Integer, DayRecord>();
            for ( DayRecord d : rec) {
                Map.Entry<Integer, DayRecord> low = tr.floorEntry(d.start);
                if (low != null ) {
                    DayRecord lowValue =  low.getValue();
                    if(lowValue.start+lowValue.length == d.start) {
                        current -= lowValue.length / k ;
                        tr.remove(lowValue.start);
                        d.start = lowValue.start;
                        d.length = lowValue.length + 1;
                    }
                }

                Map.Entry<Integer, DayRecord> hi = tr.ceilingEntry(d.start);
                if( hi != null ) {
                    DayRecord hiValue =  hi.getValue();
                    if(hiValue.start== d.length + d.start) {
                        current -= hiValue.length / k ;
                        tr.remove(hiValue.start);
                        d.length += hiValue.length ;
                    }
                }
                current+=d.length /k;

                if(current>= m) {
                    return d.bloom;
                }
                tr.put(d.start, d);

            }
            return -1;

        }
    }
}