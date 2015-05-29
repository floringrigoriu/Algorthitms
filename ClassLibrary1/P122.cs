using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Solution_P122_MaxProfit
    {
        public int MaxProfit(int[] prices)
        {
            int result = 0;
            for (int i = 0; i < prices.Length - 1; i++) {
                int delta = prices[i + 1] - prices[i];
                if (delta > 0) {
                    result += delta;
                }
            }
            return result;

        }
    }
}
