// Unmanaged.cpp : Defines the entry point for the console application.
//
// NOTE : this code is hardware specific
//

#include "stdafx.h"
#include <stdlib.h>
#include <iostream>
#include <intrin.h>

using namespace std;

extern "C" __declspec(dllexport) int AsmPopulationCount(int num);

extern "C" __declspec(dllexport) int AsmPopulationCount64(__int64 num);

extern "C" __declspec(dllexport) int AsmPopulationCountArray(int* data, int size);

// C binary exposing function to access POPCNT and other intrinsecs 
// in order to use hardware optimization for fast operations
//
int _tmain(int argc, _TCHAR* argv[])
{
	int* inputArray = new int [4];
	inputArray[0] = 0x55555555;
	inputArray[1] = 0x55555555;
	inputArray[2] = 0x55555555;
	inputArray[3] = 0x55555555;
	
	cout << "Hello world" << endl;
	cout << "32 Bit population count " << AsmPopulationCount(0x55555555)<< endl;
	cout << "64 Bit population count " << AsmPopulationCount64(0x5555555555555555L)<< endl;
	cout << "128 Bit population count " << AsmPopulationCountArray(inputArray,4)<< endl;
	return 0;
}

// Do a pop count on an int 32
//
extern "C" __declspec(dllexport) int AsmPopulationCount(int num)
{
    
	unsigned int retVal;

	retVal = __popcnt((unsigned int)num);
	/*
	of following asm code - inline assembly is not available on x64
	_asm {
		POPCNT    eax, num
		mov retVal, eax
	}
*/
	return retVal;

}

// Do a pop count on an int 64
//

extern "C" __declspec(dllexport) int AsmPopulationCount64(__int64 num)
{
    
	int retVal =0;
	retVal = __popcnt64((unsigned _int64)num);
	/*
	of following asm code

	_asm {
		popcnt    rax, num
		mov retVal, rax
	}*/

	return retVal;

}

// TODO : Pop count on MMX / SSE intrinsecs
//
extern "C" __declspec(dllexport) int AsmPopulationCountArray(int* data, int size)
{
	int retVal =0;
	for(int index =0 ;index < size; index++)
	{
		retVal += 	__popcnt(data[index]);
	}
	return retVal;
}
