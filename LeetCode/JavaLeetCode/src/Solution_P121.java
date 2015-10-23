//Say you have an array for which the ith element is the price of a given stock on day i.
//
//If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.
public class Solution_P121 {
    public int maxProfit(int[] prices) {
    	int result = 0;
    	if( prices == null || prices.length == 0) {
    		return result;
    	}
    	int min = prices[0];
    	int max = prices[0];
    	
        for(int i: prices ){
        	if(i > max) { //*//
        		max = i;
        		result = Math.max(result, max - min);
        	} else if (i < min) {
        		min = i;
        		max = i;
        	}
        }
        return result;
        // last element will be handled by line marked with"*"
    }
}
