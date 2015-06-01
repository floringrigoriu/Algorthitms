#include "stdafx.h"
#include "Solution_P191.h"

int Solution_P191::hammingWeight(uint32_t n) {
	uint32_t result=0;
	// sum bit 0-1 , 2-3, 4-5 ,....30-31;
	const uint32_t mask_1 = 0x55555555;
	result = (n & mask_1) + ((n >> 1) & mask_1);

	// sum bit 0-3, 4- 7,... 28-31
	const uint32_t mask_2 = 0x33333333;
	result = (result & mask_2) + ((result >> 2) & mask_2);

	// sum bit 0-7, 8- 15 15-23, 24-31
	const uint32_t mask_3 = 0x0f0f0f0f;
	result = (result & mask_3) + ((result >> 4) & mask_3);

	// sum bit 0-15, 15 31  - mask not needed
	result = result + (result >> 8);

	// sum bit 0-31 mask not needed
	result = result + (result >> 16);

	return result & 0x3f;// pick last 6 bits for result
}