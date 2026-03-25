namespace LeetCode.EqualSumGridPartitionI;

public class Solution {
    public bool CanPartitionGrid(int[][] grid) {
        long totalSum = 0;
        long[] horSum = new long[grid.Length];
        long[] verSum = new long[grid[0].Length];

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                totalSum += grid[i][j];
                horSum[i] += grid[i][j];
                verSum[j] += grid[i][j];
            }
        }

        int index = 0;
        long sumX = 0;
        long sumY = 0;

        while (((index < verSum.Length) || (index < horSum.Length)) && (sumX <= (totalSum / 2) + 1 || sumY <= (totalSum / 2) + 1)) {
            if (index < verSum.Length)
                sumY += verSum[index];

            if (index < horSum.Length)
                sumX += horSum[index];

            if ((sumX == totalSum - sumX) || (sumY == totalSum - sumY))
                return true;

            index++;
        }

        return false;
    }
}