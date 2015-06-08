#include "stdafx.h"
#include "CppUnitTest.h"
#include "..\Problems_CPP\Solution_P52.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace Problems_CPPTest
{
	TEST_CLASS(P52_test)
	{
	public:
		
		TEST_METHOD(TestQueensOn4size)
		{
			
			Solution_P52 *s = new Solution_P52();
			
			// get first solution :
			int solution = s->totalNQueens(4);
			Assert::AreEqual(2, solution);
			
			delete(s);
		}

	};
}