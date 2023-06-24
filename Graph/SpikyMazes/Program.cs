namespace SpikyMazes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int j = int.Parse(input[2]);

            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
            Dictionary<Tuple<int, int>, int> dic = new Dictionary<Tuple<int, int>, int>();

            char[,] maze = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int k = 0; k < m; k++)
                {
                    maze[i, k] = line[k];
                    if (line[k] == '@')
                    {
                        stack.Push(new Tuple<int, int>(i, k));
                        visited.Add(stack.Peek());
                        dic.Add(stack.Peek(), 0);
                    }
                }
            }

            Func<int , bool> rowInBounds = x => 0 <= x && x < n;
            Func<int , bool> colInBounds = x => 0 <= x && x < m;
            int answer = int.MaxValue;
            while (stack.Count > 0)
            {
                var tmp = stack.Pop();
                if (maze[tmp.Item1, tmp.Item2] == 'x')
                {
                    answer = Math.Min(answer, dic[tmp]);
                }
                if(rowInBounds(tmp.Item1 - 1) && colInBounds(tmp.Item2) && !visited.Contains(new Tuple<int, int>(tmp.Item1 - 1, tmp.Item2)))
                {
                    if (maze[tmp.Item1 - 1, tmp.Item2] == 's')
                    {
                        stack.Push(new Tuple<int, int>(tmp.Item1 - 1, tmp.Item2));
                        visited.Add(stack.Peek());
                        dic.Add(new Tuple<int, int>(tmp.Item1 - 1, tmp.Item2), dic[tmp] + 1);
                    }
                    if (maze[tmp.Item1 - 1, tmp.Item2] == '.' || maze[tmp.Item1 - 1, tmp.Item2] == 'x')
                    {
                        stack.Push(new Tuple<int, int>(tmp.Item1 - 1, tmp.Item2));
                        visited.Add(stack.Peek());
                        dic.Add(new Tuple<int, int>(tmp.Item1 - 1, tmp.Item2), dic[tmp]);
                    }
                }

                if (rowInBounds(tmp.Item1 + 1) && colInBounds(tmp.Item2) && !visited.Contains(new Tuple<int, int>(tmp.Item1 + 1, tmp.Item2)))
                {
                    if (maze[tmp.Item1 + 1, tmp.Item2] == 's')
                    {
                        stack.Push(new Tuple<int, int>(tmp.Item1 + 1, tmp.Item2));
                        visited.Add(stack.Peek());
                        dic.Add(new Tuple<int, int>(tmp.Item1 + 1, tmp.Item2), dic[tmp] + 1);
                    }
                    if (maze[tmp.Item1 + 1, tmp.Item2] == '.' || maze[tmp.Item1 + 1, tmp.Item2] == 'x')
                    {
                        stack.Push(new Tuple<int, int>(tmp.Item1 + 1, tmp.Item2));
                        visited.Add(stack.Peek());
                        dic.Add(new Tuple<int, int>(tmp.Item1 + 1, tmp.Item2), dic[tmp]);
                    }
                }
                if (rowInBounds(tmp.Item1) && colInBounds(tmp.Item2 - 1) && !visited.Contains(new Tuple<int, int>(tmp.Item1, tmp.Item2 - 1)))
                {
                    if (maze[tmp.Item1, tmp.Item2 - 1] == 's')
                    {
                        stack.Push(new Tuple<int, int>(tmp.Item1, tmp.Item2 - 1));
                        visited.Add(stack.Peek());
                        dic.Add(new Tuple<int, int>(tmp.Item1, tmp.Item2 - 1), dic[tmp] + 1);
                    }
                    if (maze[tmp.Item1, tmp.Item2 - 1] == '.' || maze[tmp.Item1, tmp.Item2 - 1] == 'x')
                    {
                        stack.Push(new Tuple<int, int>(tmp.Item1, tmp.Item2 - 1));
                        visited.Add(stack.Peek());
                        dic.Add(new Tuple<int, int>(tmp.Item1, tmp.Item2 - 1), dic[tmp]);
                    }
                }
                if (rowInBounds(tmp.Item1) && colInBounds(tmp.Item2 + 1) && !visited.Contains(new Tuple<int, int>(tmp.Item1, tmp.Item2 + 1)))
                {
                    if (maze[tmp.Item1, tmp.Item2 + 1] == 's')
                    {
                        stack.Push(new Tuple<int, int>(tmp.Item1, tmp.Item2 + 1));
                        visited.Add(stack.Peek());
                        dic.Add(new Tuple<int, int>(tmp.Item1, tmp.Item2 + 1), dic[tmp] + 1);
                    }
                    if (maze[tmp.Item1, tmp.Item2 + 1] == '.' || maze[tmp.Item1, tmp.Item2 + 1] == 'x')
                    {
                        stack.Push(new Tuple<int, int>(tmp.Item1, tmp.Item2 + 1));
                        visited.Add(stack.Peek());
                        dic.Add(new Tuple<int, int>(tmp.Item1, tmp.Item2 + 1), dic[tmp]);
                    }

                }
                
            }

            if(answer <= j / 2) Console.WriteLine("SUCCESS");
            else Console.WriteLine("IMPOSSIBLE");
        }
    }
}