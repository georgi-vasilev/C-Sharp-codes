﻿using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace KruskalAlgoDemo
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weigth { get; set; }
    }
    class Program
    {
        static HashSet<int> spanningTree = new HashSet<int>();
        static Dictionary<int, List<Edge>> nodeToEdges = new Dictionary<int, List<Edge>>();

        static void Main(string[] args)
        {
            var graph = new List<Edge>
            {
                new Edge { First = 2, Second = 4, Weigth = 2},
                new Edge { First = 1, Second = 2, Weigth = 4},
                new Edge { First = 1, Second = 3, Weigth = 5},
                new Edge { First = 3, Second = 5, Weigth = 7},
                new Edge { First = 8, Second = 9, Weigth = 7},
                new Edge { First = 4, Second = 5, Weigth = 8},
                new Edge { First = 7, Second = 8, Weigth = 8},
                new Edge { First = 1, Second = 4, Weigth = 9},
                new Edge { First = 7, Second = 9, Weigth = 10},
                new Edge { First = 5, Second = 6, Weigth = 12},
                new Edge { First = 3, Second = 4, Weigth = 20}
            };

            var nodes = graph
                .Select(e => e.First)
                .Union(graph.Select(e => e.Second))
                .Distinct()
                .OrderBy(e => e)
                .ToHashSet();

            foreach (var edge in graph)
            {
                if (!nodeToEdges.ContainsKey(edge.First))
                {
                    nodeToEdges[edge.First] = new List<Edge>();
                }
                if (!nodeToEdges.ContainsKey(edge.Second))
                {
                    nodeToEdges[edge.Second] = new List<Edge>();
                }
            }

            foreach (var node in nodes)
            {
                if (!spanningTree.Contains(node))
                {
                    Prim(node);
                }
            }
        }
        static void Prim(int startingNode)
        {
            spanningTree.Add(startingNode);

            var priorityQueue =
                new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weigth - s.Weigth));

            priorityQueue.AddMany(nodeToEdges[startingNode]);
            while (priorityQueue.Count != 0)
            {
                var minEdge = priorityQueue.GetFirst();
                priorityQueue.Remove(minEdge);

                var firstNode = minEdge.First;
                var secondNode = minEdge.Second;

                var nonTreeNode = -1;

                if (spanningTree.Contains(firstNode) &&
                    !spanningTree.Contains(secondNode))
                {
                    nonTreeNode = secondNode;
                }
                if (spanningTree.Contains(secondNode) &&
                    !spanningTree.Contains(firstNode))
                {
                    nonTreeNode = firstNode;
                }
                if (nonTreeNode == -1)
                {
                    continue;
                }

                spanningTree.Add(nonTreeNode);

                Console.WriteLine($"{minEdge.First} - {minEdge.Second}");

                priorityQueue.AddMany(nodeToEdges[nonTreeNode]);
            }
        }
    }
}


