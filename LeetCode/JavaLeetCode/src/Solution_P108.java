//Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
public class Solution_P108 {

	public TreeNode sortedArrayToBST(int[] nums) {
		return sortedArrayToBST(nums, 0, nums.length);
    }
	
	private TreeNode sortedArrayToBST(int[] nums, int start, int end) {
		if(start == end) {
			return null;
		}
		int mid = start   + (end - start) /2;
		TreeNode result = new TreeNode(nums[mid]);
		result.left = sortedArrayToBST(nums, start, mid);
		result.right = sortedArrayToBST(nums, mid + 1, end);
		return result;
	}
}
