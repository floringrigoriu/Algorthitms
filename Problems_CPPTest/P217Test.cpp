#include "stdafx.h"
#include "CppUnitTest.h"

#include "..\Problems_CPP\Solution_P217.h"
#include <string>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Problems_CPPTest
{
	TEST_CLASS(P217Test)
	{

	public:

		TEST_METHOD(TestBasicUnique)
		{
			Solution_P217 *solution = new Solution_P217();

			std::vector<int> input = {1, 10 , 2, 9 , 3, 8, 4, 7, 5, 6};
			
			Assert::AreEqual(false, solution->containsDuplicate(input));

			delete(solution);
		}

		TEST_METHOD(TestBasicDuplicate)
		{
			Solution_P217 *solution = new Solution_P217();

			std::vector<int> input = { 1, 7, 5, 6 , 1 };

			Assert::AreEqual(true, solution->containsDuplicate(input));

			delete(solution);
		}
	};
}