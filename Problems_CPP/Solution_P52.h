/*Follow up for N - Queens problem.

Now, instead outputting board configurations, return the total number of distinct solutions.
*/

#include "stdafx.h"

class Solution_P52 {


public:

	private:
		int n; // size of the problem
		int solutions = 0;
		int *solution;
		bool *col_covered;

public :
	int totalNQueens(int n) {

		this->n = n;
		this->solution = new int[n];
		this->col_covered = new bool[n];
		for (int i=0; i < n; i++){
			col_covered[i] = false;
		}

		this->countInnnerSolution(0);
		return this->solutions;
	}

private :
	void countInnnerSolution(int level){
		if (level == this->n) {
			// solution found !;
			this->solutions++;
		}

		for (int row = 0; row < this->n; row++) {
			if (this->is_valid(row,level)) {
				this->solution[level] = row;
				this->col_covered[row] = true;
				this->countInnnerSolution(level + 1);
				this->col_covered[row] = false;
			}
		}
	}

	bool is_valid(int row, int col) {
		if (this->col_covered[row]) { return false; }
		// check diagonals
		for (int c = 0; c < col; c++) {
			if (abs(c - col) == abs(solution[c] - row)) {
				return false;
			}
		}

		// no conflicts :
		return true;
	}
};