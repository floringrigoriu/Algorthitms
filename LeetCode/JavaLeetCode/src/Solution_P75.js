/**
 * Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.

Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

Note:
You are not suppose to use the library's sort function for this problem.
 */

/**
 * @param {number[]} nums
 * @return {void} Do not return anything, modify nums in-place instead.
 */
var sortColors = function(nums) {
    if(nums === null) {
        return;
    }
    var low = 0;
    var hi_w = nums.length -1 ;
   
    while(hi_w >= 0 && nums[hi_w] ===2) {
        hi_w --;
    }
    var hi_r = hi_w;
    while(hi_r > low) {
        while(nums[low] ===0  && low <= hi_r) {
            low ++;
        }
        while (hi_r >= low && nums[hi_r]!== 0) {
            if(nums[hi_r] === 1) {
                // nothing
                hi_r --;
            } else {
                nums[hi_r] = 1;
                nums[hi_w] = 2;
                hi_r --;
                hi_w --;
            }
        }
        if(low <hi_r) {
            
            nums[hi_r] = nums[low];
            nums[low] = 0;
        }
        
    }
    
};