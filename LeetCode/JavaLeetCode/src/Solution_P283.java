import java.util.Arrays;


//Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
//
//For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0].
//
//Note:
//You must do this in-place without making a copy of the array.
//Minimize the total number of operations.
	

public class Solution_P283 {

    public void moveZeroes(int[] nums) {
        int dest = 0;
        int source = 0;
        // leave initial non-zero unmoved
        while (source < nums.length && nums[source] != 0) {
        	source ++;
        }
        dest = source;
        // dest is placed on the first 0 - 
        while(source < nums.length) {
        	if(nums[source] != 0 ) { nums[dest] = nums[source]; dest++;}
        	source++;
        }
        
        // trailing 0s
        Arrays.fill(nums, dest, source ,0);
// or less efficient :
//        for(;dest < nums.length ; dest ++) {
//        	nums[dest] =0;
//        }
        
    }
}
