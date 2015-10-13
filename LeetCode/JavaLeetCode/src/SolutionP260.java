//
//Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once.
//
//For example:
//
//Given nums = [1, 2, 1, 3, 2, 5], return [3, 5].
//
//Note:
//The order of the result is not important. So in the above example, [5, 3] is also correct.
//Your algorithm should run in linear runtime complexity. Could you implement it using only constant space complexity?

public class SolutionP260 {
	public int[] singleNumber(int[] nums) {
	
		int xor = 0;
		for( int i: nums) {
			xor ^= i;
		}
		
		int bit = xor;
		int loc = 0;
		while (bit != 0  && (bit & 1) == 0) {
			bit >>>=1;
			loc ++;
		}
		
		bit = 1 << loc;
		
		// get 1st number
		
		int first = 0;
		
		for( int i: nums) {
			if((i&bit) != 0 ) {
				first ^= i;
			}
		}
		
		return new int [] { first , xor ^ first}; 
		
	}
	
}
