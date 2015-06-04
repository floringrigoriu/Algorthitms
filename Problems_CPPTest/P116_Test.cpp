#include "stdafx.h"
#include "CppUnitTest.h"

#include "..\Problems_CPP\Solution_P116.h"
#include <queue>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Problems_CPPTest
{
	TEST_CLASS(P116_Test)
	{
	public:
		
		TEST_METHOD(BasicTest4Levels)
		{
			// build get 4 level complete tree
			int treeNodeId = 1;
			TreeLinkNode *tree = new TreeLinkNode(treeNodeId);
			queue<TreeLinkNode*> *nodes = new queue<TreeLinkNode*>();
			nodes->push(tree);
			//BFS per level
			for (int level = 1; level < 4; level++){
				queue<TreeLinkNode*> *next_nodes = new queue<TreeLinkNode*>();
				while (!nodes->empty())
				{
					TreeLinkNode *cur = nodes->front();
					nodes->pop();
					cur->left = new TreeLinkNode(++treeNodeId);
					cur->right = new TreeLinkNode(++treeNodeId);
					next_nodes->push(cur->left);
					next_nodes->push(cur->right);
				}
				delete(nodes);
				nodes = next_nodes;
			}
			// connect it
			Solution_P116 *s = new Solution_P116();
			s->connect(tree);

			// validate it
			TreeLinkNode *last_level = tree->left->left->left;
			int expectedId = 8;
			while (last_level != NULL) {
				Assert::AreEqual(last_level->val, expectedId);
				expectedId++;
				last_level = last_level->next;
			}
			Assert::AreEqual(16, expectedId, L"expected 8 nodes on the last row connected");
		}
	};
}