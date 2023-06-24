using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class MaxDrop
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Calculate the max drop in the given financial records over weeks
        /// </summary>
        /// <param name="array">array of financial records (earnings/losses) over weeks</param>
        /// <returns>max drop over all weeks</returns>
        static public int FindMaxDrop(int N, short[] array)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();

            int min = int.MaxValue;
            int answer = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                //Console.WriteLine(array[i]);
                if (i < array.Length - 1)
                {
                    //Console.WriteLine(answer + " " +  min);
                    answer = Math.Max(answer, (array[i] - min));
                }
                min = Math.Min(array[i], min);
            }
            return answer;


            // Why divide and conquer solution gets time limit while its O(N/2)
            // and this solution is O(N) and gets 100%?
            //return Helper(0, N - 1, array)[2];

        }
        static public int[] Helper(int s, int e, short[] a)
        {
            
            if (s == e)
            {
                int[] arr = new int[3];
                arr[0] = a[e];
                arr[1] = a[e];
                arr[2] = 0;
                return arr;
            }
            int m = (s + e) / 2;

            int[] b = new int[3];
            int[] c = new int[3];
            //Thread t1 = new Thread(() => { b = Helper(s, m, a); });
            //Thread t2 = new Thread(() => { c = Helper(m + 1, e, a); });
            //t1.Name = "t1";
            //t2.Name = "t2";
            //t1.Start();
            //t2.Start();
            //t1.Join();
            //t2.Join();

            Task<int[]> task1 = Task<int[]>.Factory.StartNew(() => { return Helper(s, m, a); });
            Task<int[]> task2 = Task<int[]>.Factory.StartNew(() => { return Helper(m + 1, e, a); });
            Task.WaitAll(task1, task2);
            b = task1.Result;
            c = task2.Result;

            //Parallel.Invoke(
            //    () => b = Helper(s, m, a),
            //    () => c = Helper(m + 1, e, a)
            //);

            //b = Helper(s, m, a);
            //c = Helper(m + 1, e, a);
            int[] answer = new int[3];
            answer[0] = Math.Min(b[0], c[0]);
            answer[1] = Math.Max(b[1], c[1]);
            answer[2] = Math.Max(Math.Max(b[2], c[2]), b[1] - c[0]);
            //Console.WriteLine(answer[0] + " " + answer[1] + " " + answer[2]);
            return answer;   
        }
     
        #endregion
    }
}
