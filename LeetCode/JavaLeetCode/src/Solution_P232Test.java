import static org.junit.Assert.*;

import org.junit.Test;


public class Solution_P232Test {

	@Test
	public void testQueueBehavior() {
		
		Solution_P232.MyQueue q = new Solution_P232.MyQueue();
		
		assert(q.empty());
		q.push(1);
		assertFalse(q.empty());
		q.push(2);
		assertEquals(q.peek(),1);
		q.pop();
		q.push(3);
		assertEquals(q.peek(),2);
		q.pop();
		assertEquals(q.peek(),3);
		assertFalse(q.empty());
		q.pop();
		assert(q.empty());
	}

}
