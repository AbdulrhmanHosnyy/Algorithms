using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{

    public static class PathBetweenNumbers
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given two numbers X and Y, find the min number of operations to convert X into Y
        /// Allowed Operations:
        /// 1.	Multiply the current number by 2 (i.e. replace the number X by 2 × X)
        /// 2.	Subtract 1 from the current number (i.e. replace the number X by X – 1)
        /// 3.	Append the digit 1 to the right of current number (i.e. replace the number X by 10 × X + 1).
        /// </summary>
        /// <param name="X">start number</param>
        /// <param name="Y">target number</param>
        /// <returns>min number of operations to convert X into Y</returns>
        public static int Find(int X, int Y)
        {
            //REMOVE THIS LINE BEFORE START CODING
            if (X > Y) return X - Y;
            if (X == Y) return 0;
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
            HashSet<int> visited = new HashSet<int>();
            queue.Enqueue(new KeyValuePair<int, int>(X, 0));
            visited.Add(X);
            while (true)
            {
                KeyValuePair<int, int> it = queue.Dequeue();
                if (it.Key == Y)
                {
                    return it.Value;
                }
                int value = it.Value;
                int op1 = it.Key * 2;
                int op2 = it.Key - 1;
                int op3 = (it.Key * 10) + 1;
                if (it.Key > Y)
                {
                    if (op2 <= Y + 1 && !visited.Contains(op2))
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(op2, value + 1));
                        visited.Add(op2);
                    }
                }
                else
                {
                    if (op1 <= Y + 1 && !visited.Contains(op1))
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(op1, value + 1));
                        visited.Add(op1);
                    }
                    if (op2 <= Y + 1 && !visited.Contains(op2))
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(op2, value + 1));
                        visited.Add(op2);
                    }
                    if (op3 <= Y + 1 && !visited.Contains(op3))
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(op3, value + 1));
                        visited.Add(op3);
                    }
                }
            }
        }

        #endregion

    }
}
