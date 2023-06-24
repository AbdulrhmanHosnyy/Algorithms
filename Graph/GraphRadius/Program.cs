using System.Collections.Generic;

namespace GraphRadius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GraphRadius(new int[] { 0, 1, 2, 3, 4, 5 },
               new KeyValuePair<int, int>[] {
                    new KeyValuePair<int, int>(0, 2),
                    new KeyValuePair<int, int>(0, 1),
                    new KeyValuePair<int, int>(1, 2),
                    new KeyValuePair<int, int>(4, 3),
                    new KeyValuePair<int, int>(5, 3),
                    new KeyValuePair<int, int>(2, 3),

               });
        }

        private static void GraphRadius(int[] vertices, KeyValuePair<int, int>[] edges)
        {
            int n = vertices.Length;
            var graph = buildGraph(ref edges, ref vertices);

            int radius = int.MaxValue;

            foreach (var vertex in graph.Keys)
            {
                Queue<int> queue = new Queue<int>();
                HashSet<int> visited = new HashSet<int>();
                int[] dist = new int[n];

                for (int i = 0; i < dist.Length; i++)
                {
                    dist[i] = int.MaxValue;
                }

                queue.Enqueue(vertex);
                visited.Add(vertex);
                dist[vertex] = 0;

                while (queue.Count > 0)
                {
                    int current = queue.Dequeue();

                    foreach (var neighbor in graph[current])
                        if(!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            visited.Add(neighbor);
                            dist[neighbor] = dist[current] + 1;
                        }
                }
                  
                int eccentricity = dist.Max();
                if (eccentricity < radius)  
                {
                    radius = eccentricity;
                }
            }
            Console.WriteLine("Radius : " + radius);

        }

        private static Dictionary<int, List<int>> buildGraph(ref KeyValuePair<int, int>[] edges, ref int[] vertices)
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