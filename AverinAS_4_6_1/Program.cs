using System;
using System.Collections.Generic;

class Graph
{
    public Dictionary<int, List<int>> AdjacencyList { get; private set; }

    public Graph()
    {
        AdjacencyList = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int u, int v)
    {
        if (!AdjacencyList.ContainsKey(u))
            AdjacencyList[u] = new List<int>();
        if (!AdjacencyList.ContainsKey(v))
            AdjacencyList[v] = new List<int>();
        AdjacencyList[u].Add(v);
        AdjacencyList[v].Add(u);
    }

    public List<List<int>> FindConnectedComponents()
    {
        var visited = new HashSet<int>();
        var components = new List<List<int>>();

        foreach (var node in AdjacencyList.Keys)
        {
            if (!visited.Contains(node))
            {
                var component = new List<int>();
                DFS(node, visited, component);
                components.Add(component);
            }
        }
        return components;
    }

    private void DFS(int node, HashSet<int> visited, List<int> component)
    {
        visited.Add(node);
        component.Add(node);
        foreach (var neighbor in AdjacencyList[node])
        {
            if (!visited.Contains(neighbor))
            {
                DFS(neighbor, visited, component);
            }
        }
    }
    
    public void PrintComponents()
    {
        var components = FindConnectedComponents();
        Console.WriteLine("Connected Components:");
        foreach (var component in components)
        {
            Console.WriteLine(string.Join(", ", component));
        }
    }
}
class Program
{
    static void Main()
    {
        var graph = new Graph();
        
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        graph.AddEdge(4, 5);
        graph.AddEdge(5, 6);
        
        graph.AddEdge(7, 7);
        
        graph.PrintComponents();
    }
}