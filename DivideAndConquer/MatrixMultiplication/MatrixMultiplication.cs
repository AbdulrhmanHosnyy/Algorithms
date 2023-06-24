using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class MatrixMultiplication
    {
        #region YOUR CODE IS HERE

        //Your Code is Here:
        //==================
        /// <summary>
        /// Multiply 2 square matrices in an efficient way [Strassen's Method]
        /// </summary>
        /// <param name="M1">First square matrix</param>
        /// <param name="M2">Second square matrix</param>
        /// <param name="N">Dimension (power of 2)</param>
        /// <returns>Resulting square matrix</returns>
        /// 

        static public int[,] MatrixMultiply(int[,] M1, int[,] M2, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();

            // Naive Solution
            // --------------

            //int[,] answer = new int[N, N];
            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < N; j++)
            //    {
            //        for (int k = 0; k < N; k++)
            //        {
            //            answer[i, j] += M1[i, k] * M2[k, j];
            //        }
            //    }
            //}

            // Straseen's Solution
            // --------------------
            int[,] M3 = new int[N, N];
            if (N <= 64)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < N; k++)
                        {
                            M3[i, j] += M1[i, k] * M2[k, j];
                        }
                    }
                }
            }
            else
            {
                int n = N / 2;
                int[,] a = new int[n, n];
                int[,] b = new int[n, n];
                int[,] c = new int[n, n];
                int[,] d = new int[n, n];
                int[,] e = new int[n, n];
                int[,] f = new int[n, n];
                int[,] g = new int[n, n];
                int[,] h = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = M1[i, j];
                        b[i, j] = M1[i, j + n];
                        c[i, j] = M1[i + n, j];
                        d[i, j] = M1[i + n, j + n];

                        e[i, j] = M2[i, j];
                        f[i, j] = M2[i, j + n];
                        g[i, j] = M2[i + n, j];
                        h[i, j] = M2[i + n, j + n];
                    }
                }

                int[,]P1 = MatrixMultiply(a, Subtraction(f, h, n), n);
                int[,]P2 = MatrixMultiply(Addition(a, b, n), h, n);
                int[,]P3 = MatrixMultiply(Addition(c, d, n), e, n);
                int[,]P4 = MatrixMultiply(d, Subtraction(g, e, n), n);
                int[,]P6 = MatrixMultiply(Subtraction(b, d, n), Addition(g, h, n), n);
                int[,]P7 = MatrixMultiply(Subtraction(a, c, n), Addition(e, f, n), n);
                int[,]P5 = MatrixMultiply(Addition(a, d, n), Addition(e, h, n), n);


                int[,] r = new int[n, n];
                int[,] s = new int[n, n];
                int[,] t = new int[n, n];
                int[,] u = new int[n, n];

                r = Addition(Subtraction(Addition(P5, P4, n), P2, n), P6, n);
                s = Addition(P1, P2, n);
                t = Addition(P3, P4, n);
                u = Subtraction(Subtraction(Addition(P5, P1, n), P3, n), P7, n);


                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        M3[i, j] = r[i, j];
                        M3[i, j + n] = s[i, j];
                        M3[i + n, j] = t[i, j];
                        M3[i + n, j + n] = u[i, j];
                    }
                }
            }
            return M3;
        }

        //Addition of two matricees
        static public int[,] Addition(int[,] A, int[,] B, int N)
        {
            int[,] C = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
        }

        // Subtraction of two mtricies
        static public int[,] Subtraction(int[,] A, int[,] B, int N)
        {
            int[,] C = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    C[i, j] = A[i, j] - B[i, j];
                }
            }
            return C;
        }
        #endregion
    }
}
