namespace LeetCode.MergeTwo2DArraysbySummingValues;

public class Solution
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {

        List<int[]> result = new List<int[]>();
        int i = 0, j = 0;
        while (i < nums1.Length || j < nums2.Length)
        {
            if (i >= nums1.Length)
            {
                result.Add(nums2[j]);
                j++;
            }
            else if (j >= nums2.Length)
            {
                result.Add(nums1[i]);
                i++;
            }
            else
            {
                if (nums1[i][0] == nums2[j][0])
                {
                    result.Add(new int[2] { nums1[i][0], nums1[i][1] + nums2[j][1] });
                    i++;
                    j++;
                }
                else if (nums1[i][0] < nums2[j][0])
                {
                    result.Add(new int[2] { nums1[i][0], nums1[i][1] });
                    i++;
                }
                else
                {
                    result.Add(new int[2] { nums2[j][0], nums2[j][1] });
                    j++;
                }
            }
        }

        return result.ToArray();
    }
}