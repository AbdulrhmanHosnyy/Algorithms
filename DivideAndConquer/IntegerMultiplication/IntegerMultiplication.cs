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
    public static class IntegerMultiplication
    {
        #region YOUR CODE IS HERE

        //Your Code is Here:
        //==================
        /// <summary>
        /// Multiply 2 large integers of N digits in an efficient way [Karatsuba's Method]
        /// </summary>
        /// <param name="X">First large integer of N digits [0: least significant digit, N-1: most signif. dig.]</param>
        /// <param name="Y">Second large integer of N digits [0: least significant digit, N-1: most signif. dig.]</param>
        /// <param name="N">Number of digits (power of 2)</param>
        /// <returns>Resulting large integer of 2xN digits (left padded with 0's if necessarily) [0: least signif., 2xN-1: most signif.]</returns>
        static public byte[] IntegerMultiply(byte[] X, byte[] Y, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            var answer = new byte[N * 2];
            for (int i = N - 1; i >= 0; i--)
            {
                var tmp = new byte[N * 2];
                int carry = 0;
                for (int j = N - 1; j >= 0; j--)
                {
                    int product = X[j] * Y[i] + carry + answer[i + j + 1];
                    answer[i + j + 1] = (byte)(product % 10);
                    carry = product / 10;
                }
                answer[i] += (byte)carry;
                foreach (var item in tmp)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                //AddArrays(ref answer, ref tmp, N * 2);
            }
            Array.Reverse(answer);
            return answer;

        }
        static private void AddArrays(ref byte[] X, ref byte[] Y, int N)
        {
            byte[] result = new byte[N];
            int carry = 0;
            for (int i = N - 1; i >= 0; i--)
            {
                int sum = X[i] + Y[i] + carry;
                result[i] = (byte)(sum % 10);
                carry = sum / 10;
            }
            if (carry > 0)
            {
                // If there is a carry after the loop, prepend it to the result
                byte[] newResult = new byte[N + 1];
                newResult[0] = (byte)carry;
                Array.Copy(result, 0, newResult, 1, N);
                result = newResult;
            }
            //foreach (var item in result)
            //{
            //    Console.Write(item);
            //}
            //Console.WriteLine();
            X = result;
        }

        #endregion
    }
}
