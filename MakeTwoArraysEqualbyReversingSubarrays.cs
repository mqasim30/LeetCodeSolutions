namespace LeetCode.MakeTwoArraysEqualbyReversingSubarrays;

public class Solution
{
    public bool CanBeEqual(int[] target, int[] arr)
    {
        int[] cnt1 = new int[1001];
        int[] cnt2 = new int[1001];

        foreach (int v in target)
        {
            cnt1[v]++;
        }

        foreach (int v in arr)
        {
            cnt2[v]++;
        }

        for (int i = 0; i < 1001; i++)
        {
            if (cnt1[i] != cnt2[i])
            {
                return false;
            }
        }

        return true;
    }
}
