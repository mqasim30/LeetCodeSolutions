using System.Net.NetworkInformation;

namespace LeetCode.MergeSortedArray
{

    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int pointer1 = 0;
            int pointer2 = 0;
            int index = 0;
            int[] result = new int[nums1.Length];
            while (m != 0 && n != 0)
            {
                if (nums1[pointer1] == nums2[pointer2])
                {
                    result[index] = nums1[pointer1];
                    index += 1;
                    result[index] = nums2[pointer2];
                    index += 1;
                    pointer1 += 1;
                    pointer2 += 1;
                    m -= 1;
                    n -= 1;
                }
                else if (nums1[pointer1] < nums2[pointer2])
                {
                    result[index] = nums1[pointer1];
                    pointer1 += 1;
                    index += 1;
                    m -= 1;
                }
                else if (nums1[pointer1] > nums2[pointer2])
                {
                    result[index] = nums2[pointer2];
                    pointer2 += 1;
                    index += 1;
                    n -= 1;
                }
            }

            if (m == 0 && n != 0)
            {
                while (n != 0)
                {
                    result[index] = nums2[pointer2];
                    pointer2 += 1;
                    index += 1;
                    n -= 1;
                }
            }
            else
            {
                while (m != 0)
                {
                    result[index] = nums1[pointer1];
                    pointer1 += 1;
                    index += 1;
                    m -= 1;
                }
            }
            for (int i = 0; i < result.Length; i++)
            {
                nums1[i] = result[i];
            }
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] nums1 = [1, 2, 3, 0, 0, 0];
    //         int[] nums2 = [2, 5, 6];
    //         //int[] nums1 = [0];
    //         //int[] nums2 = [1];
    //         solution.Merge(nums1, 3, nums2, 3);
    //         foreach (var item in nums1)
    //         {
    //             Console.WriteLine(item);
    //         }
    //     }
    // }

}