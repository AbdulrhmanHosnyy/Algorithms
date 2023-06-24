using Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Problem
{

    public class Problem : ProblemBase, IProblem
    {
        #region ProblemBase Methods
        public override string ProblemName { get { return "MaxDrop"; } }

        public override void TryMyCode()
        {
            int N = 0 ;
            int output, expected;
            
            //All -ve's
            N = 5;
            short[] arr1 = { -1, -4, -5, -3, -2 };
            expected = 4;
            output = MaxDrop.FindMaxDrop(N, arr1);
            PrintCase(N, arr1, output, expected);

            //All +ve's
            N = 5;
            short[] arr2 = { 1, 6, 3, 4, 2 };
            expected = 4;
            output = MaxDrop.FindMaxDrop(N, arr2);
            PrintCase(N, arr2, output, expected);

            N = 5;
            short[] arr3 = { 1, 6, 3, 4, -1 };
            expected = 7;
            output = MaxDrop.FindMaxDrop(N, arr3);
            PrintCase(N, arr3, output, expected);

            //Alternating
            N = 5;
            short[] arr4 = { 1, -6, 3, -4, 1 };
            expected = 7;
            output = MaxDrop.FindMaxDrop(N, arr4);
            PrintCase(N, arr4, output, expected);

            //No Drop
            N = 5;
            short[] arr5 = { 5, 7, 9, 17, 23 };
            expected = 0;
            output = MaxDrop.FindMaxDrop(N, arr5);
            PrintCase(N, arr5, output, expected);
            
            //Identical
            N = 5;
            short[] arr6 = { -1, -1, -1, -1, -1 };
            expected = 0;
            output = MaxDrop.FindMaxDrop(N, arr6);
            PrintCase(N, arr6, output, expected);

        }

        Thread tstCaseThr;
        bool caseTimedOut ;
        bool caseException;

        protected override void RunOnSpecificFile(string fileName, HardniessLevel level, int timeOutInMillisec)
        {
            int testCases;
            int N = 0;
            short[] arr = null;
            int output, actualResult;

            Stream s = new FileStream(fileName, FileMode.Open);
            BinaryReader br = new BinaryReader(s);
   
            testCases = br.ReadInt32();

            int totalCases = testCases;
            int correctCases = 0;
            int wrongCases = 0;
            int timeLimitCases = 0;
 
            int i = 1;
            while (testCases-- > 0)
            {
                N = br.ReadInt32();
                arr = new short[N];
                for (int j = 0; j < N; j++)
                {
                    arr[j] = br.ReadInt16();
                }
                actualResult = br.ReadInt32();

                //Console.WriteLine("N = {0}, Res = {1}", N, actualResult);
                output = 0;
                caseTimedOut = true;
                caseException = false;
                {
                    tstCaseThr = new Thread(() =>
                    {
                        try
                        {
                            Stopwatch sw = Stopwatch.StartNew();
                            output = MaxDrop.FindMaxDrop(N, arr);
                            sw.Stop();
                            //Console.WriteLine("N = {0}, time in ms = {1}", arr.Length, sw.ElapsedMilliseconds);
                        }
                        catch
                        {
                            caseException = true;
                            output = int.MinValue;
                        }
                        caseTimedOut = false;
                    });

                    //StartTimer(timeOutInMillisec);
                    tstCaseThr.Start();
                    tstCaseThr.Join(timeOutInMillisec);
                }

                if (caseTimedOut)       //Timedout
                {
                    Console.WriteLine("Time Limit Exceeded in Case {0}.", i);
					tstCaseThr.Abort();
                    timeLimitCases++;
                }
                else if (caseException) //Exception 
                {
                    Console.WriteLine("Exception in Case {0}.", i);
                    wrongCases++;
                }
                else if (output == actualResult)    //Passed
                {
                    Console.WriteLine("Test Case {0} Passed!", i);
                    correctCases++;
                }
                else                    //WrongAnswer
                {
                    Console.WriteLine("Wrong Answer in Case {0}.", i);
                    Console.WriteLine(" your answer = " + output + ", correct answer = " + actualResult);
                    wrongCases++;
                }

                i++;
            }
            s.Close();
            br.Close();
            Console.WriteLine();
            Console.WriteLine("# correct = {0}", correctCases);
            Console.WriteLine("# time limit = {0}", timeLimitCases);
            Console.WriteLine("# wrong = {0}", wrongCases);
            Console.WriteLine("\nFINAL EVALUATION (%) = {0}", Math.Round((float)correctCases / totalCases * 100, 0)); 
        }

        protected override void OnTimeOut(DateTime signalTime)
        {
        }

        public override void GenerateTestCases(HardniessLevel level, int numOfCases)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helper Methods
        private static void PrintCase(int N, short[] arr, int output, int expected)
        {
            Console.WriteLine("N: {0}", N);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Output = " + output);
            Console.WriteLine("Expected = " + expected);
            Console.WriteLine();
        }
        #endregion
   
    }
}
