// P136_SingleNumber.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include "Header.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	cout << "Hellow world" << endl;
	Solution *s = new Solution();
	vector<int> *test = new vector<int>();
	test->push_back(1);
	test->push_back(5);
	test->push_back(1);

	cout << "solution : " << s->singleNumber(*test);
	delete(s);
	return 0;
}

