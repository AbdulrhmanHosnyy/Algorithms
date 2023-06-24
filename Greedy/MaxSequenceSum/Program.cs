namespace MaxSequenceSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 31, -41, 59, 26, -53, 58, 97, -93, -23, 84};

            int sum = 0, maxi = 0;
            int start = 0, end = 0;
            int tmp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (sum < 0)
                {
                    sum = 0;
                    tmp = i + 1;
                }
                if(sum > maxi)
                {
                    maxi = sum;
                    start = tmp;
                    end = i;
                }
            }
            Console.WriteLine(start + " " + end);
            Console.WriteLine(maxi);
        }
    }
}