#include "stdafx.h"
#include "Solution_P144.h"
#include <stack>

using namespace std;

vector<int> Solution_P144::preorderTraversal(TreeNode* root){
	vector<int> *result = new vector<int>();
	stack<TreeNode*> *next_nodes = new stack<TreeNode*>(); // nodes of the tree to visited
	next_nodes->push(root);
	while (!next_nodes->empty())
	{
		TreeNode* current = next_nodes->top();
		next_nodes->pop();
		if (current != NULL) {
			result->push_back(current->val);
			next_nodes->push(current->left);
			next_nodes->push(current->right);
		}
	}
	delete(next_nodes);
	return *result;
}