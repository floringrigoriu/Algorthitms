#include "stdafx.h"
#include "CppUnitTest.h"

#include "..\Problems_CPP\Solution_P171.h"
#include <string>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Problems_CPPTest
{
	TEST_CLASS(P171Test)
	{

	public:

		TEST_METHOD(TestBasic)
		{
			Solution_P171 *solution = new Solution_P171();

			string input = "A";
			Assert::AreEqual(1, solution->titleToNumber(input));

			input = "P";
			Assert::AreEqual(16, solution->titleToNumber(input));
			
			input = "AA";
			Assert::AreEqual(27, solution->titleToNumber(input));

			input = "AB";
			Assert::AreEqual(28, solution->titleToNumber(input));

			delete(solution);
		}
	};
}