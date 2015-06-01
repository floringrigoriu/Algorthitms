/*
Related to question Excel Sheet Column Title

Given a column title as appear in an Excel sheet, return its corresponding column number.

For example:

A -> 1
B -> 2
C -> 3
...
Z -> 26
AA -> 27
AB -> 28

*/

#include <string>
#include "stdafx.h"
using namespace std;

class CLASS_DECLSPEC Solution_P171 {
public:
	int titleToNumber(string s);

private: inline int getChVal(char ch) {
		ch = ch & 0xdf; // to upper
		int val = ch - 'A' + 1; // a == 1;
		// todo: validation : don't allow ch outside [a-z] interval
		return val;
	}
};