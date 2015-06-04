#include "stdafx.h"
#include "CppUnitTest.h"

#include "..\Problems_CPP\Solution_P94.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Problems_CPPTest
{
	TEST_CLASS(P94Test)
	{

	public:

		TEST_METHOD(TestIterativeInorderTraversal)
		{
			// define tree
			TreeNode *root = new TreeNode(1);
			root->left = new TreeNode(2);
			root->right = new TreeNode(3);
			root->left->left = new TreeNode(4);
			root->left->right = new TreeNode(5);

			// define solution
			Solution_P94 *s = new Solution_P94();

			// test it
			std::string expected = " 4 2 5 1 3";
			vector<int> result = s->inorderTraversal(root);
			std::string actual;
			for (auto i : result) {
				actual += " ";
				actual += std::to_string(i);
			}
			Assert::AreEqual(expected, actual);
		}
	};
}