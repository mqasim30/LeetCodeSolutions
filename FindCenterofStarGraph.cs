namespace LeetCode.FindCenterofStarGraph;
public class Solution
{
    public int FindCenter(int[][] edges)
    {
        return edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1] ? edges[0][0] : edges[0][1];
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[][] edges = [[1, 2], [2, 3], [4, 2]];
//         Console.WriteLine(solution.FindCenter(edges));
//     }
// }