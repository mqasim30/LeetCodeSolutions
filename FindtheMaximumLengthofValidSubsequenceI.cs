namespace LeetCode.FindtheMaximumLengthofValidSubsequenceI;

public class Solution
{
    public int MaximumLength(int[] nums)
    {
        int res = 0;
        int[,] patterns =
            new int[4, 2] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
        for (int i = 0; i < 4; i++)
        {
            int cnt = 0;
            foreach (int num in nums)
            {
                if (num % 2 == patterns[i, cnt % 2])
                {
                    cnt++;
                }
            }
            res = Math.Max(res, cnt);
        }
        return res;
    }
}