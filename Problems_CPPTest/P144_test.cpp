#include "stdafx.h"
#include "CppUnitTest.h"

#include "..\Problems_CPP\Solution_P144.h"
//#include "..\Problems_CPP\TreeNode.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Problems_CPPTest
{
	TEST_CLASS(P144Test)
	{

	public:

		TEST_METHOD(TestBasic)
		{	
			// define tree
			TreeNode *root = new TreeNode(1);
			root->left = new TreeNode(2);
			root->right = new TreeNode(3);
			root->left->left = new TreeNode(4);
			root->left->right = new TreeNode(5);
			
			// define solution
			Solution_P144 *s = new Solution_P144();

			// test it
			std::string expected = " 1 2 4 5 3";
			vector<int> result = s->preorderTraversal(root);
			std::string actual;
			for (auto i : result) {
				actual += " ";
				actual += std::to_string(i);
			}
			Assert::AreEqual(expected, actual);
		}
	};
}