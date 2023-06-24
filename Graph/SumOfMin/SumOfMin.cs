using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Linq.Enumerable;

namespace Problem
{
    public static class SumOfMin
    {
        public static int CalcSumOfMinInComps(int[] valuesOfVertices, KeyValuePair<int, int>[] edges)
        {
            int n = valuesOfVertices.Length;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (KeyValuePair<int, int> edge in edges)
            {
                int u = edge.Key;
                int v = edge.Value;
                graph[u].Add(v);
                graph[v].Add(u);
            }

            //var visited = new HashSet<int>(); 
            bool[] visited = new bool[n];
            int[] color = new int[n];
            int[] comp = new int[n];
            Queue<int> queue = new Queue<int>();

            int count = 1;
            foreach (var vertex in Range(0, n - 1))
            {
                if (!visited[vertex])
                {
                    queue.Enqueue(vertex);
                    visited[vertex] = true;
                    comp[vertex] = count;
                    while (queue.Count > 0)
                    {
                        int current = queue.Dequeue();
                        foreach (var neighbour in graph[current])
                        {
                            if (!visited[neighbour])
                            {
                                queue.Enqueue(neighbour);
                                visited[neighbour] = true;
                                comp[neighbour] = comp[current];
                            }
                        }
                    }
                    count++;
                }
            }
            Dictionary<int, int> helper = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (!helper.ContainsKey(comp[i]))
                {
                    helper.Add(comp[i], valuesOfVertices[i]);
                }
                else
                {
                    helper[comp[i]] = Math.Min(helper[comp[i]], valuesOfVertices[i]);
                }
            }
            int answer = 0;
            foreach (var item in helper)
            {
                answer += item.Value;
            }
            return answer;
        }
    }
}