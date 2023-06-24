using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class AliBabaInParadise
    {
        #region YOUR CODE IS HERE
        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given the Camels maximum load and N items, each with its weight and profit 
        /// Calculate the max total profit that can be carried within the given camels' load
        /// </summary>
        /// <param name="camelsLoad">max load that can be carried by camels</param>
        /// <param name="itemsCount">number of items</param>
        /// <param name="weights">weight of each item</param>
        /// <param name="profits">profit of each item</param>
        /// <returns>Max total profit</returns>
        /// 

        static int[] selectedWeights;
        static Dictionary<int, int> UniqueSelectedWeights = new Dictionary<int, int>();
        static public int SolveValue(int camelsLoad, int itemsCount, int[] weights, int[] profits)
        {
            if (weights.Min() > camelsLoad) return 0;
            selectedWeights = new int[camelsLoad + 1];
            return helperTabu(camelsLoad, itemsCount, weights, profits, selectedWeights);   
        }
        #endregion
        static public int helperMemo(int camelsLoad, int itemsCount, int[] weights, int[] profits, int[] selectedWeights, Dictionary<int, int> memo = null)
        {
            if(memo == null)    memo = new Dictionary<int, int>();
            if(memo.ContainsKey(camelsLoad)) return memo[camelsLoad];
            if (camelsLoad == 0) return 0;
            int maxi = 0;
            int b = -1;
            for (int i = 0; i < itemsCount; i++)
            {
                if (camelsLoad - weights[i] < 0)
                    continue;
                int tmp = helperMemo(camelsLoad - weights[i], itemsCount, weights, profits, selectedWeights) + profits[i];
                if (tmp > maxi)
                {
                    maxi = tmp;
                    b = i;
                }
            }
            if(b != -1)
                selectedWeights[camelsLoad] = b;
            memo.Add(camelsLoad, maxi);
            return memo[camelsLoad];
        }
        static public int helperTabu(int camelsLoad, int itemsCount, int[] weights, int[] profits, int[] selectedWeights)
        {
            int[] memo = new int[camelsLoad + 1];

            for (int i = 1; i <= camelsLoad; i++)
            {
                int maxi = 0;
                int b = -1;
                for (int j = 0; j < itemsCount; j++)
                {
                    if (i - weights[j] < 0)
                        continue;
                    int tmp = memo[i - weights[j]] + profits[j];
                    if (tmp > maxi)
                    {
                        maxi = tmp;
                        b = j;
                    }
                }
                if (b != -1)
                    selectedWeights[i] = b;
                memo[i] = maxi;
            }

            return memo[camelsLoad];
        }


        static void BackTrackSW(int camelsLoad, int[] selectedWeights, int[] weights)
        {
            if (camelsLoad - weights[selectedWeights[camelsLoad]] < 0) return;
            if (UniqueSelectedWeights.ContainsKey(selectedWeights[camelsLoad])) UniqueSelectedWeights[selectedWeights[camelsLoad]]++;
            else UniqueSelectedWeights.Add(selectedWeights[camelsLoad], 1);
            BackTrackSW(camelsLoad - weights[selectedWeights[camelsLoad]], selectedWeights, weights);
        }
        #region FUNCTION#2: Construct the Solution
        //Your Code is Here:
        //==================
        /// <returns>Tuple array of the selected items to get MAX profit (stored in Tuple.Item1) together with the number of instances taken from each item (stored in Tuple.Item2)
        /// OR NULL if no items can be selected</returns>
        static public Tuple<int, int>[] ConstructSolution(int camelsLoad, int itemsCount, int[] weights, int[] profits)
        {
            if (weights.Min() > camelsLoad) return null;
            UniqueSelectedWeights.Clear();
            BackTrackSW(camelsLoad, selectedWeights, weights);
            Tuple<int, int>[] UniqueSelectedWeightsTuples = UniqueSelectedWeights
                .Select(pair => Tuple.Create(pair.Key, pair.Value))
                .ToArray();
            return UniqueSelectedWeightsTuples;
        }
        #endregion
        #endregion
    }
}
