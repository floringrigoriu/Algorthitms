// Problems_CPP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Solution_P191.h"


#include "iostream"
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	Solution_P191 *s = new Solution_P191();
	cout << "hello world: "<< s->hammingWeight(0xfec80731);
	return 0;
}

