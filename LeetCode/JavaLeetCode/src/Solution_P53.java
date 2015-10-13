/*
 * 
 * Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

For example, given the array [-2,1,-3,4,-1,2,1,-5,4],
the contiguous subarray [4,-1,2,1] has the largest sum = 6.

click to show more practice.

More practice:
If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
 * 
 * 
 * 
 * */



public class Solution_P53 {
	public int maxSubArray(int[] nums) {
		return this.maxSubArray(nums, 0 , nums.length);
    }
	
	private int maxSubArray(int[] nums, int start, int end) {
		if(start == end ) {return Integer.MIN_VALUE;}
		if(start + 1 == end ) {
			return  nums[start];
		}
		int mid = (end - start) / 2 + start;
		int result = this.maxSubArray(nums, start, mid);
		result = Math.max(result, this.maxSubArray(nums, mid, end));
		result = Math.max(result, this.maxSubArrayDivided(nums, start , mid, end));
		return result;
	}
	
	private int maxSubArrayDivided(int[] nums, int start, int mid, int end) {
		int max_l = 0;
		boolean any = false;
		int sum = 0;
		for (int i = mid - 1 ; i >= start ; i --) {
			sum+=nums[i];
			if(sum > max_l) {
				max_l = sum;
				any = true;
			}
		}
		sum = 0;
		int max_r = 0;
		
		for (int j = mid ; j < end ; j++) {
			sum+= nums[j];
			if (sum > max_r) { max_r = sum; any = true;}
		}
		if(any) {
		return max_l+max_r;
		} else {
			return Integer.MIN_VALUE;
		}
		
	}
	
}
