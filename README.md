# Intuition
To find the minimum height trees (MHTs) in a given tree, we need to identify the root nodes that produce the smallest height when the tree is rooted at them. The key observation is that the height of the tree is determined by its most distant leaves (nodes with only one connection). Therefore, by iteratively trimming the leaves, we can progressively reduce the tree until we find the root nodes that minimize the height.

# Approach
1. Graph Representation: Create an adjacency list representation of the graph using the input edges. This list will store the connections (edges) between nodes.
2. Identify Initial Leaves: Initialize a list of leaves (nodes with only one neighbor) from the graph.
3. Trim Leaves Iteratively: Iteratively remove the leaves from the graph, and in the process, adjust the degrees of their neighboring nodes. Add any new leaves (nodes with one neighbor) to a new list.
4. Continue until Remaining Nodes: Repeat the leaf trimming process until one or two nodes remain. These remaining nodes are the potential roots of the minimum height trees (MHTs).
5. Return Remaining Nodes: The remaining nodes are the potential roots of the minimum height trees. Return these nodes as the output.
# Complexity
- Time Complexity: The time complexity of the approach is approximately 
O(n). This is because we iterate through the leaves, removing them from the graph, and adjusting the adjacency list, which can be done in linear time relative to the number of nodes.
- Space Complexity: The space complexity of the approach is approximately O(n) due to the adjacency list representation of the graph and the list of leaves.
