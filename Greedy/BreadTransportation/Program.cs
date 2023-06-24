namespace BreadTransportation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // each one in the array decides how much bread he wants to sell or buy
            // array overall summ is 0
            // find min transports to do 
            // to transport from index i = j it equals i - j
            // this is a summary for the problem

            //int[] arr = new int[] { 5, -4, 1, -3, 1 };
            int[] arr = new int[] { -1000, -1000, -1000, 1000, 1000, 1000 };
            int i = -1, j = -1;
            for (int k = 0; k < arr.Length; k++)
            {
                if (i == -1 && arr[k] > 0) i = k;
                if(j == -1 && arr[k] < 0) j = k;
            }
            int answer = 0;
            while (i < arr.Length && j < arr.Length)
            {
                if (Math.Abs(arr[i]) < Math.Abs(arr[j]))
                {
                    answer += arr[i] * Math.Abs(j - i);
                    arr[j] += arr[i];
                    arr[i] = 0;
                    while (i < arr.Length && arr[i] <= 0)
                        i++;
                }
                else
                {
                    answer += Math.Abs(arr[j]) * Math.Abs(j - i);
                    arr[i] += arr[j];
                    arr[j] = 0;
                    while (j < arr.Length && arr[j] >= 0)
                        j++;
                }

            }
            Console.WriteLine(answer);
            Console.ReadLine();
        }
    }
}