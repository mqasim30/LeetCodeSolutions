namespace LeetCode.AverageWaitingTime;

public class Solution
{
    public double AverageWaitingTime(int[][] customers)
    {
        int n = customers.Length;
        double timeWaiting = customers[0][1];
        int finishedPrev = customers[0][0] + customers[0][1];

        for (int customerInd = 1; customerInd < n; ++customerInd)
        {
            int[] times = customers[customerInd];
            int arrive = times[0];

            int startCook = Math.Max(arrive, finishedPrev);
            int endTime = startCook + times[1];
            finishedPrev = endTime;
            timeWaiting += endTime - arrive;
        }

        return timeWaiting / n;
    }
}
