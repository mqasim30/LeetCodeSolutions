namespace LeetCode.SortthePeople;

public class Solution
{
    public string[] SortPeople(string[] names, int[] heights)
    {
        Array.Sort(heights, names, Comparer<int>.Create((x, y) => y.CompareTo(x)));
        return names;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         string[] names = ["Mary", "John", "Emma"];
//         int[] heights = [180, 165, 170];
//         Console.WriteLine(solution.SortPeople(names, heights));
//     }
// }