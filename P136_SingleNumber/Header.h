#include "stdafx.h"

using namespace std;

class Solution {
public:
	int singleNumber(vector<int>& nums) {
		int accumulator = 0;
		for (vector<int>::iterator it = nums.begin(); it != nums.end(); it++) {
			accumulator ^= *it;
		}
		return accumulator;
	}
};