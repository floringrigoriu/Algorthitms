
// https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/541/week-3-june-15th-june-21st/3367/


/**
 * 
 * The demons had captured the princess (P) and imprisoned her in the bottom-right corner of a dungeon. The dungeon consists of M x N rooms laid out in a 2D grid. Our valiant knight (K) was initially positioned in the top-left room and must fight his way through the dungeon to rescue the princess.

The knight has an initial health point represented by a positive integer. If at any point his health point drops to 0 or below, he dies immediately.

Some of the rooms are guarded by demons, so the knight loses health (negative integers) upon entering these rooms; other rooms are either empty (0's) or contain magic orbs that increase the knight's health (positive integers).

In order to reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step.

 

Write a function to determine the knight's minimum initial health so that he is able to rescue the princess.

For example, given the dungeon below, the initial health of the knight must be at least 7 if he follows the optimal path RIGHT-> RIGHT -> DOWN -> DOWN.

-2 (K)	-3	3
-5	-10	1
10	30	-5 (P)
 

Note:

The knight's health has no upper bound.
Any room can contain threats or power-ups, even the first room the knight enters and the bottom-right room where the princess is imprisoned.
 */

public class p21 {

    
    class Solution {
        public int calculateMinimumHP(int[][] dungeon) {
            int m = dungeon.length;
            int n = dungeon[0].length;
            for (int d = m+n-3;d>=0 ; d-- ) {
                for(int i = Math.max(0, d- m +1), j = Math.min(m-1, d); i< n && j >=0; i++, j --) {
                    if (j== m-1) {
                        if(dungeon[j][i+1]<=0) {
                            dungeon[j][i] += dungeon[j][i+1] ;
                        }
                    } else if(i==n-1) {
                        if(dungeon[j+1][i]<=0) {
                            dungeon[j][i] += dungeon[j+1][i] ;
                        }
                    } else {
                        int other = Math.max(dungeon[j][i+1],dungeon[j+1][i] );
                        if(other<=0) {
                            dungeon[i][j] += other;
                        }
                    }
                }
            }
            return (-1) * Math.min(0, dungeon[0][0]) +1;
        }
    }
}