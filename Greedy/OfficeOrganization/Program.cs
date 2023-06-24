namespace OfficeOrganization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Your office becomes full of documents. You currently have N units of documents on your
            // office, and your father demands that you have exactly M units of documents left by the end
            // of the day.The only hope for you now is to ask help from your brother and sister
            // Your sister offers that she can reduce your documents by half for $A 
            // Your brother offers that he can reduce your entire documents by one unit for $B
            // Note that work can never be reduced to less than 0.
            // Given N, M, A and B, your task is to find the minimum costs in MOST EFFICIENT WAY to organize your office to meet your father needs.

            int n = 100, m = 5, a = 10, b = 1;
            //int n = 100, m = 5, a = 5, b = 2;

            int answer = 0;

            while(!(n == m))
            {

                int tmp = n / 2;
                if(tmp < m)
                {
                    answer += b;
                    n -= 1;
                }
                else if(a > (tmp + 1 * b))
                {
                    answer += b;
                    n -= 1;
                }
                else
                {
                    answer += a;
                    n /= 2;
                }
                Console.WriteLine(n);
            }
            Console.WriteLine($"Min cost is: {answer}");
        }
    }
}