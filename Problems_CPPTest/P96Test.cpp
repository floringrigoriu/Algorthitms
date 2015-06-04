#include "stdafx.h"
#include "CppUnitTest.h"
#include "..\Problems_CPP\Solution_P96.h"


using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace Problems_CPPTest
{
	TEST_CLASS(P96Test)
	{
	public:
		
		TEST_METHOD(NumTreeCounter)
		{
			// build solver
			Solution_P96 *s = new Solution_P96();

			// validate solutions
			Assert::AreEqual(1, s->numTrees(1));

			Assert::AreEqual(2, s->numTrees(2));

			Assert::AreEqual(5, s->numTrees(3));

			Assert::AreEqual(14, s->numTrees(4));

			Assert::AreEqual(42, s->numTrees(5));
		}

	};
}