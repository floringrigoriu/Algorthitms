import static org.junit.Assert.assertEquals;
import static org.junit.Assert.fail;


public class TreeTestUtility {
	public static void treeAreEqual(TreeNode t1, TreeNode t2){
		if (t1 == null && t2 == null) {
			//all is good
			return;
		}
		if(t1 == null) {
			fail(String.format("first node is null  other is %d",t2.val));
		}
		if (t2 == null) {
			fail(String.format("second node is null  other is %d",t1.val));
		}
		// both t1,t2 not null
		assertEquals(t1.val, t2.val);
		treeAreEqual(t1.left,t2.left);
		treeAreEqual(t1.right, t2.right);
	}
}
