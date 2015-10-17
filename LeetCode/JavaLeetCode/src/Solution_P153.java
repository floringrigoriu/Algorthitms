//Suppose a sorted array is rotated at some pivot unknown to you beforehand.
//
//(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
//
//Find the minimum element.
//
//You may assume no duplicate exists in the array.


public class Solution_P153 {
	public int findMin(int[] nums) {
        if(nums == null || nums.length == 0) {
        	return Integer.MAX_VALUE;
        }
        
        int start = 0;
        int end = nums.length -1 ;
        while( end - start > 1 && nums[start] > nums[end]) {
        	int mid = (end -start )/2 + start;
        	if (nums[mid] > nums[end]) {
        		start = mid;
        	} else {
        		end = mid;
        	}
        	
        }
        
        if(end - start != 1 ) {
        	return nums[start];
        } else {
        	return Math.min(nums[start], nums[end]);
        }
    }
}
