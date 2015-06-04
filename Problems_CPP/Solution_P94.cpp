#include "stdafx.h"
#include "Solution_P94.h"
#include <stack>

using namespace std;

vector<int> Solution_P94::inorderTraversal(TreeNode* root) {
	stack<pair<TreeNode*, Direction>*> *nodes = new stack<pair<TreeNode*, Direction>*>();
	nodes->push(new pair<TreeNode*, Direction>(root, Direction::Up));
	vector<int> *result = new vector<int>();
	while (!nodes->empty())
	{
		auto cur = nodes->top(); nodes->pop();
		if (cur->first != NULL){
			// handle left subree
			if (cur->second == Direction::Up) {
				cur->second = Direction::Down; // next time will come from below
				nodes->push(cur);
				nodes->push(
					new pair<TreeNode*, Direction>(cur->first->left, Direction::Up)
					);

			}
			else {
				//handle currrent node :: direction down
				result->push_back(cur->first->val);
				// handle right subtree
				nodes->push(new pair<TreeNode*, Direction>(cur->first->right, Direction::Up));
			}
		}
	}
	return *result;
}