namespace CycleDetection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vertices = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            KeyValuePair<int, int>[] edges = {
                new KeyValuePair<int, int>(0, 1),
                new KeyValuePair<int, int>(0, 4),
                new KeyValuePair<int, int>(1, 5),
                new KeyValuePair<int, int>(4, 5),
                new KeyValuePair<int, int>(2, 6),
                new KeyValuePair<int, int>(6, 3),
                new KeyValuePair<int, int>(2, 3),
                new KeyValuePair<int, int>(6, 7),
                new KeyValuePair<int, int>(8, 9),
                new KeyValuePair<int, int>(8, 10),
                new KeyValuePair<int, int>(9, 10),

            };

            var graph = buildGraph(ref vertices, ref edges);
            int[] color = new int[graph.Count];

            foreach (var vertex in vertices)
            {
                if (color[vertex] == 0) DFS(ref graph, vertex, ref color , -1);
            }

        }
        private static void DFS(ref Dictionary<int, List<int>> graph, int vertex, ref int[] color, int parent)
        {
            color[vertex] = 1;
            foreach (var neighbour in graph[vertex])
            {
                if (neighbour != parent)
                {
                    if (color[neighbour] == 0)
                    {
                        color[neighbour] = 1;
                        DFS(ref graph, neighbour, ref color, vertex);
                    }
                    else if (color[neighbour] == 1)
                    {
                        Console.WriteLine("cycle is detected");
                        Console.WriteLine("cycle start vertex is " + vertex);
                        Console.WriteLine("cycle end vertex is " + neighbour);
                    }
                }
            }
            color[vertex] = 2;
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

