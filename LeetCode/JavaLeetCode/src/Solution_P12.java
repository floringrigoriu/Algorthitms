//Given an integer, convert it to a roman numeral.
//
//Input is guaranteed to be within the range from 1 to 3999.


public class Solution_P12 {

    private static final RomanDigits[] translator =  new RomanDigits[]{
    	new Solution_P12.RomanDigits(' ', 'M' , 1000 ),
    	new Solution_P12.RomanDigits('D', 'C' , 100 ),
    	new Solution_P12.RomanDigits('L', 'X' , 10 ),
    	new Solution_P12.RomanDigits('V', 'I' , 1 ),
    };
	
	public String intToRoman(int num) {
        if(num <0 || num > 3999) {
        	return "";
        }
        
		int index = translator.length - 1;
        StringBuilder sb = new StringBuilder();
        while (num > 0) {
        	assert(index>=0);
        	int digit = num % 10; 
        	if ( digit != 0) {
        		if (digit == 9) {
        			assert (index >0); 
        			{
        				sb.insert(0,translator[index-1].one);
        				sb.insert(0,translator[index].one);
        			}
        		} else if (digit == 4) {
        			sb.insert(0,translator[index].five);
        			sb.insert(0,translator[index].one);
        		} else {
	        		boolean hasFive = false;
	        		if(digit >= 5) {
	        			hasFive = true;
	        			digit -=5;
	        		}
	        		assert(digit <= 3);
	        		while(digit >0) {
	        			sb.insert(0,translator[index].one);
	        			digit --;
	        		}
	        		if(hasFive) {
	        			sb.insert(0,translator[index].five);
	        		}
        		}
        	}
        	num /=10;
        	index --;
        }
        
        
        return sb.toString();
        
    }
    
    private static class RomanDigits {
    	public char five;
    	public char one;
    	public int multiplier;
    	
    	public RomanDigits( char five,char one, int multiplier){
    		this.five = five;
    		this.one = one;
    		this.multiplier= multiplier;
    	}
    }
}
