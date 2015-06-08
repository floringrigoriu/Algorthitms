#include "stdafx.h"
#include <vector>
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

class UnitTestUtil{

public:
	template<typename T> static void AreCollectionEqual(
		const vector<T> &expected,
		const vector<T> &actual,
		const wchar_t* message = NULL
	) {
		Assert::AreEqual(expected.size(), actual.size(), L"the expected lenght differen from actual lenght");
		for (int i = 0; i < expected.size(); i++)
		{
			Assert::AreEqual(expected[i], actual[i], message);
		}
	}
};
