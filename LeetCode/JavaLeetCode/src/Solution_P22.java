import java.util.LinkedList;
import java.util.List;

//Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
//
//For example, given n = 3, a solution set is:
//
//"((()))", "(()())", "(())()", "()(())", "()()()"

public class Solution_P22 {
    public List<String> generateParenthesis(int n) {
       List<String> result = new LinkedList<String>();
       StringBuilder current = new StringBuilder(n*2);
       internalGenerate(result, current, n, n);
       return result;
    }
    
    private void internalGenerate(List<String> accumulator, StringBuilder current, int opened , int closed) {
    	if(opened < 0) {
    		return; // not enough parentheses
    	}
    	if (opened == 0 && closed == 0) {
    		accumulator.add(current.toString());// done !
    		return;
    	}
    	if(closed < opened ) {
    		return; //invalid
    	}
    	internalGenerate(accumulator, current.append('('), opened -1, closed);
    	current.deleteCharAt(current.length()-1);
    	
    	internalGenerate(accumulator, current.append(')'), opened , closed - 1);
    	current.deleteCharAt(current.length()-1);
    }
}
