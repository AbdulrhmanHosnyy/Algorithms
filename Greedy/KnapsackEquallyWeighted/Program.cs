namespace KnapsackEquallyWeighted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5, w = 22, itemWeight = 6;
            int[] costs = new int[] { 5, 9, 3, 7, 8 };
            Array.Sort(costs);
            Array.Reverse(costs);
            int i = 0;
            int answer = 0;
            while (itemWeight <= w)
            {
                w -= itemWeight;
                answer += costs[i];
                i++;
            }
            Console.WriteLine("Maximum benefit: " + answer);

            Console.ReadLine();
        }
    }
}