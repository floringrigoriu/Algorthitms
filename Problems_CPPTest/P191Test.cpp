#include "stdafx.h"
#include "CppUnitTest.h"

#include "..\Problems_CPP\Solution_P191.h"
#include <stdint.h>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace Problems_CPPTest
{		
	TEST_CLASS(P191Test)
	{
	
	public:
		
		TEST_METHOD(TestMin)
		{
			Solution_P191 *solution = new Solution_P191();
			uint32_t input = 0x0;
			Assert::AreEqual(0, solution->hammingWeight(input));
			delete(solution);
		}

		TEST_METHOD(TestMax)
		{
			Solution_P191 *solution = new Solution_P191();
			uint32_t input = 0x0 - 1;
			Assert::AreEqual(32, solution->hammingWeight(input));
			delete(solution);
		}

		TEST_METHOD(TestGeneralCase)
		{
			Solution_P191 *solution = new Solution_P191();
			uint32_t input = 0xfec80731;
			Assert::AreEqual(16, solution->hammingWeight(input));
			delete(solution);
		}

	};
}