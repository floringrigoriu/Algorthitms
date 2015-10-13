import java.util.Stack;


public class Solution_P226 {
	
	
	public class Pair<K, V> {

	    private final K element0;
	    private final V element1;

	    public Pair(K element0, V element1) {
	        this.element0 = element0;
	        this.element1 = element1;
	    }

	    public K getElement0() {
	        return element0;
	    }

	    public V getElement1() {
	        return element1;
	    }

	}
	 
	public TreeNode invertTree(TreeNode root) {
        if(root == null) {
        	return null;
        }
        TreeNode result = new TreeNode(root.val);
        Stack<Solution_P226.Pair<TreeNode,TreeNode>> nodes = 
        		new Stack<Solution_P226.Pair<TreeNode,TreeNode>>(); 
	    nodes.add(new Pair<TreeNode,TreeNode>(root,result));
	    while(!nodes.isEmpty()) {
	    	Solution_P226.Pair<TreeNode,TreeNode> node = nodes.pop();
	    	TreeNode sourceNode = node.getElement0();
	    	TreeNode targetNode = node.getElement1();
	    	if(sourceNode != null) {
	    		if(sourceNode.left != null) {
	    			targetNode.right = new TreeNode(sourceNode.left.val);
	    			nodes.push(new Pair<TreeNode,TreeNode>(sourceNode.left, targetNode.right));
	    		}
	    		if(sourceNode.right !=null) {
	    			targetNode.left = new TreeNode(sourceNode.right.val);
	    			nodes.push(new Pair<TreeNode,TreeNode>(sourceNode.right, targetNode.left));
	    		}
	    	}
	    }
        
        return result;    

	}
	
	

}
