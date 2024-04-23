using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Example 1:
        int n = 4;
        int[][] edges = new int[][] {
            new int[] {1, 0},
            new int[] {1, 2},
            new int[] {1, 3}
        };
        
        // Create an instance of the Solution class
        var solution = new Solution();
        
        // Call the FindMinHeightTrees method and store the result
        IList<int> result = solution.FindMinHeightTrees(n, edges);
        
        // Print the result
        Console.WriteLine("Minimum height trees roots:");
        foreach (var root in result)
        {
            Console.WriteLine(root);
        }
    }
}

public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        // If there's only one node, the root must be node 0
        if (n == 1) return new List<int> { 0 };

        // Initialize adjacency list to represent the graph
        var adjList = new List<HashSet<int>>(n);
        for (int i = 0; i < n; i++) {
            adjList.Add(new HashSet<int>());
        }
        
        // Populate the adjacency list
        foreach (var edge in edges) {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        
        // Initialize the list of leaves (nodes with only one neighbor)
        var leaves = new List<int>();
        for (int i = 0; i < n; i++) {
            if (adjList[i].Count == 1) {
                leaves.Add(i);
            }
        }
        
        // Iteratively remove leaves until we have one or two nodes left
        while (n > 2) {
            n -= leaves.Count;
            var newLeaves = new List<int>();
            
            foreach (int leaf in leaves) {
                // Find the neighbor of the leaf
                int neighbor = adjList[leaf].First();
                
                // Remove the leaf from the neighbor's adjacency list
                adjList[neighbor].Remove(leaf);
                
                // If the neighbor becomes a leaf, add it to the new leaves list
                if (adjList[neighbor].Count == 1) {
                    newLeaves.Add(neighbor);
                }
            }
            
            // Update leaves with the new leaves list
            leaves = newLeaves;
        }
        
        // Return the remaining nodes as the roots of minimum height trees
        return leaves;
    }
}
