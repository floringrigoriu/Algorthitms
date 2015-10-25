//Write an algorithm to determine if a number is "happy".
//
//A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
//
//Example: 19 is a happy number
//
//12 + 92 = 82
//82 + 22 = 68
//62 + 82 = 100
//12 + 02 + 02 = 1


var next = function(n) {
	var result = 0;
	while(n > 0) {
		var digit = n % 10;
		n = n /10;
		result += n*n;
	}
	return result;
}

var isHappy = function(n) {
    var slow = n;
    var fast = n;
    do {
    	slow = next(slow);
    	fast = next(fast);
    	if(fast ===1 ) {
    		break;
    	}
    	fast = next(fast);
    	
    }while(fast !== 1 && slow !== fast);
	
    return  fast ===1;
};