using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // ***************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // ***************
    public static class ModuloSum
    {
        #region YOUR CODE IS HERE    

        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// Fill this function to check whether there's a subsequence numbers in the given array that their sum is divisible by M
        /// </summary>
        /// <param name="items">array of integers</param>
        /// <param name="N">array size </param>
        /// <param name="M">value to check against it</param>
        /// <returns>true if there's subsequence with sum divisible by M... false otherwise</returns>
        /// 

        static List<int[]> table;
        static int[] arr;
        static public bool SolveValue(int[] items, int N, int M)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            // Create a set to store all the possible remainders
            //HashSet<int> remainders = new HashSet<int>();
            //remainders.Add(0);
            //for (int i = 0; i < N; i++)
            //{
            //    HashSet<int> newRemainders = new HashSet<int>();
            //    foreach (int remainder in remainders)
            //    {
            //        int newRemainder = (remainder + items[i]) % M;
            //        if (newRemainder == 0)
            //        {
            //            return true;
            //        }
            //        newRemainders.Add(newRemainder);
            //    }
            //    remainders.UnionWith(newRemainders);
            //}

            //return false;

            table = Enumerable.Repeat<int[]>(null, M + 1).ToList();
            int[] tmp = new int[items.Length];
            Array.Copy(items, tmp, items.Length);
            for (int i = 0; i < N; i++)
            {
                tmp[i] = tmp[i] % M;
                if (tmp[i] == 0)
                {
                    arr = new int[] { items[i] };
                    return true;
                }
            }
            Array.Sort(tmp);
            table[0] = Array.Empty<int>();
            int k = 0;
            for (int i = 0; i <= M; i++)
            {
                if (table[i] != null)
                {
                    for (int j = k; j < N; j++)
                    {
                        if (i + tmp[j] <= M)
                        {
                            table[i + tmp[j]] = new int[table[i].Length + 1]; ;
                            Array.Copy(table[i], table[i + tmp[j]], table[i].Length);
                            table[i + tmp[j]][table[i + tmp[j]].Length - 1] = j;
                        }
                    }
                    k++;
                }
            }
            if (table[M] != null)
            {
                arr = new int[table[M].Length];
                int i = 0;
                foreach (var item in table[M])
                {
                    arr[i] = items[item];
                    i++;
                }
            }
            else arr = null;
            if (table[M] == null) return false;
            return true;

        }
        #endregion

        #region FUNCTION#2: Construct the Solution
        //Your Code is Here:
        //==================
        /// <returns>if exists, return the numbers themselves whose sum is divisible by ‘M’ else, return null</returns>
        static public int[] ConstructSolution(int[] items, int N, int M)
        {
            Dictionary<int, List<int>> remainders = new Dictionary<int, List<int>>();
            remainders.Add(0, new List<int>());
            for (int i = 0; i < N; i++)
            {
                Dictionary<int, List<int>> newRemainders = new Dictionary<int, List<int>>();
                foreach (KeyValuePair<int, List<int>> pair in remainders)
                {
                    int remainder = pair.Key;
                    List<int> itemsList = pair.Value;

                    int newRemainder = (remainder + items[i]) % M;
                    if (newRemainder == 0)
                    {
                        itemsList.Add(items[i]);
                        return itemsList.ToArray();
                    }

                    if (!newRemainders.ContainsKey(newRemainder))
                    {
                        newRemainders.Add(newRemainder, new List<int>());
                    }
                    List<int> newItemsList = new List<int>(itemsList);
                    newItemsList.Add(items[i]);
                    newRemainders[newRemainder] = newItemsList;
                }
                foreach (KeyValuePair<int, List<int>> pair in newRemainders)
                {
                    int remainder = pair.Key;
                    List<int> itemsList = pair.Value;

                    if (!remainders.ContainsKey(remainder))
                    {
                        remainders.Add(remainder, new List<int>());
                    }
                    remainders[remainder] = itemsList;
                }
            }

            return null; 
            //return arr;

        }
        #endregion
        #endregion

    }
}