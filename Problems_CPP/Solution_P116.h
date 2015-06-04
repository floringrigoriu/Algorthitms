/*
Given a binary tree

struct TreeLinkNode {
TreeLinkNode *left;
TreeLinkNode *right;
TreeLinkNode *next;
}
Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

Initially, all next pointers are set to NULL.

Note:

You may only use constant extra space.
You may assume that it is a perfect binary tree (ie, all leaves are at the same level, and every parent has two children).
For example,
Given the following perfect binary tree,
1
/  \
2    3
/ \  / \
4  5  6  7
After calling your function, the tree should look like:
1 -> NULL
/  \
2 -> 3 -> NULL
/ \  / \
4->5->6->7 -> NULL

*/


/**
* Definition for binary tree with next pointer.
* struct TreeLinkNode {
*  int val;
*  TreeLinkNode *left, *right, *next;
*  TreeLinkNode(int x) : val(x), left(NULL), right(NULL), next(NULL) {}
* };
*/

// 1:25 PM - 1:35 PM plan

#include "stdafx.h"
#include "TreeLinkNode.h"

class Solution_P116 {
public:
	void connect(TreeLinkNode *root) {
		if (root == NULL) {
			return;
		}

		TreeLinkNode *level = root;
		// works only for complete trees
		while (level->left != NULL) {
			TreeLinkNode *cur = level;
			// for intermediar nodes connect left to right, and right to the left of the next node
			while (cur->next !=NULL)
			{
				cur->left->next = cur->right;
				cur->right->next = cur->next->left;
				// progress on level
				cur = cur->next;
			}
			// connect only the left of the last node
			cur->left->next = cur->right;
			// progress to next level:
			level = level->left;
		}
		// that should be all
	}
}; // end : 1:47 PM



