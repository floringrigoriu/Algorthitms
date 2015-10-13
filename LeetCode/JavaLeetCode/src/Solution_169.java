//import java.util.Arrays;
//import java.util.Random;

/*
Given an array of size n, find the majority element. The majority element is the element that appears more than 
[ n/2] times.

You may assume that the array is non-empty and the majority element always exist in the array.
*/


public class Solution_169 {
	
	/*Random generator;
	
	public Solution_169() {
		this.generator = new Random();
	}
	*/
	public int majorityElement(int[] nums) {
		int lo = 0; 
		int hi = nums.length ;
		
		while(lo< hi) {
			/*int pivot = this.generator.nextInt(hi - lo) + lo;*/
			int pivot = lo;
			int pos = lo; 
			
			for(int i = lo ; i < hi ; i++) {
				if (nums[i]< nums[pivot]) {pos++;}
			}
			swap(nums, pivot, pos);
			int l = lo ; 
			int j = hi - 1;
			while (l<j){
				while(nums[l] <  nums[pos] && l < pos) {l++;};
				while(nums[j] >= nums[pos] && j > pos) {j--;}
				if(l<j) {
					swap (nums, l, j);
				}
			}
			if(pos > nums.length /2 ) {
				hi = pos;
			} else {
				lo = pos + 1;
			}
		}
		return nums[nums.length / 2];
    }
	
	private void swap(int [] array, int start, int end) {
		if(start == end) {return;}
		array[start] ^= array[end];
		array[end] ^= array[start];
		array[start] ^= array[end];
	}
}
