//
#include "stdafx.h"
//#include "UnitTestUtil.h"
//#include "CppUnitTest.h"
//#include <vector>
//
//using namespace Microsoft::VisualStudio::CppUnitTestFramework;
//using namespace std;
//
//template<typename T> static void UnitTestUtil::AreCollectionEqual(
//	vector<T> expected, 
//	vector<T> actual, 
//	const wchar_t* message){
//
//	if (expected == NULL && actual == NULL) {
//		return; // null both : all is well
//	}
//
//	if (expected == NULL) {
//		Assert::Fail("Expected value not null");
//	}
//
//	if (actual == NULL) {
//		Assert::Fail("Expected value is null");
//	}
//	
//	Assert::AreSame(expected.size(), actual.size(), L"the expected lenght differen from actual lenght");
//	for (int i = 0; i < expected.size(); i++)
//	{
//		Assert::AreSame(expected[i], actual[i], message);
//	}
//}
