

/*
 * Given an array of integers, every element appears three times 
 * except for one. Find that single one.
 * */
public class Solution_P137 {

	final int cardinality = 3 ; // number of occurrences of the normal value 
	
    public int singleNumber(int[] nums) {
    	int[] bits = new int[32];
    	for(int n: nums) {
    		for (int b = 0 ; b < 32 ; b++) {
    			bits[b] += (n >> b) & 0x1;
    			bits[b] %= cardinality;
    		}
    	}
    	
    	int result = 0;
    	for(int b = 0 ; b < 32 ; b++) {
    		if(bits[b] != 0) {
    			result |= 1 << b;
    		}
    	}
    	
    	return result;
    }
}
