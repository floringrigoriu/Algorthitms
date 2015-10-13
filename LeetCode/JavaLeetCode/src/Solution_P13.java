import java.util.HashMap;
import java.util.Map;


public class Solution_P13 {

	private Map<Character, Integer> roman_to_int;
	
	public Solution_P13(){
		roman_to_int =  new HashMap<Character, Integer>();
		roman_to_int.put('M', 1000);
		roman_to_int.put('D', 500);
		roman_to_int.put('C', 100);
		roman_to_int.put('L', 50);
		roman_to_int.put('X', 10);
		roman_to_int.put('V', 5);
		roman_to_int.put('I',1); 
	}

	int RomanToInteger(String s) /*throws Exception*/ {
		
		int result = 0;
		for(int i = 0 ; i < s.length() ; i ++){
			int val = this.getValue(s.charAt(i));
			result+=val;
			if( i >= 1) {
				// pred
				int pred = this.getValue(s.charAt(i-1));
				if(pred < val) {
					// something like IX or XM
					result -= 2 * pred;
				}
			}
		}
		return result;

	}
	
	private int getValue(Character ch) /*throws Exception */{
		if(!roman_to_int.containsKey(ch)){
			return 0;
			//{ throw new Exception(" {0} not a valid roman letter");}
		}
		return roman_to_int.get(ch);
	}
}
