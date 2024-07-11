namespace LeetCode.IntersectionofTwoArraysII;

public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        List<int> ints = new List<int>();
        int left = 0;
        int right = 0;
        Array.Sort(nums1);
        Array.Sort(nums2);
        while (left < nums1.Length && right < nums2.Length)
        {
            if (nums1[left] == nums2[right])
            {
                ints.Add(nums1[left]);
                left++;
                right++;
            }
            else if (nums1[left] < nums2[right])
            {
                left++;
            }
            else if (nums1[left] > nums2[right])
            {
                right++;
            }
        }
        return ints.ToArray();
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] arr1 = [4, 9, 5];
//         int[] arr2 = [9, 4, 9, 8, 4];
//         solution.Intersect(arr1, arr2);
//     }
// }