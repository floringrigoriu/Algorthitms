//Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.
//
//Note:
//You must not modify the array (assume the array is read only).
//You must use only constant, O(1) extra space.
//Your runtime complexity should be less than O(n2).
//There is only one duplicate number in the array, but it could be repeated more than on

public class Solution_P287 {
    public int findDuplicate(int[] nums) {
        if(nums == null || nums.length < 2) {
        	return -1;
        }
        
        int min = 1; // min value - inclusive
        int max = nums.length; // max value - exclusive
        while (min + 1 < max) {
        	int mid = min + (max-min) /2;
        	int lower = 0;
        	for(int n : nums) {
        		if (n <mid &&  n >= min) {
        			lower++;
        		}
        	}
        	if (lower > mid - min) {
        		// more elements in the range min - mid;
        		max = mid;
        	} else {
        		min = mid;
        	}
        }
        
        return min; // 
    }
}
