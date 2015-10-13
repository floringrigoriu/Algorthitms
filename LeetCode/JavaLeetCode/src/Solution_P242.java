import java.util.HashMap;
import java.util.Map;

//Given two strings s and t, write a function to determine if t is an anagram of s.
//
//For example,
//s = "anagram", t = "nagaram", return true.
//s = "rat", t = "car", return false.
//
//Note:
//You may assume the string contains only lowercase alphabet


public class Solution_P242 {
	 public boolean isAnagram(String s, String t) {
		 if(s == null ^ t == null) {
			 return false;
		 }
		  if(s==t) {
			 return true; 
		 }
		 // by now we know for sure the strings are not null
		 if(s.length() != t.length()) {
			 return false;
		 }
		 
		 Map<Character,Integer> histogramS = getHistogram(s);
		 Map<Character,Integer> histogramT = getHistogram(t);
		 return histogramS.equals(histogramT);		
	}
	 
	private  static Map<Character,Integer> getHistogram(String s) {
		Map<Character,Integer> result = new HashMap<Character,Integer>(32);
		int size = s.length();
		for(int i=0 ; i< size ;i ++) {
			char c = s.charAt(i);
			Integer value = result.get(c);
			if(value == null) {
				value = 1;
			} else {
				value++;
			}
			result.put(c, value);
			
		}
		
		return result;
		
	}
}
