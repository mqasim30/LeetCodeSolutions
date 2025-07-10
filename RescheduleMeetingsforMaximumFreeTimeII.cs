namespace LeetCode.RescheduleMeetingsforMaximumFreeTimeII;

public class Solution
{
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
    {
        int n = startTime.Length;
        bool[] q = new bool[n];
        int t1 = 0, t2 = 0;
        for (int i = 0; i < n; i++)
        {
            if (endTime[i] - startTime[i] <= t1)
            {
                q[i] = true;
            }
            t1 = Math.Max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

            if (endTime[n - i - 1] - startTime[n - i - 1] <= t2)
            {
                q[n - i - 1] = true;
            }
            t2 = Math.Max(t2, (i == 0 ? eventTime : startTime[n - i]) -
                                  endTime[n - i - 1]);
        }

        int res = 0;
        for (int i = 0; i < n; i++)
        {
            int left = i == 0 ? 0 : endTime[i - 1];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            if (q[i])
            {
                res = Math.Max(res, right - left);
            }
            else
            {
                res = Math.Max(res, right - left - (endTime[i] - startTime[i]));
            }
        }
        return res;
    }
}