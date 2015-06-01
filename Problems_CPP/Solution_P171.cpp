#include "stdafx.h"
#include "Solution_P171.h"

int Solution_P171::titleToNumber(string s){
	int val = 0;
	int coef = 1;
	for (int i = s.length() - 1; i >= 0; i--) {
		val += coef * this->getChVal(s.at(i));
		coef *= 26;
	}
	return val;
}