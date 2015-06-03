/*
Given an array of integers, find if the array contains any duplicates. 
Your function should return true if any value appears at least twice in the array, 
and it should return false if every element is distinct.
*/

#include "stdafx.h"
#include <unordered_set>

using namespace std;

class CLASS_DECLSPEC Solution_P217 {
public:
	bool containsDuplicate(vector<int>& nums) {
		// alternative :
		// - extra memory O(n), time : O(n)
		// - sort + no extra memory - time : O(nLogn)
		// - brute force : all pairs O(n^2)
		bool result = false;
		unordered_set<int> *acc = new unordered_set<int>();
		for (auto it = nums.begin(); it < nums.end(); it++) {
			if (acc->find(*it) != acc->end()) {
				result = true;
				break;
			}
			acc->emplace(*it);
		}
		delete(acc);
		return result;
	}
};