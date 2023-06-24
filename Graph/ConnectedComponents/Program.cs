namespace ConnectedComponents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] vertices = { 0, 1, 2, 3, 4, 5, 6, 7, };
            //KeyValuePair<int, int>[] edges  = {
            //    new KeyValuePair<int, int>(0, 1),
            //    new KeyValuePair<int, int>(0, 4),
            //    new KeyValuePair<int, int>(2, 3),
            //    new KeyValuePair<int, int>(2, 6),
            //    new KeyValuePair<int, int>(3, 7),
            //    new KeyValuePair<int, int>(6, 7),
            //    new KeyValuePair<int, int>(5, 6),
            //    new KeyValuePair<int, int>(2, 5),
            //};

            int[] vertices = { 0, 1, 2, 3, 4, 5, 6, 7, };
            KeyValuePair<int, int>[] edges = {
                new KeyValuePair<int, int>(0, 1),
                new KeyValuePair<int, int>(4, 5),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(2, 6),
            };
            var graph = buildGraph(ref vertices, ref edges);
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            int[] comp = new int[graph.Count];

            int count = 1;
            foreach (var vertex in vertices)
            {
                if (!visited.Contains(vertex))
                {
                    queue.Enqueue(vertex);
                    visited.Add(vertex);
                    comp[vertex] = count;
                    while(queue.Count > 0)
                    {
                        int current = queue.Dequeue();
                        foreach (var neighbour in graph[current])
                        {
                            if (!visited.Contains(neighbour))
                            {
                                queue.Enqueue(neighbour);
                                visited.Add(neighbour);
                                comp[neighbour] = comp[current];
                            }
                        }
                    }
                    count++;
                }
            }

            for(int i = 0; i < graph.Count; i++)
            {
                Console.WriteLine(i + " " + comp[i]);
            }

        }
        private static Dictionary<int, List<int>> buildGraph(ref int[] vertices, ref KeyValuePair<int, int>[] edges)
        {
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < vertices.Length; i++)
            {
                graph[vertices[i]] = new List<int>();
            }
            foreach (var edge in edges)
            {
                graph[edge.Key].Add(edge.Value);
                graph[edge.Value].Add(edge.Key);
            }
            return graph;
        }
    }
}