namespace LeetCode.FindClosestNodetoGivenTwoNodes;

public class Solution
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        int n = edges.Length;
        if (node1 == node2)
            return node1;

        HashSet<int> v1 = new(), v2 = new();
        int idx1 = node1, idx2 = node2;
        int[] pre = [n + 1, n + 1];
        while (idx1 >= 0 || idx2 >= 0)
        {
            if (idx1 >= 0)
            {
                if (v2.Contains(idx1)) // it's visited by other node
                {
                    pre[0] = idx1;
                    idx1 = -1;
                }

                if (idx1 >= 0)
                {
                    if (!v1.Add(idx1)) // avoid cycle 
                        idx1 = -1;
                    else
                        idx1 = edges[idx1];
                }
            }

            if (idx2 >= 0)
            {
                if (v1.Contains(idx2))
                {
                    pre[1] = idx2;
                    idx2 = -1;
                }

                if (idx2 >= 0)
                {
                    if (!v2.Add(idx2))
                        idx2 = -1;
                    else
                        idx2 = edges[idx2];
                }
            }

            if (pre[0] < n || pre[1] < n)
                return Math.Min(pre[0], pre[1]);
        }

        return -1;
    }
}