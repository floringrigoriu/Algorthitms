//Write a program to check whether a given number is an ugly number.
//
//Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. For example, 6, 8 are ugly while 14 is not ugly since it includes another prime factor 7.
//
//Note that 1 is typically treated as an ugly number.

/**
 * @param {number} num
 * @return {boolean}
 */
var removeFactor = function(num, factor) {
    while(num % factor === 0) {
        num = num  / factor;
    }
    return num;
}
var isUgly = function(num) {
    if(num === 0) {
        return false;
    }
    var uglyNumberDivisors = new Array(2, 3, 5);
    for(var i = 0 ; i < uglyNumberDivisors.length; i++ ) {
        num = removeFactor(num,uglyNumberDivisors[i]);
    }
    return num === 1;
};