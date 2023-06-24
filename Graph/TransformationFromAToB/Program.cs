namespace TransformationFromAToB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32 (Console.ReadLine());
            int b = Convert.ToInt32 (Console.ReadLine());

            short flag = -1;

            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            queue.Enqueue(a);
            visited.Add(a);

            while (queue.Count > 0) {
                int tmp = queue.Dequeue();
                if(tmp == b)
                {
                    flag = 1;
                    break;
                }

                int tmp1 = tmp * 2;
                int tmp2 = (tmp * 10) + 1;
                
                if(!visited.Contains(tmp1) && tmp1 <= b)
                {
                    queue.Enqueue(tmp1);
                    visited.Add(tmp1);
                }
             
                if (!visited.Contains(tmp2) && tmp2 <= b)
                {
                    queue.Enqueue(tmp2);
                    visited.Add(tmp2);
                }
            }
            Console.WriteLine(flag);
        }
    }
}