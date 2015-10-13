
public class Solution_P256 {
   
	 /*O(1)*/
	public int addDigits(int num) {
        if(num == 0) {
        	return 0;
        }
        num = num % 9;
        if(num == 0) {
        	num = 9;
        }
        return num < 0 ? (-1)*num : num;
   }
	
	public int addDigistsIter(int num){
		int result = 0;
		do {
			while (num !=0) {
				result += num % 10;
				num /= 10;
			}
			
			result = Math.abs(result);
			if (result >= 10 ) {
				num = result;
				result = 0;
			}
			
		} while(num >= 10);
		
		return result;
	}
}
