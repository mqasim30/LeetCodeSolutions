namespace LeetCode.MinimumDominoRotationsForEqualRow;

public class Solution
{
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        var result = CheckMinDominoRotations(tops[0], tops, bottoms);
        if (result != -1 || tops[0] == bottoms[0]) return result;
        return CheckMinDominoRotations(bottoms[0], tops, bottoms);
    }

    public int CheckMinDominoRotations(int x, int[] A, int[] B)
    {
        int rotateA = 0, rotateB = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] != x && B[i] != x) return -1;
            else if (A[i] != x) rotateA++;
            else if (B[i] != x) rotateB++;
        }

        return Math.Min(rotateA, rotateB);
    }
}