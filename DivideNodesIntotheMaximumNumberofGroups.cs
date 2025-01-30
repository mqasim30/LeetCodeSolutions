namespace LeetCode.DivideNodesIntotheMaximumNumberofGroups;

public class Solution
{
    public int MagnificentSets(int numNodes, int[][] edgesList)
    {
        var adjacencyList = new List<int>[numNodes];

        for (int i = 0; i < numNodes; i++)
            adjacencyList[i] = [];

        foreach (int[] edge in edgesList)
        {
            int node1 = edge[0] - 1, node2 = edge[1] - 1;
            adjacencyList[node1].Add(node2);
            adjacencyList[node2].Add(node1);
        }

        var nodeDistances = new int[numNodes];

        for (int startNode = 0; startNode < numNodes; ++startNode)
        {
            var nodeQueue = new Queue<int>();
            nodeQueue.Enqueue(startNode);

            var distance = new int[numNodes];
            distance[startNode] = 1;

            var maxDistance = 1;
            int rootNode = startNode;

            while (nodeQueue.Count > 0)
            {
                int currentNode = nodeQueue.Dequeue();
                rootNode = Math.Min(rootNode, currentNode);

                foreach (int neighbor in adjacencyList[currentNode])
                {
                    if (distance[neighbor] == 0)
                    {
                        distance[neighbor] = distance[currentNode] + 1;
                        maxDistance = Math.Max(maxDistance, distance[neighbor]);
                        nodeQueue.Enqueue(neighbor);
                    }
                    else if (Math.Abs(distance[neighbor] - distance[currentNode]) != 1)
                    {
                        return -1;
                    }
                }
            }

            nodeDistances[rootNode] = Math.Max(nodeDistances[rootNode], maxDistance);
        }

        return nodeDistances.Sum();
    }
}