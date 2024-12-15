using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject
{
    internal class KruskalAlgorithm
    {
        public class Edge : IComparable<Edge>
        {
            public int Source, Destination, Weight;

            public int CompareTo(Edge other)
            {
                return this.Weight.CompareTo(other.Weight);
            }
        }

        public class Graph
        {
            public int Vertices, Edges;
            public Edge[] EdgeArray;

            public Graph(int vertices, int edges)
            {
                Vertices = vertices;
                Edges = edges;
                EdgeArray = new Edge[edges];
                for (int i = 0; i < edges; i++)
                    EdgeArray[i] = new Edge();
            }

            public int Find(int[] parent, int i)
            {
                if (parent[i] != i)
                    parent[i] = Find(parent, parent[i]);
                return parent[i];
            }

            public void Union(int[] parent, int[] rank, int x, int y)
            {
                int rootX = Find(parent, x);
                int rootY = Find(parent, y);

                if (rank[rootX] < rank[rootY])
                    parent[rootX] = rootY;
                else if (rank[rootX] > rank[rootY])
                    parent[rootY] = rootX;
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }

            public void KruskalMST()
            {
                Array.Sort(EdgeArray);

                int[] parent = new int[Vertices];
                int[] rank = new int[Vertices];

                for (int v = 0; v < Vertices; v++)
                {
                    parent[v] = v;
                    rank[v] = 0;
                }

                List<Edge> result = new List<Edge>();
                int edgeCount = 0, i = 0;

                while (edgeCount < Vertices - 1 && i < Edges)
                {
                    Edge nextEdge = EdgeArray[i++];

                    int x = Find(parent, nextEdge.Source);
                    int y = Find(parent, nextEdge.Destination);

                    if (x != y)
                    {
                        result.Add(nextEdge);
                        edgeCount++;
                        Union(parent, rank, x, y);
                    }
                }

                Console.WriteLine("Edges in the Minimum Spanning Tree:");
                foreach (var edge in result)
                {
                    Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
                }
            }
        }

        public static void Main(string[] args)
        {
            int vertices = 4;
            int edges = 5;

            Graph graph = new Graph(vertices, edges);

            graph.EdgeArray[0].Source = 0;
            graph.EdgeArray[0].Destination = 1;
            graph.EdgeArray[0].Weight = 10;

            graph.EdgeArray[1].Source = 0;
            graph.EdgeArray[1].Destination = 2;
            graph.EdgeArray[1].Weight = 6;

            graph.EdgeArray[2].Source = 0;
            graph.EdgeArray[2].Destination = 3;
            graph.EdgeArray[2].Weight = 5;

            graph.EdgeArray[3].Source = 1;
            graph.EdgeArray[3].Destination = 3;
            graph.EdgeArray[3].Weight = 15;

            graph.EdgeArray[4].Source = 2;
            graph.EdgeArray[4].Destination = 3;
            graph.EdgeArray[4].Weight = 4;

            graph.KruskalMST();
        }
    }
}
