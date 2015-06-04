/*

Given a binary tree, return the inorder traversal of its nodes' values.

For example:
Given binary tree {1,#,2,3},
1
\
2
/
3
return [1,3,2].

Note: Recursive solution is trivial, could you do it iteratively?

confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.

*/

// start : 2:46PM

#include "stdafx.h"
using namespace std;



class CLASS_DECLSPEC Solution_P94 {
private:
	enum Direction{ // enum to use the state of the node exploration
		Up, // exploring a node coming from its parent
		Down // exploring the node after exploring the left subtree
	};
public:
	vector<int> inorderTraversal(TreeNode* root);
};

// time : 3:03
