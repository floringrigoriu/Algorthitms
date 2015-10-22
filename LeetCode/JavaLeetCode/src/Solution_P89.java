import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;
import java.util.Stack;

//The gray code is a binary numeral system where two successive values differ in only one bit.
//
//Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. A gray code sequence must begin with 0.
//
//For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:
//
//00 - 0
//01 - 1
//11 - 3
//10 - 2
//Note:
//For a given n, a gray code sequence is not uniquely defined.
//
//For example, [0,2,3,1] is also a valid gray code sequence according to the above definition.
//
//For now, the judge is able to judge based on one instance of gray code sequence. Sorry about that.
public class Solution_P89 {
    public List<Integer> grayCode(int n) {
        if(n < 0 || n >31) {
        	return new LinkedList<Integer>();
        }
        Stack<Integer> seed = new Stack<Integer>();
        seed.push(0);
        int mask = 0x1;
        while(n>0) {
        	n--;
        	Queue<Integer> higher = new LinkedList<Integer>();
        	Stack<Integer> lower = new Stack<Integer>();
        	while(!seed.isEmpty()){
        		higher.add(mask|seed.peek());
        		lower.push(seed.pop());
        	}
        	mask <<=1;
        	while(!lower.isEmpty()){
        		seed.push(lower.pop());
        	}
        	seed.addAll(higher);
        }
        
        return new ArrayList<Integer>(seed);
    }
}
