namespace LeetCode.FindtheDifferenceofTwoArrays;
public class Solution
{
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        IList<IList<int>> results = new List<IList<int>>() { new List<int>(), new List<int>() };
        HashSet<int> ints1 = [.. nums1];
        HashSet<int> ints2 = [.. nums2];

        foreach (int item in ints1)
        {
            if (!ints2.Contains(item))
            {
                results[0].Add(item);
            }
        }

        foreach (var item in ints2)
        {
            if (!ints1.Contains(item))
            {
                results[1].Add(item);
            }
        }

        return results;
    }
}


// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] nums1 = [1, 2, 3, 3], nums2 = [1, 1, 2, 2];
//         solution.FindDifference(nums1, nums2);
//     }
// }

