#include "stdafx.h"
#include "CppUnitTest.h"

#include "..\Problems_CPP\Solution_P141.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Problems_CPPTest
{
	TEST_CLASS(P141Test)
	{

	public:

		TEST_METHOD(TestNoLoop)
		{
			// setup
			ListNode *head = new ListNode(1);
			Solution_P141 *s = new Solution_P141();
 
			// trigger
			auto result = s->hasCycle(head);

			// test
			Assert::IsFalse(result);
		}

		TEST_METHOD(TestLoop)
		{
			// setup
			ListNode *head = new ListNode(1);
			head->next = new ListNode(2);
			ListNode *loop_start = head->next;
			ListNode *current = loop_start;
			current->next = new ListNode(3); current = current->next;
			current->next = new ListNode(4); current = current->next;
			//end loop
			current->next = loop_start;

			Solution_P141 *s = new Solution_P141();

			// trigger
			auto result = s->hasCycle(head);

			// test
			Assert::IsTrue(result);
		}
		// t: 2:35 PM
	};
}