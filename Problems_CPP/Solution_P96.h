/*
Given n, how many structurally unique BST's (binary search trees) that store values 1...n?

For example,
Given n = 3, there are a total of 5 unique BST's.

1         3     3   2      1
\       /     /    / \      \
3     2     1      1   3      2
/    /       \                 \
2    1         2                 3

*/

// start : 2:55 PM

#include "stdafx.h"
#include <map>

using namespace std;

class Solution_P96 {

private:
	map<int, int> computed_unique_bst;

public:
	int numTrees(int n) {
		if (n < 0) {
			throw "negative number of nodes in BST not supported";
		}
		
		// base case - null trees or trees with 1 node - allow only one unique representation
		if (n == 0 || n == 1) {
			return 1;
		}

		// recursive solution with caching of intermediare results
		// based on observation that you can build 5 unique BST with 1..3 or n,n+1,n+2
		auto cache = computed_unique_bst.find(n);
		if (cache != computed_unique_bst.end()) {
			return cache->second;
		}
		else {
			int compute = 0;
			for (int pos = 0; pos < n; pos++){ // pos - position of the root
				compute += this->numTrees(pos)/*number of nodes in left subtree*/ 
					*  this->numTrees(n - 1 - pos) /*number of nodes in rights subtree*/;
			}
			computed_unique_bst[n] = compute; // cache it 
			return compute;
		}
	}
};
// end 3:15PM