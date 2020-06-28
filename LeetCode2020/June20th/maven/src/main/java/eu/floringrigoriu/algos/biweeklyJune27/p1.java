package main.java.eu.floringrigoriu.algos.biweeklyJune27;

// https://uipath.visualstudio.com/Cloud%20RPA/_build/results?buildId=1009047&view=results
public class p1 {
    class Solution {
        public double average(int[] salary) {
           int min = salary[0];
           int max = salary[0];
           int result =0;
           for(int n: salary) {
               result += n;
               min = Math.min(min,n);
               max = Math.max(max,n);
           } 
           return 1.0 * (result-min -max) / (salary.length-2);
        }
    }
}