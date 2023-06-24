using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class FindExtraElement
    {
        #region YOUR CODE IS HERE
        /// <summary>
        /// Find index of extra element in first array
        /// </summary>
        /// <param name="arr1">first sorted array with an extra element</param>
        /// <param name="arr2">second sorted array</param>
        /// <returns>index of the extra element in arr1</returns>
        public static int FindIndexOfExtraElement(int[] arr1, int[] arr2)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            if (arr1[arr1.Length - 2] == arr2[arr2.Length - 1]) return arr2.Length;
            if (arr1[0] != arr2[0]) return 0;
            int start = 0;
            int end = arr2.Length;
            int mid = 0;
            while(start < end)
            {
                mid = (start + end) / 2;
                if (arr1[mid] < arr2[mid])
                {
                    if (arr1[mid - 1] == arr2[mid - 1]) return mid;
                    else end = mid;
                } 
                else start = mid + 1;
            }
            return 0;
        }

        #endregion
    }
}
