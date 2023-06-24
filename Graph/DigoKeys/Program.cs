namespace DigoKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Dictionary<int, List<int>> keys = new Dictionary<int, List<int>>();

            for (int i = 1; i < n; i++)
            {
                int m = Convert.ToInt32(Console.ReadLine());
                

                while (m > 0)
                {
                    int box = Convert.ToInt32(Console.ReadLine());
                    if (keys.ContainsKey(i)) keys[i].Add(box);
                    else
                    {
                        keys.Add(i, new List<int>());
                        keys[i].Add(box);
                    }
                    m--;
                }
            }

            var parent = Enumerable.Range(2, (n + 1)).Select(i => -1).ToList();
            parent[1] = 0;

        
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            bool result = false;
            while (queue.Count > 0)
            {
                int index = queue.Dequeue();
                foreach (var box in keys[index])
                {
                    if (parent[box] == -1)
                    {
                        parent[box] = index;
                        if (box == n)
                        {
                            result = true;
                            break;
                        }
                        queue.Enqueue(box);
                    }
                }
                if (result) break;
            }
            Console.WriteLine();
            if (result == false) Console.WriteLine("Not Found!!");
            else
            {
                for (int j = parent[n]; j != 0; j = parent[j]) Console.WriteLine(j);
            }


            Console.WriteLine();
        }
    }
}