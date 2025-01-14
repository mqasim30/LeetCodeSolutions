namespace LeetCode.FindthePrefixCommonArrayofTwoArrays;

public class Solution
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        int n = A.Length, common = 0;
        int[] C = new int[n], commonArray = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            commonArray[A[i]] ^= A[i];
            if (commonArray[A[i]] == 0) common++;

            commonArray[B[i]] ^= B[i];
            if (commonArray[B[i]] == 0) common++;

            C[i] = common;
        }

        return C;
    }
}